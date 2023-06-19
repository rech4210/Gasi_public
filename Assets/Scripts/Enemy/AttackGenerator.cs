using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class AttackGenerator : MonoBehaviour
{
    public GameObject attackObject;

    private List<AbstractAttack> attackObjList;

    void AttackGenerate()
    {
        var obj = Instantiate(attackObject,Vector3.zero,Quaternion.identity);
        var _abstract = obj.GetComponent<AbstractAttack>();
        attackObjList.Add(_abstract);

        // 아무래도 여기서 초기 설정은 제어해줘야 할듯. Buffmanager -> CardGen -> AttackGen -> 생성
        //if (_abstract != null ) { _abstract.SetAttackStatus(); }
        //else 
    }

    private void IncreaseTargetStat()
    {
        //foreach (var attack in attackObjList) { attack.CalcAttackStatus()}
    }

}
