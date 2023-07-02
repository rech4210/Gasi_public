/*필요한 데이터 정리
 * 카드
 * string type 
 * 배경, 아이콘, 버프이름, 설명, 묘사, 변화수치 텍스트
 * 
 * 스탯
 * primitive
 * 랭크, 포인트 값, 초기 값, 상승 값, 버프코드
 * 
 * 
 */
#region 버프 종류, 버프 데이터
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;


[Serializable]
public class Structure
{
    public BuffData[] buff;

    public Structure()
    {
        buff = new BuffData[100];
    }

}


[Serializable]
public enum BuffStatEnum
{
    health,
    speed,
    endurance,
    empty
}


[Serializable]
public class BuffData
{
    public char buffCode;
    public CardInfo cardInfo;
    public BuffStat stat;

    public void Print()
    {
        UnityEngine.Debug.Log($"code:{buffCode},{cardInfo.cardName},{stat.point}");
    }
    public BuffData(char buffCode, BuffStat stat, CardInfo cardInfo)
    {
        this.buffCode = buffCode;
        this.stat = stat;
        this.cardInfo = cardInfo;
    }
}
[Serializable]
public class CardInfo
{
    public BuffStatEnum buffType;
    public string cardName;
    public string bGImage;
    public string fRImage;
    public string information; // 공격이 ... 만큼... 한다. 변화된 수치도 표기
    public string description; //발이 느려진다.. ex
    public CardInfo(BuffStatEnum bufftype,string cardName, string bGImage, string fRImage, string information, string description)
    {
        this.buffType = bufftype;
        this.cardName = cardName;
        this.bGImage = bGImage;
        this.fRImage = fRImage;
        this.information = information;
        this.description = description;
    }
}

[Serializable]
// 여기에 버프 타입 넣어야하지 않을까?
public struct BuffStat
{
    public int rank;
    public int point;
    public int useValue;
    public int upValue;

    public BuffStat(int rank, int point, int useValue, int upValue)
    {
        this.rank = rank;
        this.point = point;
        this.useValue = useValue;
        this.upValue = upValue;
    }
}
#endregion

#region 공격 종류, 공격 데이터



[Serializable]
public class AttackStructure
{
    public AttackData[] attackDatas;

    // 배열 길이 수정할것
    public AttackStructure()
    {
        attackDatas = new AttackData[10];
    }
}

[Serializable]
public class AttackData
{
    public char attackCode;
    public AttackStatus attackStatus;
    public  AttackCardInfo attackInfo;

    public AttackData(char attackCode, AttackStatus status ,AttackCardInfo info)
    {
        this.attackCode = attackCode;
        attackStatus = status;
        attackInfo = info;
    }
}

[Serializable]
public enum AttackCardEnum
{
    generate,
    duration,
    scale,
    damage,
    skill_1 = 100,
    skill_2 = 101,
    skill_3 = 102
}

[Serializable]
public enum AttackType
{
    laser,
    guided,
    bullet,
    trap
}

[Serializable]
public struct AttackStatus
{
    public AttackType attackType;
    public int rank;
    public int point;
    public float duration;
    public float scale;

    public AttackStatus(AttackType attackType, int rank, int point, float duration, float scale)
    {
        this.attackType = attackType;
        this.rank = rank;
        this.point = point;
        this.duration = duration;
        this.scale = scale;
    }
}

[Serializable]
public class AttackCardInfo
{
    public AttackCardEnum attackCardEnum;
    public string attackName;
    public string bGImage;
    public string fRImage;
    public string information; // 공격이 ... 만큼... 한다. 변화된 수치도 표기
    public string description; //발이 느려진다.. ex
    public AttackCardInfo(AttackCardEnum attackCardEnum, string attackBuffName, string bGImage, string fRImage, string information, string description)
    {
        this.attackCardEnum = attackCardEnum;
        this.attackName = attackBuffName;
        this.bGImage = bGImage;
        this.fRImage = fRImage;
        this.information = information;
        this.description = description;
    }
}

#endregion

