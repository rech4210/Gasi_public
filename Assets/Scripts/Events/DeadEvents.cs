using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadEvents : Events<DeadEvents>
{
    protected override void Execute()
    {
        if (OnExecute?.Method == null)
        {
            OnExecute += Dead_1;
            OnExecute += Dead_2;
        }
    }


    private void Dead_1()
    {
        Debug.Log("Dead_1");
        TimeEvent.Instance.ExecuteEvent();
    }
    private void Dead_2()
    {
        Debug.Log("Dead_2");
        //StageManager.Instance.SwichStage(); //이부분 스테이지 변경하기
        SceneManager.LoadScene(0);
    }
}
