using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//json 파일 문자 경로로 스프라이트 가져오기

public class GenerateCard : MonoBehaviour
{
    private float timeSinceStart;
    private char buffCode;
    private Dictionary<char, BuffStat> statGenerateDic;
    private Dictionary<char, CardInfo> infoGenerateDic;
    private Dictionary<char, AttackStatus> attackStatusGenerateDic;
    private Dictionary<char, AttackCardInfo> attacInfoGenerateDic;

    public GameObject cardPrefab;
    public GameObject attackCardPrefab;

    StatusEffect buffEffect;
    //추후 카드 프리팹에 들어갈 요소, 이미지 들을 정리할 구조체가 필요할듯.

    public int cardCount;

    GraphicRaycaster graphicRaycaster;
    PointerEventData pointerEventData;

    [SerializeField]
    EventSystem eventSystem;


    private void Start()
    {
        
        graphicRaycaster = GetComponent<GraphicRaycaster>();

        if (GameObject.FindWithTag("BuffManager")
            .TryGetComponent<BuffManager>(out BuffManager buffManager))
        {
            this.statGenerateDic = buffManager.StatToGenerate();
            this.infoGenerateDic = buffManager.InfoToGenerate();
            this.attackStatusGenerateDic = buffManager.AttackStatToGenerate();
            this.attacInfoGenerateDic = buffManager.AttackInfoToGenerate();
        }

        AttackGenerate();
    }

    // 이 부분에서 생성을 어떻게 처리할지?

    // 1. attack과 buff 생성기의 함수를 따로 만들어 처리한다.
    // 2. 분기로 처리한다.
    // 3. 나누지 않고 하나의 오브젝트를 받고, Add 컴포넌트 처리

    // 어택 제너레이트 고려해야 할 점.
    /*
     * 1. 카드를 누르면 이벤트가 처리되어, 개체가 생성되어야 함.
     * 2. 생성된 개체는 업데이트된 성능으로 생성됨.
     * 3. 이미 생성된 개체들도 자동적으로 업데이트 되도록 만들어야 함.
     * 4. 그렇다면 각 카드에 특수기능을 넣어서 관리하여야 하는지..? 아니라면 
     * 5. 일괄적용 기능과 함수 제어는 어텍 제너레이터안에 리스트로 관리해야할것 같다.
    */
    private void Update()
    {
        if ((timeSinceStart  = Time.realtimeSinceStartup)% 30 == 0)
        {
            
        }
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
                    buffEffect = statusEffect;
                    buffEffect.OnChecked();
                }
                else if(result.gameObject.transform.parent.TryGetComponent<AbstractAttack>(out AbstractAttack attack))
                {
                    attack.OnChecked();
                }
                else
                { Debug.Log("not defined raytarget"); }
            }
        }
    }

    // 고려 사항
    /* 1. 카드 개수
     * 2. 코드 지급 확률 계산
     * 3. 카드 생성 시간
     * 
     */
    void BuffGenerate() // -> 여기에 특수, 악마, 천사, 일반카드 재사용하도록 짜기
    {
        for (int i = 0; i < cardCount; i++)
        {
            var cardObj = Instantiate(cardPrefab,this.transform);
            //buffCode = (char)Random.Range(1, statGenerateDic.Count + 1);
            // 생성된 카드들 배치하는것도 만들어야 함.
            char _buffCode = (char)0;

            var targetCard = cardObj.GetComponent<StatusEffect>() ??  null;

            if (infoGenerateDic.TryGetValue(_buffCode, out CardInfo cardInfo))
            {
                targetCard?.GetRandomCodeWithInfo(buffCode, cardInfo, statGenerateDic[buffCode]);
                targetCard?.SetCardInfo();
                //스탯을 어떻게 적용시켜줄건지?
            }
            else Debug.Log("Missing value");
            
            //Will be change
        }
    }

    void AttackGenerate()
    {
        
        //카드 카운트 수정
        for (int i = 0; i < cardCount; i++)
        {
            var cardObj = Instantiate(attackCardPrefab, this.transform);

            cardObj.GetComponent<RectTransform>().anchoredPosition = new Vector2((-210 + (i * 140)),0f) ;

            //buffCode = (char)Random.Range(1, statGenerateDic.Count + 1);
            char _attackCode = (char)UnityEngine.Random.Range(0,3);
            AbstractAttack targetCard = null;
            switch (attackStatusGenerateDic[_attackCode].attackType)
            {
                case AttackType.laser:
                    targetCard = cardObj.AddComponent<LaserAttack>();
                    break;
                case AttackType.guided:
                    targetCard = cardObj.AddComponent<TrapAttack>();
                    break;
                case AttackType.bullet:
                    targetCard = cardObj.AddComponent<BulletAttack>();
                    break;
                case AttackType.trap:
                    targetCard = cardObj.AddComponent<TrapAttack>();
                    break;
                default:
                    Debug.Log("There is no maching attack type");
                    break;
            }

            // 어택 데이터 어떻게 처리할건지? 여기서 가져올거임?
            if (attacInfoGenerateDic.TryGetValue(_attackCode, out AttackCardInfo attacinfo))
            {
                targetCard?.GetRandomCodeWithInfo(_attackCode, attacinfo, attackStatusGenerateDic[_attackCode]);
                Debug.Log(targetCard?._AttackCardInfo.attackCardEnum);
                targetCard?.SetCardInfo();
            }
            else Debug.Log("Missing value");

            //Will be change
        }


        //for (int i = 0; i < 3; i++)
        //{
        //    buffStorage = (BuffEnumStorage)Random.Range(0, buffStorageLength);
        //    var d = Instantiate(cardPrefab, buffManager.transform);

        //    var asd = buffManager.ReturnBuff(buffStorage);

        //}
    }
}
