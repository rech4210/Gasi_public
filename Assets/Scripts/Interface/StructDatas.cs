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

using System;
using System.Collections.Generic;
using UnityEngine;

#region 플레이어 데이터
// 이부분 그냥 클래스로 바꿔버릴까??
public struct PlayerStatStruct
{
    public float[] array;

    public float health;
    public float will;
    public float luck;
    public float agility;
    public float wisdom;
    public float faith;

    public float speed;
    public float defence;
    public float indurance;


    public void PrintPlayerStat()
    {
        Debug.Log($"PlayerStat: health = {health} will = {will} luck = {luck} agility = {agility} wisdom = {wisdom} faith = {faith} ");
    }
    public PlayerStatStruct(float health, float will, float luck, float agility, float wisdom, float faith, float speed, float defence, float indurance)
    {
        array = new float[50];
        this.health = health;
        this.will = will;
        this.luck = luck;
        this.agility = agility;
        this.wisdom = wisdom;
        this.faith = faith;

        this.speed = speed;
        this.defence = defence;
        this.indurance = indurance;

        this.damage = 0;
        this.avoidness = 0;
        this.blockness = 0;
    }

    public void SetArrayFromValue(int count)
    {
        if(array == null)
        {
            array = new float[count];
        }
        array[0] = health;
        array[1] = will; 
        array[2] = luck; 
        array[3] = agility;
        array[4] = wisdom;
        array[5] = faith; 
        array[6] = speed; 
        array[7] = defence;
        array[8] = indurance;
    }
    public void SetValueFromArray()
    {
        health = array[0];
        will = array[1];
        luck = array[2];
        agility = array[3];
        wisdom = array[4];
        faith = array[5];
        speed = array[6];
        defence = array[7];
        indurance = array[8];
    }

    // when it activated
    public float damage;
    public float avoidness;
    public float blockness;
}

#endregion

#region 버프 종류, 버프 데이터
[Serializable]
public class BuffStructure : IDataLoader<int, BuffData>
{
    public BuffData[] buffDatas;

    public BuffStructure()
    {
        buffDatas = new BuffData[100];
    }

    public Dictionary<int, BuffData> MakeDict()
    {
        Dictionary<int, BuffData> dict = new();

        foreach (var item in buffDatas)
        {
            if(item != null)
            {
                dict.Add(item.buffCode, item);
            }
        }
        return dict;

    }
    public void Print()
    {
    }
}




[Serializable]
public enum BuffStatEnum
{
    health,
    will,
    luck,
    agility,
    wisdom,
    faith,
    speed,
    defence,
    indurance,
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
public class AttackStructure : IDataLoader<int, AttackData>
{
    public AttackData[] attackDatas;

    // 배열 길이 수정할것
    public AttackStructure()
    {
        attackDatas = new AttackData[10];
    }


    public Dictionary<int, AttackData> MakeDict()
    {
        Dictionary<int, AttackData> dict = new();
        foreach (var item in attackDatas)
        {
            if (item != null)
            {
                dict.Add(item.attackCode, item);
            }
        }
        return dict;
    }
}

[Serializable]
public class AttackData
{
    public char attackCode;
    public AttackStatus attackStatus;
    public  AttackCardInfo attackInfo;

    public void Print()
    {
        UnityEngine.Debug.Log($"code:{attackCode},{attackInfo.attackName},{attackStatus.point}");
    }
    public AttackData(char attackCode, AttackStatus status, AttackCardInfo info)
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
    point,
    speed, // 최근에 추가된것, 수정할것 Json 파일
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
    public float speed;

    public AttackStatus(AttackType attackType, int rank, int point, float duration, float scale, float speed)
    {
        this.attackType = attackType;
        this.rank = rank;
        this.point = point;
        this.duration = duration;
        this.scale = scale;
        this.speed = speed;
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

