using UnityEngine;

public class StageManager : Manager<StageManager>
{
    private int currentStageNum;
    private GameObject currentStage;
    [SerializeField] GameObject[] stagesArray = new GameObject[10];

    private void Awake()
    {
        currentStageNum = 0;
        currentStage = Instantiate(stagesArray[currentStageNum]);
    }

    public void SwichStage()
    {
        currentStage.SetActive(false);
        currentStageNum++;
        currentStage = Instantiate(stagesArray[currentStageNum]);
        currentStage.SetActive(true);
    }

    public GameObject GetCurrentStage()
    {
        return currentStage;
    }
}
