using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    Ray ray;
    ArrayList buffers = new ArrayList();
    RaycastHit hit;

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
                    hit.collider.GetComponent<Buff>().OnChecked();
                }
                catch (System.Exception e)
                {
                    Debug.Log("´ë»ó ¾Æ´Ô") ;
                }
            }
        }
    }
    void Start()
    {
    }

    public void GetBuff(Buff buff)
    {
        if (buffers?.Count> 0)
        {
            for (int i = 0; i < buffers.Count; i++)
            {
                if (buffers[i].GetType() == buff.GetType())
                {
                    Debug.Log(buffers[i]);
                    buff.BuffUp();
                    break;
                }
                else if (i >= buffers.Count -1)
                {
                    buffers.Add(buff);
                    buff.BuffUse();
                }
            }
        }
        else { buffers.Add(buff); buff.BuffUse();}
    }
}

