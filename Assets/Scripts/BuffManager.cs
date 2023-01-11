using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    //public delegate void BuffTrigger(Buff);

    List<Buff> myBuffList = new List<Buff>();

    Ray ray;

    RaycastHit hit;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.main.transform.position,ray.direction * 20f,Color.red);

            if (Physics.Raycast(ray, out hit,50f))
            {
                hit.collider.GetComponent<Buff>().OnChecked();
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    private void Awake()
    {
    }
    void Start()
    {
        myBuffList.Clear();
    }

    public void GetBuff(Buff buff)
    {
        if (myBuffList.Contains(buff)) // 이부분 각각 적용임..
        {
            buff.BuffUp();
        }
        else
        {
            myBuffList.Add(buff);
            buff.BuffUse();
            for (int i = 0; i < myBuffList.Count; i++)
            {
                Debug.Log(myBuffList[i]);
            }
        }
        for (int i = 0; i < myBuffList.Count; i++)
        {
            Debug.Log(myBuffList[i].ToString());
        }
    }

}
