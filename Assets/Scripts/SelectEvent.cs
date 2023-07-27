using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEvent : Events<SelectEvent>
{
    public SelectEvent(SelectEvent selectEvent) : base()
    {
        instance = selectEvent;
    }
    protected override void Execute()
    {
    }
}
