using System.Collections.Generic;
using UnityEngine;
public class GenerateCard : MonoBehaviour
{
    public BuffManager buffManager;
    public GameObject cardPrefab; //- >대상을 다른 레퍼런스로
    BuffStorage buffStorage;
    int maxRange;

    private Dictionary<BuffStorage, Dictionary<StatusEffect, BuffStat>>
            dictFullBuff = new Dictionary<BuffStorage, Dictionary<StatusEffect, BuffStat>>();

    [SerializeField]
    private Dictionary<StatusEffect,BuffStat> 
        dictFullBuffStatus = new Dictionary<StatusEffect,BuffStat>();

    int buffStorageLength = System.Enum.GetValues(typeof(BuffStorage)).Length;

    private void Awake()
    {
        for (int i = 0; i < buffStorageLength; i++)
        {
            dictFullBuff.Add(buffStorage = (BuffStorage)i, dictFullBuffStatus); // 딕셔너리에 값 넣기
            // 이거 매니저로 빼야할까?
        }

        // 사전 제너레이트
    }
    private void Start()
    {
        Generate();
    }
    void Generate()
    {
        for (int i = 0; i < 5; i++)
        {
            buffStorage = (BuffStorage)Random.Range(0, buffStorageLength);
            var d = Instantiate(cardPrefab, buffManager.transform);

            if (buffManager.CheckBuff(buffStorage))
            {
            }
            else
            {
                var buffToTest = buffManager.ReturnBuff(buffStorage);
                d.AddComponent(buffToTest.GetType()); 
                // 인스턴스에 대한 레퍼런스 통합 어떻게 할건지?
            }
        }
    }
}
