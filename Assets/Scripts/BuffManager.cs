using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class BuffManager : MonoBehaviour
{
    private Dictionary<BuffStorage, BuffData> 
        dictBuff = new Dictionary<BuffStorage, BuffData>();

    private Dictionary<StatusEffect, BuffStat> 
        buffValuePairs = new Dictionary<StatusEffect, BuffStat>();

    // -> 여기에서 전체 버프에 대한 초기화를 시켜주고 해당 버프가 카드에 등장하면
    //    전체를 순환하면서 맞는 데이터값을 전달해줌.
    Ray ray;
    RaycastHit hit;

    BuffData buffData;

    private void Awake()
    {
        dictBuff.Clear();

        
    }

    /* 1. 버프를 누른다.
     * 2. AddDictionary를 통해 해당 버프가 존재하는지 판단.
     * 3. 만약 존재한다면 SetBuffData를 통해 저장하고 값을 최신화 시켜준다 (BuffManager가 관리).
     *      3-1. 아니라면 버프 리스트 전체를 순회하면서 Type과 비교하여 값을 넣어준다.
     * 4. 최신화 된 값을 가져와 각 버프가 가진 BuffData에 대입한다.
     */
    public BuffData SetBuffData(StatusEffect statusEffect)
    {
        // 이미 가진 데이터들과 비교하여 처리할것.
        
        if (buffValuePairs.TryGetValue(statusEffect,out BuffStat value))
        {
            buffData = new BuffData(statusEffect, value);

        }
        return buffData;
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
                catch (System.NullReferenceException e)
                {
                    Debug.Log("대상 아님") ;
                }
            }
        }
    }

    public void AddorUpdateDictionary(BuffStorage buffType, BuffData buffValues)
    {
        if (dictBuff.ContainsKey(buffType))
        {
            Debug.Log("이미 존재합니다 랭크 증가");
            buffValues.StatusEffect.BuffUp();
            // 여기 딕셔너리 최신화
        }
        else
        {
            dictBuff.Add(buffType, buffValues);
            buffValues.StatusEffect.BuffUse();
            
            Debug.Log("없는 버프 추가 : " + dictBuff.Keys + " " + "버프 갯수:"+ dictBuff.Count);
        }
    }

    public void RemoveSomthing(BuffStorage buffType)
    {
        if (dictBuff.ContainsKey(buffType))
        {
            dictBuff.Remove(buffType);
        }
    }

    public StatusEffect ReturnBuff(BuffStorage buffType)
    {
        return dictBuff[buffType].StatusEffect;
    }
    public StatusEffect CheckBuff(BuffStorage buffType)
    {
        return dictBuff[buffType].StatusEffect;
    }
    
}

