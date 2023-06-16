using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
public class BuffManager : MonoBehaviour
{
    //use char type to buff code
    //기존 버프 enum 을 만들어서 해결하려 했으나, json 파일에 넣으면 필요없다고 판단
    //그러므로  char 타입으로 256까지 카드 버프종류를 구분할 수 있도록 타입을 만들기
    private Dictionary<char, BuffStat> allBuffStatArchive = new();
    private Dictionary<char, CardInfo> allCardInfoArchive = new();

    private Dictionary<char, BuffStat> containBuffDictionary = new();

    string path = null;

    int buffCounts = 100;

    //BuffData buffData; //초기화용 버프

    private void Awake()
    {
        //?_?
        allBuffStatArchive.Clear();
        allCardInfoArchive.Clear();

        containBuffDictionary.Clear();
        temp();


    }

    private void Start()
    {
        try
        {
            SaveJson();
        }

        catch (System.Exception e)
        {
            Debug.Log(e + "Path is not defined");
            throw e;
        }

        JsonParsing();

    }

    /*
     * 1. BuffEnumStorage , buffstat 등을 모두 제이슨 파일로 저장
     * 2. 카드들의 원형을 클래스로 관리하지 말것, 중복되는 부분은 인터페이스만 유지
     * 3. temp 함수 부분에서 json 파싱하는 부분을 만들어줘야할듯.
     */


    public void SaveJson()
    {
        path = Path.Combine(Application.dataPath + "/Json/", "BuffData.json");
        //string jsonData = null;

        File.WriteAllText(path, "");
        for (int i = 1; i < buffCounts; i++)
        {
            BuffData buffData = new BuffData((char)i, new BuffStat(1, 1, 1, 1), new CardInfo("1", "1", "1", "1", "1"));
            string jsonData = JsonUtility.ToJson(buffData,true);
            File.AppendAllText(path, jsonData);
            File.AppendAllText(path, "\n");
        }

    }

    public void JsonParsing()
    {
        path = Path.Combine(Application.dataPath + "/Json/", "BuffData.json");

        string jsonData = File.ReadAllText(path);
        Debug.Log(jsonData);

        var _buffData = JsonConvert.DeserializeObject<BuffData>(jsonData);
        //BuffData _buffData =JsonUtility.FromJson<BuffData>(jsonData);
        _buffData.Print();
        for (int i = 0; i < buffCounts; i++)
        {
            allBuffStatArchive.Add(_buffData.buffCode, _buffData.stat);
            allCardInfoArchive.Add(_buffData.buffCode, _buffData.cardInfo);

            Debug.Log(allBuffStatArchive[_buffData.buffCode]);
            Debug.Log(allCardInfoArchive[_buffData.buffCode]);

        }
    }
    public void temp()
    {
        // 여기 부분을 json 타입으로 파싱해서 가져와야함.
        allBuffStatArchive.Add((char)1,new BuffStat(1, 5, 7, 10));
        allBuffStatArchive.Add((char)2, new BuffStat(1, 5, 22, 100));

        allCardInfoArchive.Add((char)1, new CardInfo("name","bg","fr","informaton","description"));
        allCardInfoArchive.Add((char)2, new CardInfo("name", "bg", "fr", "informaton", "description"));

        foreach (var item in allBuffStatArchive.Keys)
        {
            Debug.Log("키 등록: " + allCardInfoArchive[item].BuffEnumName);
        }
    }

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
            Debug.Log($"이미 존재합니다 랭크 증가");
        }
        else
        {
            containBuffDictionary.Add(buffCode, allBuffStatArchive[buffCode]); //각각에 인스턴스로 존재해버림, 이 데이터 값들을 버프매니저에서 통합으로 관리해야함.
            Debug.Log("없는 버프 추가 : " + allCardInfoArchive[buffCode].BuffEnumName + " " + "현재 버프 갯수:"+ containBuffDictionary.Count);
        }
        Debug.Log($"대상 버프 : {allCardInfoArchive[buffCode].BuffEnumName}, " +
            $"스탯 상승 : {containBuffDictionary[buffCode].point}, " +
            $"랭크 : {containBuffDictionary[buffCode].rank}");
    }
    // 플레이어 적용부 구현하기

    public BuffStat BuffUp(BuffStat buffStat)
    {
        buffStat.rank++;
        buffStat.point += buffStat.upValue;
        return buffStat;
    }

    public BuffStat BuffUse(BuffStat buffStat)
    {
        buffStat.rank = 0;
        buffStat.point += buffStat.useValue;
        return buffStat;
    }

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