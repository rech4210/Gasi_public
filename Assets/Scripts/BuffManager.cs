using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;



public class BuffManager : MonoBehaviour
{
    private Dictionary<BuffEnumStorage, BuffData> allBuffArchive = new();

    private Dictionary<BuffEnumStorage, BuffData> containBuffDictionary = new();

    Ray ray;
    RaycastHit hit;

    BuffData buffData; //초기화용 버프

    private void Awake()
    {
        containBuffDictionary.Clear();
        temp();
    }
    public BuffData SetBuffData(BuffEnumStorage type, BuffData data) 
    {
        // 이미 존재하는경우 다시 카드에 부착되면 init이 발동될거임 해당 문제 처리
        if (!containBuffDictionary.ContainsKey(type))
        {
            if (allBuffArchive.TryGetValue(type, out BuffData archiveData))
            {
                archiveData.StatusEffect = data.StatusEffect;
                buffData = archiveData;
            }
        }
        else
        {
            Debug.Log("이미 아카이브에 등록된 버프입니다");
            buffData = data;
        }
        return buffData;
    }
    public void temp()
    {
        allBuffArchive.Add(BuffEnumStorage.Power, new BuffData(null, new BuffStat(1, 5, 7, 10)));
        allBuffArchive.Add(BuffEnumStorage.Health, new BuffData(null, new BuffStat(1, 5, 22, 100)));

        foreach (var item in allBuffArchive.Keys)
        {
            Debug.Log("키 등록: "+item);
        }
        //편하게 할 방법.
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position,ray.direction * 20f,Color.red);
            if (Physics.Raycast(ray, out hit,50f))
            {
                try
                {
                    hit.collider.GetComponent<StatusEffect>().OnChecked();

                }
                catch (System.Exception e)
                {
                    Debug.Log(e);
                }

            }
        }
    }

    public void AddorUpdateDictionary(BuffEnumStorage buffType, BuffData data)
    {
        if (containBuffDictionary.ContainsKey(buffType))
        {
            containBuffDictionary[buffType] = data.StatusEffect.BuffUp();
            Debug.Log($"이미 존재합니다 랭크 증가");
        }
        else
        {
            data.StatusEffect.BuffUse();
            containBuffDictionary.Add(buffType,data); //각각에 인스턴스로 존재해버림, 이 데이터 값들을 버프매니저에서 통합으로 관리해야함.
            Debug.Log("없는 버프 추가 : " + allBuffArchive[buffType].StatusEffect + " " + "버프 갯수:"+ allBuffArchive.Count);
        }
        Debug.Log($"대상 버프 : {buffType}, " +
            $"스탯 상승 : {containBuffDictionary[buffType].stat.point}, " +
            $"랭크 : {containBuffDictionary[buffType].stat.rank}");
    }


    // 굳이 버프를 동적으로 생성해줘야 함? 미리 밖으로 꺼내두고 bool이나 setactive로 buffdata 탐색해서 처리해주면 되는거 아님?
    public void RemoveSomthing(BuffEnumStorage buffType) 
    {
        if (containBuffDictionary.ContainsKey(buffType))
        {
            containBuffDictionary.Remove(buffType);
        }
    }

    public BuffData ReturnBuff(BuffEnumStorage buffType)
    {
        return containBuffDictionary[buffType];
    }
    public StatusEffect CheckBuff(BuffEnumStorage buffType) /// 이거 삭제해도 될듯
    {
        return containBuffDictionary[buffType].StatusEffect;
    }
}

