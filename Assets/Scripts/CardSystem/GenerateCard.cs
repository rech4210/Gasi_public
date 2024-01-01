using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GenerateCard : MonoBehaviour
{
    private float timeSinceStart;
    Queue<Action> actions = new Queue<Action>();

    public void getact(Action action)
    {
        actions.Enqueue(action);
    }

    BuffManager buffManager;
    AttackGenerator attackGenerator;

    private Dictionary<int, BuffData> buffArchive = new();
    private Dictionary<int, AttackData> attackArchive = new();

    private Dictionary<int, BuffStat> containStatGenerateDic = new();
    private Dictionary<int, AttackStatus> containAttackStatusGenerateDic = new();

    public GameObject cardPrefab;
    public GameObject attackCardPrefab;

    private List<GameObject> buffCardList = new List<GameObject>();
    private List<GameObject> attackCardList = new List<GameObject>();


    //추후 카드 프리팹에 들어갈 요소, 이미지 들을 정리할 구조체가 필요할듯.

    public int cardCount; // 이거 값 public임을 명심하자.
    #region start 함수와 point 정의
    GraphicRaycaster graphicRaycaster;
    PointerEventData pointerEventData;

    [SerializeField]
    EventSystem eventSystem;

    private void Start()
    {

        graphicRaycaster = GetComponent<GraphicRaycaster>();

        buffArchive = DataManager.Instance.ReturnDict(buffArchive);
        attackArchive = DataManager.Instance.ReturnDict(attackArchive);
        try
        {
            if (GameObject.FindWithTag("AttackGenerator")
            .TryGetComponent(out AttackGenerator attack))
            {
                this.attackGenerator = attack;
            }
            if (GameObject.FindWithTag("BuffManager")
            .TryGetComponent(out BuffManager buff))
            {

                this.buffManager = buff;
            }
        }

        catch (System.NullReferenceException e)
        {
            Debug.LogError($"에러 대상:{this.name}$에러 내용: {e.Message}");
            throw e;
        }

        InvokeRepeating("AttackGenerate", 0f, 10f);
        InvokeRepeating("BuffGenerate", 0.1f, 15f);

        // 이 부분 액션 멀티캐스트로 처리하기

        //StartCoroutine(BuffGenerate());
        //StartCoroutine(AttackGenerate());

    }

    #endregion

    // 어택 제너레이트 고려해야 할 점.
    /*
     * 1. 카드를 누르면 이벤트가 처리되어, 개체가 생성되어야 함.
     * 2. 생성된 개체는 업데이트된 성능으로 생성됨.
     * 3. 이미 생성된 개체들도 자동적으로 업데이트 되도록 만들어야 함.
     * 4. 그렇다면 각 카드에 특수기능을 넣어서 관리하여야 하는지..? 아니라면 
     * 5. 일괄적용 기능과 함수 제어는 어텍 제너레이터안에 리스트로 관리해야할것 같다.
    */

    async void test()
    {
        Task a = new Task(() => AttackGenerate());
        a.Start();
        a.Wait(5000);
        await a;
        Debug.Log("delay end");
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) /*스페이스바로도*/)
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();

            graphicRaycaster.Raycast(pointerEventData, raycastResults);

            //중복 누름에 대한 우려 존재
            foreach (var result in raycastResults) 
            {
                if(result.gameObject.transform.parent.TryGetComponent<StatusEffect>(out StatusEffect statusEffect))
                {
                    statusEffect.OnChecked();
                    for (int i = 0; i < buffCardList.Count; i++)
                    {
                        Destroy(buffCardList[i]);
                        Time.timeScale = 1.0f;
                    }
                    buffCardList.Clear();
                }
                else if(result.gameObject.transform.parent.TryGetComponent<AbstractAttack>(out AbstractAttack attack))
                {
                    attack.OnChecked();
                    for (int i = 0; i < attackCardList.Count; i++)
                    {
                        Destroy(attackCardList[i]);
                        Time.timeScale = 1.0f;
                    }
                    attackCardList.Clear();
                }
                else { Debug.Log("not defined raytarget"); }

            }
        }
    }

    // 고려 사항
    /* 1. 카드 개수
     * 2. 코드 지급 확률 계산
     * 3. 카드 생성 시간
     * 
     */


    //카드 생성시 문자열 + 숫자 조합하여 해당하는 카드 생성하도록??
    void BuffGenerate() // -> 여기에 특수, 악마, 천사, 일반카드 재사용하도록 짜기
    {
        //Time.timeScale = .0f;
        containStatGenerateDic = buffManager.ContainStatToGenerate();
        for (int i = 0; i < cardCount; i++)
        {
            var cardGameObj = Instantiate(cardPrefab, this.transform);
            //buffCode = (char)Random.Range(1, statGenerateDic.Count + 1);
            // 생성된 카드들 배치하는것도 만들어야 함.
            char _buffCode = (char)0;
            var data = buffArchive[_buffCode];

                
            var targetCard = cardGameObj.GetComponent<StatusEffect>() ?? null;
            buffCardList.Add(cardGameObj);
            if (containStatGenerateDic.TryGetValue(_buffCode, out BuffStat stat) /*&& containStatGenerateDic[_buffCode].rank > 0*/)
            {
                targetCard?.GetRandomCodeWithInfo(data);
                targetCard?.SetCardInfo();
            }
            else
            {
                targetCard?.GetRandomCodeWithInfo(data);
                targetCard?.SetCardInfo();
                //스탯을 어떻게 적용시켜줄건지?
            }
        }

        //yield return new WaitForSecondsRealtime(15f);
        Time.timeScale = .0f;

        //if (buffCardList.Count != 0)
        //{
        //    Debug.Log("선택하지 않음 축복 소멸");
        //    RemoveCard(buffCardList);
        //}
    }

    
    void AttackGenerate()
    {

        containAttackStatusGenerateDic = attackGenerator.ContainAttackStatToGenerate();

        //카드 카운트 수정
        for (int i = 0; i < cardCount; i++)
        {
            var cardGameObj = Instantiate(attackCardPrefab, this.transform);
            attackCardList.Add(cardGameObj);
            cardGameObj.GetComponent<RectTransform>().anchoredPosition = new Vector2((-210 + (i * 140)), 0f);


            //buffCode = (char)Random.Range(1, statGenerateDic.Count + 1);
            char _attackCode = (char)UnityEngine.Random.Range(0, 4);

            var data = attackArchive[_attackCode];

            AbstractAttack targetCard = null;

            switch (data.attackStatus.attackType)
            {
                case AttackType.laser:
                    targetCard = cardGameObj.AddComponent<LaserAttack>();
                    break;
                case AttackType.guided:
                    targetCard = cardGameObj.AddComponent<GuidedAttack>();
                    break;
                case AttackType.bullet:
                    targetCard = cardGameObj.AddComponent<BulletAttack>();
                    break;
                case AttackType.trap:
                    targetCard = cardGameObj.AddComponent<TrapAttack>();
                    break;
                default:
                    Debug.Log("There is no maching attack type 정의되지 않은 카드입니다");
                    break;
            }

            // 현재 딕셔너리에 값이 저장된 이력이 있다면.
            // 단, 상승 스탯카드는 공격 타겟이 존재할때 사용
            if (containAttackStatusGenerateDic.TryGetValue(_attackCode, out AttackStatus containAttackStat))
            {
                targetCard?.GetRandomCodeWithInfo(data);
                //Debug.Log(targetCard?._AttackData.attackInfo.attackCardEnum);
                targetCard?.SetCardInfo();
            }
            else
            {
                targetCard?.GetRandomCodeWithInfo(data);
                //Debug.Log(targetCard?._AttackData.attackInfo.attackCardEnum);
                targetCard?.SetCardInfo();
            }

        }

        //yield return new WaitForSecondsRealtime(15f);
        Time.timeScale = .0f;
        //if (attackCardList.Count != 0)
        //{
        //    Debug.Log("선택하지 않음 패널티 부여");
        //    RemoveCard(attackCardList);
        //}


    }


    private void RemoveCard(List<GameObject> carList)
    {
        for (int i = 0; i < carList.Count; i++) 
        {
            Destroy(carList[i]);
        }
        carList.Clear();
    }
}
