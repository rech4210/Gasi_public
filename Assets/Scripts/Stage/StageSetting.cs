using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StageSetting : MonoBehaviour
{
    protected abstract void StageOn();
    protected abstract void StageOff();
}