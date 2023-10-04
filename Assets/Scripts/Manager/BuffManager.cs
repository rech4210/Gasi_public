using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{

    private Dictionary<int, BuffData> allBuffStatArchive = new();
    private Dictionary<int, BuffStat> containBuffDict = new();

    Player player = null;

    private void Start()
    {
        allBuffStatArchive = DataManager.Instance.ReturnDict(allBuffStatArchive);
    }

    public void AddorUpdateDictionary(int buffCode)
    {
        if (containBuffDict.ContainsKey(buffCode))
        {
            containBuffDict[buffCode] = BuffCase(buffCode);
            //CalcBuff
            Debug.Log($"이미 존재합니다 버프 랭크 증가");
        }
        else
        {
            //초기 값을 설정해주어 BuffCase를 거쳐 플레이어 데이터 계산할건지? 추가해야함.
            containBuffDict.Add(buffCode, allBuffStatArchive[buffCode].stat); //각각에 인스턴스로 존재해버림, 이 데이터 값들을 버프매니저에서 통합으로 관리해야함.
            Debug.Log("없는 버프 추가 : " + allBuffStatArchive[buffCode].cardInfo.cardName + " " + "현재 버프 갯수:"+ containBuffDict.Count);
        }
        Debug.Log($"대상 버프 : {allBuffStatArchive[buffCode].cardInfo.cardName}, " +
            $"스탯 상승 : {containBuffDict[buffCode].point}, " +
            $"랭크 : {containBuffDict[buffCode].rank}");

        //this content must be need switch case
    }
    
    private BuffStat BuffCase(int buffCode)
    {
        BuffStat stat = containBuffDict[buffCode];
        PlayerStatStruct playerStatStruct = DataManager.Instance._playerStat;

        playerStatStruct.SetArrayFromValue(8); // 여기를 변수로 교체하기
        // empty의 경우 체크해주기
        if (allBuffStatArchive[buffCode].cardInfo.buffType != BuffStatEnum.empty)
        {
            playerStatStruct.array[(int)allBuffStatArchive[buffCode].cardInfo.buffType] += CalcBuff(ref stat, buffCode);
            playerStatStruct.SetValueFromArray();
        }
        else
        {
            //Do empty work
        }
        DataManager.Instance.PlayerStatDele(playerStatStruct);
        return stat;
    }
    private int CalcBuff(ref BuffStat stat, int buffCode)
    {
        //Use와 Up을 혼동하진 않았는지..?
        stat.rank++;
        stat.point += allBuffStatArchive[buffCode].stat.upValue;
        return stat.point;
    }

    public void RemoveSomthing(int buffCode) 
    {
        if (containBuffDict.ContainsKey(buffCode))
        {
            containBuffDict.Remove(buffCode);
        }
    }

    public BuffStat ReturnBuff(int buffCode)
    {
        return containBuffDict[buffCode];
    }

    // 이 부분 프로퍼티로 수정
    public Dictionary<int, BuffStat> ContainStatToGenerate()
    {
        return containBuffDict;
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


//public Dictionary<char, BuffStat> StatToGenerate()
//{
//    return allBuffStatArchive;
//}

//public Dictionary<char,CardInfo> InfoToGenerate()
//{
//    return allCardInfoArchive;
//}

//public Dictionary<char, AttackStatus> AttackStatToGenerate()
//{
//    return allAttackStatArchive;
//}

//public Dictionary<char, AttackCardInfo> AttackInfoToGenerate()
//{
//    return allAttackCardInfoArchive;
//}


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