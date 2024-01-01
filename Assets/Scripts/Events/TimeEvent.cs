using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class TimeEvent : Events<TimeEvent>
{
    float time;

    List<ITimeEvent> perSecondTimeEventLists;
    List<ITimeEvent> perHMiniteTimeEventLists;
    Action<ITimeEvent> timeAction;

    Task timeWorkTask;

    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Time_1;
            OnExecute += Time_2;
        }
    }

    private void Start()
    {
        //timeWorkTask = Task.Run(() => { SendMessagePerSecond();});
        perSecondTimeEventLists = new List<ITimeEvent>();
    }

    public void StoreTimeEventObj(ITimeEvent @event)
    {
        perSecondTimeEventLists.Add(@event);
        foreach (var item in perSecondTimeEventLists)
        {
            Debug.Log(item);
        }
    }



    // 초당 부르면 부담이 크지않을까?
    // 대상의 범위를 제한하거나, 초단위 호출이 아닌 다른 이벤트 호출 조건을 사용하여야 할듯하다.
    // 대상이 가지는 ITimeEvent에 시간값을 넣어주고 이걸 딕서녀리나 셋으로 관리하면 어떨기?

    /*딕셔너리에 해당 함수가 발동되도록 딜레이 플롯값을 넣어두고 해당 내용이 완료될시 실행시키는 태스크를 만들고
     한 개채 (Bullet Turret 등등..)태스크를 관리할 자료구조를 만들면 어떨까? Task가 완료되면 로컬 bool 값이 변경되는 형식
     ex) Dic*/
    /*Dictionary<ITimeEvent, float> eventDict;
    ForEach -> task if(float > ItimeEventLocalFloat)
        => bool = true*/

    //Timer에서 시간 값 추출
    //TimeEvent에서는 게임 전체에서의 시간 관련 호출을 담당함.
    //TimeEvent에 호출될 이벤트들을 분류해두어야 함 (ex) 동시성, 호출 빈도)
    //ITimer을 구현받아 함수를 만들고 TimeEvent에서 분류된 개체들을 모두 호출함

    public void SendMessagePerSecond()
    {
        for (int i = 0; i < perSecondTimeEventLists.Count; i++)
        {
            //get now time in here
            perSecondTimeEventLists[i].TimeEvent(Time.time);
        } 
    }

    private void Time_1()
    {
        Debug.Log("Time_1");
        //Time.timeScale = 0;
    }
    private void Time_2()
    {
        Debug.Log("Time_2");
    }
    public void SaveTime(float time)
    {
        this.time = time;
    }
}
