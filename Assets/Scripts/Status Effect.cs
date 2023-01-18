using UnityEngine;
public abstract class StatusEffect : MonoBehaviour
{
    protected BuffManager buffManager;

    public int rank;
    public abstract void Init();
    public abstract void OnChecked();
    protected void FindBuffManager(BuffManager buff)
    {
        try
        {
            if (GameObject.FindWithTag("BuffManager")
            .TryGetComponent<BuffManager>(out buff))
            {
                Debug.Log(buff);
                this.buffManager = buff;
            }
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError(e.Message);
            throw e;
        }
    }
}
