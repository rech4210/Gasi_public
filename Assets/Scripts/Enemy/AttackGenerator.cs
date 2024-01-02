using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackGenerator : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] attackObjectPrefab;

    private Dictionary<int, AttackData> allAttackStatArchive = new();
    private Dictionary<int, AttackStatus> containAttackDict = new();

    private GameObject attackTarget;
    private List<GameObject> attackObjects = new List<GameObject>();
    private List<AttackFunc> objectsComponent = new List<AttackFunc>();
    //private List<AbstractAttack> attackObjList;

    public void AddorUpdateAttackDictionary(int attackCode)
    {
        //과연 생성과 강화는 따로있는데 어떻게 딕셔너리 구분지어서 설정할건지?
        if (containAttackDict.ContainsKey(attackCode))
        {
            //method which use for player through out buffstat with buffcode
            containAttackDict[attackCode] = allAttackStatArchive[attackCode].attackStatus;
            //Debug.Log($"랭크 증가");
        }
        else
        {
            //Debug.Log(allAttackStatArchive[attackCode].attackStatus);
            containAttackDict.Add(attackCode, allAttackStatArchive[attackCode].attackStatus); //각각에 인스턴스로 존재해버림, 이 데이터 값들을 버프매니저에서 통합으로 관리해야함.
            //Debug.Log("없는 공격 추가 : " + allAttackStatArchive[attackCode].attackInfo.attackName + " " + "현재 버프 갯수:" + containAttackDict.Count);
        }
        //Debug.Log($"대상 공격 : {allAttackStatArchive[attackCode].attackInfo.attackName}, " +
        //    $"스탯 상승 : {containAttackDict[attackCode].point}, " +
        //    $"랭크 : {containAttackDict[attackCode].rank}");
    }
    public Dictionary<int, AttackStatus> ContainAttackStatToGenerate()
    {
        return containAttackDict;
    }


    private void Start()
    {
        allAttackStatArchive = DataManager.Instance.ReturnDict(allAttackStatArchive);
        FindPlayer();
    }

    protected void FindPlayer() //이부분을 수정해야함 (플레이어 찾기를 실시간으로)
    {
       // 플레이어 찾는건 스태틱으로 처리해도 될듯 .수정
        try
        {
            attackTarget = DataManager.Instance._playerTransform.gameObject;
            //if (GameObject.FindWithTag("Player").TryGetComponent<Player>(out Player player))
            //{
            //    // 게임오브젝트 컴포넌트 자체를 가져오려고 생긴 문제였음.
            //    attackTarget = player.gameObject;
            //    Debug.Log(attackTarget + "공격 대상");
            //}
        }
        catch (NullReferenceException e)
        {
            Debug.Log("IsThere no player");
            throw e;
        }
    }


    Vector3 RandomPose() => new Vector3(1, 1, 1);
    //{
    //    return new Vector3(
    //    UnityEngine.Random.Range(23f, -23f),
    //    UnityEngine.Random.Range(0, 0),
    //    UnityEngine.Random.Range(4f, -23f));
    //}

    public void Generate(AttackStatus status)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+5f, transform.localPosition.z); 

        //Debug.Log((status.attackType).ToString());
        var obj = Instantiate(attackObjectPrefab[(int)status.attackType], RandomPose(),this.transform.rotation,StageManager.Instance.GetCurrentStagePos());
        attackObjects.Add(obj);

        var component = obj.GetComponent<AttackFunc>();
        //var Itimeobj = component.GetComponent<ITimeEvent>();
        //component.GetComponent<ITimeEvent>(() => { TimeEvent.Instance.StoreTimeEventObj(component); });
        TimeEvent.Instance.StoreTimeEventObj(obj);
        // 윗 부분에서 generate시 자동으로 옵저버에 등록되도록 설정

        //Debug.Log(component.ToString());
        //Debug.Log(attackTarget.ToString());

        //직관적이지 않다
        component._Player = attackTarget;
        component._AttackStatus = status;
        //attackFunc에 카드 공격능력치와 추적 대상을 부여해줌.
        //후에, AttackFunc를 상속받는 대상들에게 전달
        //공격 개체들이 데이터를 받으면 파생된 탄막들에게 공격수치를 입력해줌.

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
