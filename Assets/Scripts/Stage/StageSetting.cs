using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StageSetting : MonoBehaviour
{
    //각 스테이지에서 보스를 배치할시 초기값 설정해주기
    public abstract void StageOn();
    public abstract void StageOff();
}