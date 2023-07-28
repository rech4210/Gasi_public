using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    //use char type to buff code
    //기존 버프 enum 을 만들어서 해결하려 했으나, json 파일에 넣으면 필요없다고 판단
    //그러므로  char 타입으로 256까지 카드 버프종류를 구분할 수 있도록 타입을 만들기
    private Dictionary<char, BuffStat> allBuffStatArchive = new();
    private Dictionary<char, CardInfo> allCardInfoArchive = new();

    private Dictionary<char, BuffStat> containBuffDictionary = new();


    private Dictionary<char, AttackStatus> allAttackStatArchive = new();
    private Dictionary<char, AttackCardInfo> allAttackCardInfoArchive = new();

    private Dictionary<char, AttackStatus> containAttackStatDictionary = new();



    string path = null;

    int buffCounts = 100;

    //BuffData buffData; //초기화용 버프

    private void Awake()
    {
        //?_?
        allBuffStatArchive.Clear();
        allCardInfoArchive.Clear();
        allAttackStatArchive.Clear();
        allAttackCardInfoArchive.Clear();
        containBuffDictionary.Clear();
        containAttackStatDictionary.Clear();

        //SaveBuffJson();
        //SaveAttackJson();

        //트라이 캐치 구문이 존나 어색한데?
        //try
        //{
        //    SaveBuffJson();
        //}

        //catch (System.Exception e)
        //{
        //    Debug.Log(e + "Path is not defined");
        //    throw e;
        //}

        JsonParsing();
        JsonAttackParsing();
    }

    private void Start()
    {
    }
    private void Update()
    {

    }

    /*
     * 1. BuffEnumStorage , buffstat 등을 모두 제이슨 파일로 저장
     * 2. 카드들의 원형을 클래스로 관리하지 말것, 중복되는 부분은 인터페이스만 유지
     * 3. temp 함수 부분에서 json 파싱하는 부분을 만들어줘야할듯.
     */

    [JsonConverter(typeof(StringEnumConverter))]
    public BuffStatEnum statEnum { get; set; }

    #region 제이슨 파싱
    public void SaveBuffJson()
    {
        path = Path.Combine(Application.dataPath + "/Json/", "BuffData.json");
        //string jsonData = null;

        File.WriteAllText(path, "");

        Structure buffdata = new Structure();

        for (int i = 0; i < buffCounts; i++)
        {
            BuffData buff = new BuffData((char)i, new BuffStat(1, 1, 1, 1), new CardInfo(statEnum = BuffStatEnum.empty, "1", "1", "1", "1", "1"));

            buffdata.buff[i] = buff;
        }
        string jsonData = JsonUtility.ToJson(buffdata, true);
        File.WriteAllText(path, jsonData);
    }
    //어떻게 처리?
    [JsonConverter(typeof(StringEnumConverter))]
    public AttackType attackType { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public AttackCardEnum attackEnum { get; set; }
    public void SaveAttackJson()
    {
        path = Path.Combine(Application.dataPath + "/Json/", "AttackData.json") ?? null;
        //string jsonData = null;
        if (path == null) return;

        File.WriteAllText(path, "");

        AttackStructure structure = new AttackStructure();

        for (int i = 0; i < 10; i++)
        {
            AttackData attackData = new AttackData((char)i,new AttackStatus(attackType, 1,1,1,1,1),new AttackCardInfo(attackEnum, "1", "1", "1", "1", "1"));

            structure.attackDatas[i] = attackData;

        }
        string jsonData = JsonUtility.ToJson(structure, true);
        File.WriteAllText(path, jsonData);
    }


    public void JsonParsing()
    {
 
        path = Path.Combine(Application.dataPath + "/Json/", "BuffData.json");

        string jsonData = File.ReadAllText(path);
        Debug.Log(jsonData);

        Structure _buffData = JsonUtility.FromJson<Structure>(jsonData);

        for (int i = 0; i < buffCounts; i++)
        {
            allBuffStatArchive.Add(_buffData.buff[i].buffCode, _buffData.buff[i].stat);
            allCardInfoArchive.Add(_buffData.buff[i].buffCode, _buffData.buff[i].cardInfo);

            //Debug.Log(allBuffStatArchive[_buffData.buff[i].buffCode].point);
            //Debug.Log(allCardInfoArchive[_buffData.buff[i].buffCode].cardName);

        }
    }

    public void JsonAttackParsing()
    {

        path = Path.Combine(Application.dataPath + "/Json/", "AttackData.json");

        string jsonData = File.ReadAllText(path);
        Debug.Log(jsonData);

        AttackStructure _attackStruct = JsonUtility.FromJson<AttackStructure>(jsonData);


        for (int i = 0; i < 10; i++)
        {
            allAttackStatArchive.Add(_attackStruct.attackDatas[i].attackCode, _attackStruct.attackDatas[i].attackStatus);
            allAttackCardInfoArchive.Add(_attackStruct.attackDatas[i].attackCode, _attackStruct.attackDatas[i].attackInfo);

            //Debug.Log(allAttackStatArchive[_attackStruct.attackDatas[i].attackCode].point);
            //Debug.Log(allAttackCardInfoArchive[_attackStruct.attackDatas[i].attackCode].attackName);

        }
    }

    #endregion

    //중앙 허브에서 버프 추가 관리 및 연산까지 수행한 후 뿌려주는게 맞을까?
    // 아니라면 연산 수행은 카드 단에서 진행하는게 맞을까?
    // 우선 뿌려주는 형식이라면 연산을 버프매니저에서 진행한다.
    // 그리고 중복되는 판단을 point 값이 0인지 아닌지로 판단하는걸로 하자.

    // 그건 그렇다쳐도 플레이어한테 들어갈 스탯은 어떻게 구분할건데?
    // 스탯만해도 아주 다양하게 나뉘는데. 버프 코드로 처리할거임? 아니면 .

    // 결론, 버프 매니저에서 데이터를 연산하도록 하자,
    // search BuffContainer -> Generate card -> Click buff -> Calc buffCode in BM
    // broad cast to player, enemy
    public void AddorUpdateDictionary(char buffCode)
    {
        if (containBuffDictionary.ContainsKey(buffCode))
        {
            //method which use for player through out buffstat with buffcode
            containBuffDictionary[buffCode] = BuffUp(containBuffDictionary[buffCode]);
            Debug.Log($"이미 존재합니다 버프 랭크 증가");
        }
        else
        {
            containBuffDictionary.Add(buffCode, allBuffStatArchive[buffCode]); //각각에 인스턴스로 존재해버림, 이 데이터 값들을 버프매니저에서 통합으로 관리해야함.
            Debug.Log("없는 버프 추가 : " + allCardInfoArchive[buffCode].cardName + " " + "현재 버프 갯수:"+ containBuffDictionary.Count);
        }
        Debug.Log($"대상 버프 : {allCardInfoArchive[buffCode].cardName}, " +
            $"스탯 상승 : {containBuffDictionary[buffCode].point}, " +
            $"랭크 : {containBuffDictionary[buffCode].rank}");
    }
    public void AddorUpdateAttackDictionary(char attackCode,AttackStatus attackStatus)
    {
        //과연 생성과 강화는 따로있는데 어떻게 딕셔너리 구분지어서 설정할건지?
        if (containAttackStatDictionary.ContainsKey(attackCode))
        {
            //method which use for player through out buffstat with buffcode
            containAttackStatDictionary[attackCode] = attackStatus;
            Debug.Log($"랭크 증가");
        }
        else 
        {
            containAttackStatDictionary.Add(attackCode, allAttackStatArchive[attackCode]); //각각에 인스턴스로 존재해버림, 이 데이터 값들을 버프매니저에서 통합으로 관리해야함.
            Debug.Log("없는 공격 추가 : " + allAttackCardInfoArchive[attackCode].attackName + " " + "현재 버프 갯수:" + containAttackStatDictionary.Count);
        }
        Debug.Log($"대상 공격 : {allAttackCardInfoArchive[attackCode].attackName}, " +
            $"스탯 상승 : {containAttackStatDictionary[attackCode].point}, " +
            $"랭크 : {containAttackStatDictionary[attackCode].rank}");
    }

    // 플레이어 적용부 구현하기

    private BuffStat BuffUp(BuffStat buffStat)
    {
        buffStat.rank++;
        buffStat.point += buffStat.upValue;
        return buffStat;
    }

    //public BuffStat BuffUse(BuffStat buffStat)
    //{
    //    buffStat.rank = 0;
    //    buffStat.point += buffStat.useValue;
    //    return buffStat;
    //}

    // 굳이 버프를 동적으로 생성해줘야 함? 미리 밖으로 꺼내두고 bool이나 setactive로 buffdata 탐색해서 처리해주면 되는거 아님?
    public void RemoveSomthing(char buffCode) 
    {
        if (containBuffDictionary.ContainsKey(buffCode))
        {
            containBuffDictionary.Remove(buffCode);
        }
    }

    public BuffStat ReturnBuff(char buffCode)
    {
        return containBuffDictionary[buffCode];
    }



    public Dictionary<char, BuffStat> StatToGenerate()
    {
        return allBuffStatArchive;
    }

    public Dictionary<char,CardInfo> InfoToGenerate()
    {
        return allCardInfoArchive;
    }

    public Dictionary<char, AttackStatus> AttackStatToGenerate()
    {
        return allAttackStatArchive;
    }

    public Dictionary<char, AttackCardInfo> AttackInfoToGenerate()
    {
        return allAttackCardInfoArchive;
    }
    public Dictionary<char, BuffStat> ContainStatToGenerate()
    {
        return containBuffDictionary;
    }

    public Dictionary<char, AttackStatus> ContainAttackStatToGenerate()
    {
        return containAttackStatDictionary;
    }

}


// This method use for Initialize of Buffdata
//public BuffData SetBuffData(char buffCode, BuffStat data) 
//{
//    // 이미 존재하는경우 다시 카드에 부착되면 init이 발동될거임 해당 문제 처리
//    if (!containBuffDictionary.ContainsKey(buffCode))
//    {
//        if (allBuffArchive.TryGetValue(buffCode, out BuffStat archiveData))
//        {
//            //archiveData.StatusEffect = data.StatusEffect;
//            //buffData = archiveData;
//            buffData = new BuffData(buffCode, archiveData);
//        }
//    }
//    else
//    {
//        Debug.Log("이미 현재 컨테이너에 등록된 버프입니다");
//        //buffData = data;
//    }
//    return buffData;
//}