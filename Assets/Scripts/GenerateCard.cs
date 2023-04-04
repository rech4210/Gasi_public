using System.Collections.Generic;
using UnityEngine;
public class GenerateCard : MonoBehaviour
{
    public BuffManager buffManager;
    public GameObject cardPrefab; //- >대상을 다른 레퍼런스로
    BuffEnumStorage buffStorage;

    int buffStorageLength = System.Enum.GetValues(typeof(BuffEnumStorage)).Length;

    private void Start()
    {
        Generate();
    }
    void Generate() // -> 여기에 특수, 악마, 천사, 일반카드 재사용하도록 짜기
    {
        //for (int i = 0; i < 3; i++)
        //{
        //    buffStorage = (BuffEnumStorage)Random.Range(0, buffStorageLength);
        //    var d = Instantiate(cardPrefab, buffManager.transform);

        //    var asd = buffManager.ReturnBuff(buffStorage);

        //}
    }
}
