using System.Collections.Generic;
using UnityEngine;
public class GenerateCard : MonoBehaviour
{
    private char buffCode;
    private Dictionary<char, BuffStat> allBuffArchive;
    public GameObject cardPrefab;
    //추후 카드 프리팹에 들어갈 요소, 이미지 들을 정리할 구조체가 필요할듯.

    public int cardCount;

    private void Start()
    {
        if (GameObject.FindWithTag("BuffManager")
            .TryGetComponent<BuffManager>(out BuffManager buffManager))
        {
            this.allBuffArchive = buffManager.DicToGenerate();
        }
        Generate();
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
            cardObj.GetComponent<PowerUp>()
                .GetRandomBuffCode((char)Random.Range(1, allBuffArchive.Count + 1));
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
