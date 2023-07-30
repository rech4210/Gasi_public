using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEvent : Events<SelectEvent>
{
    public SelectEvent() : base() 
    {
    }

    //public override SelectEvent ChangeInstance(SelectEvent @event)
    //{
    //    return instance = @event;
    //}

    protected override void Execute()
    {
        throw new System.NotImplementedException();
    }


}
