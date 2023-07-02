using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] attackObjectPrefab;

    private GameObject attackTarget;
    private List<GameObject> attackObjects = new List<GameObject>();
    private List<AttackFunc> objectsComponent = new List<AttackFunc>();
    //private List<AbstractAttack> attackObjList;

    private void Start()
    {
        FindPlayer();
    }

    protected void FindPlayer()
    {
       // 플레이어 찾는건 스태틱으로 처리해도 될듯 .수정
        try
        {
            if (GameObject.FindWithTag("Player").TryGetComponent<Player>(out Player player))
            {
                // 게임오브젝트 컴포넌트 자체를 가져오려고 생긴 문제였음.
                attackTarget = player.gameObject;
                Debug.Log(attackTarget + "공격 대상");
            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log("IsThere no player");
            throw e;
        }
    }


    Vector3 RandomPose()
    {
        return new Vector3(
        UnityEngine.Random.Range(17f, -17f),
        UnityEngine.Random.Range(0, 0),
        UnityEngine.Random.Range(1.2f, -20f));
    }

    public void Generate(AttackStatus status)
    {
        Debug.Log(((int)status.attackType).ToString());
        var obj = Instantiate(attackObjectPrefab[(int)status.attackType], RandomPose(),this.transform.rotation);
        attackObjects.Add(obj);

        var component = obj.GetComponent<AttackFunc>();

        Debug.Log(component.ToString());
        Debug.Log(attackTarget.ToString());
        component._Player = attackTarget;
        objectsComponent?.Add(component);

        //var _abstract = obj.GetComponent<AbstractAttack>();

        // 아무래도 여기서 초기 설정은 제어해줘야 할듯. Buffmanager -> CardGen -> AttackGen -> 생성
        //if (_abstract != null ) { _abstract.SetAttackStatus(); }
        //else 
    }

    public void IncreaseTargetStat(AttackStatus status, AttackCardInfo info)
    {
        //삭제해질 경우 해당 부분에서 에러가 발생할 여지가 있다. 수정
        foreach (var obj in objectsComponent) 
        {
            if (obj._AttackType == status.attackType) 
            {
                obj.GetComponent<AttackFunc>()?.CalcStat(status,info);
            }
            // 공격에 대한 정보 (적용부임)
            // 
            //obj.GetComponent<>();
        }
        //foreach (var attack in attackObjList) { attack.CalcAttackStatus()}
    }

    public void UseSkill(AttackStatus status, string skill)
    {
        foreach (var obj in objectsComponent)
        {
            if (obj._AttackType == status.attackType)
            {
                obj.GetComponent<AttackFunc>()?.Invoke(skill,0);
            }
            // 공격에 대한 정보 (적용부임)
            // 
            //obj.GetComponent<>();
        }
    }

}
