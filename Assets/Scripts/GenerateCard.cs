using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//json 파일 문자 경로로 스프라이트 가져오기


public class GenerateCard : MonoBehaviour
{
    private char buffCode;
    private Dictionary<char, BuffStat> statGenerateDic;
    private Dictionary<char, CardInfo> infoGenerateDic;
    public GameObject cardPrefab;
    PowerUp powerUp;
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

        }
        Generate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();

            graphicRaycaster.Raycast(pointerEventData, raycastResults);

            //중복 누름에 대한 우려 존재
            foreach (var result in raycastResults) 
            {
                if(result.gameObject.transform.parent.TryGetComponent<PowerUp>(out PowerUp component))
                {
                    powerUp = component;
                    powerUp.OnChecked();
                }
                else
                {
                    Debug.Log("찾을수 없는 컴포넌트 대상");
                }
                
            }
        }
    }

    // 고려 사항
    /* 1. 카드 개수
     * 2. 코드 지급 확률 계산
     * 3. 
     * 
     */
    void Generate() // -> 여기에 특수, 악마, 천사, 일반카드 재사용하도록 짜기
    {
        for (int i = 0; i < cardCount; i++)
        {
            var cardObj = Instantiate(cardPrefab,this.transform);
            var _buffcode = (char)Random.Range(1, statGenerateDic.Count + 1);

            cardObj.GetComponent<PowerUp>()
                .GetRandomCodeWithInfo(_buffcode, infoGenerateDic[_buffcode]);
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
