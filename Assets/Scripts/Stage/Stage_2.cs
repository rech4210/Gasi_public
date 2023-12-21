using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2 : StageSetting
{
    private void OnEnable()
    {
        StageOn();
    }
    public override void StageOn()
    {
        //Instantiate(player, gameObject.transform);
        Debug.Log("now is stage2");
    }

    public override void StageOff()
    {
        //Destroy(player);
        //StageManager.Instance.SwichStage();
    }

    private void OnDisable()
    {
        StageOff();
    }
}
