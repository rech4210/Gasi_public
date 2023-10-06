using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1 : StageSetting
{
    private void OnEnable()
    {
        StageOn();
    }
    protected override void StageOn()
    {
        Debug.Log("stage1 open");
    }

    protected override void StageOff()
    {
        Debug.Log("stage off");
        //Destroy(player);
        //StageManager.Instance.SwichStage();
    }

    private void OnDisable()
    {
        StageOff();
    }
}
