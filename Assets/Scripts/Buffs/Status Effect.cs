using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public abstract class StatusEffect : MonoBehaviour, ISetCardInfo/*, IStatusEffect*/
{
    char buffCode;
    protected BuffManager buffManager;
    CardInfo cardInfo;
    BuffStat buffStat;

    public char _BuffCode { get { return buffCode; } set { buffCode = value; } }
    public CardInfo _CardInfo { get { return cardInfo; } set { cardInfo = value; } }
    public BuffStat _BuffStat { get { return buffStat; } set { buffStat = value; } }
    //private int _point;
    //public int point { get { return _point; } protected set { _point = value; } }

    //private int _rank = 1;
    //public int rank { get { return _rank; } protected set { _rank = value; } }

    //private int _upBuffValue;
    //public int upBuffValue { get { return _rank; } protected set { _rank = value; } }

    //private int _useBuffValue;
    //public int useBuffValue { get { return _rank; } protected set { _rank = value; } }

    public abstract void OnChecked();
    protected void FindBuffManager(BuffManager buff)
    {
        try
        {
            if (GameObject.FindWithTag("BuffManager")
            .TryGetComponent<BuffManager>(out buff))
            {
                this.buffManager = buff;
            }
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError($"에러 대상:{this.name }$에러 내용: {e.Message}");
            throw e;
        }
    }
    public virtual void GetRandomCodeWithInfo(char buffCode, CardInfo cardInfo, BuffStat buffStat)
    { _BuffCode = buffCode; _CardInfo = cardInfo; _BuffStat = buffStat; }

    public virtual void SetCardInfo()
    {
        if (this.transform.GetChild(0).GetChild(1)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI buffname))
        {
            buffname.text = cardInfo.cardName;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(0).GetChild(2)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI information))
        {
            information.text = cardInfo.information;
        }
        else Debug.LogError("Not Setted Object You're null!!");

        if (this.transform.GetChild(0).GetChild(3)
            .TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI description))
        {
            description.text = cardInfo.description;
        }
        else Debug.LogError("Not Setted Object You're null!!");


        if (this.transform.GetChild(0).GetChild(0).TryGetComponent<Image>(out Image frontImage))
        {

            frontImage.sprite = Resources.Load<Sprite>(Path.Combine(StringManager.Instance.buffCardResource, cardInfo.fRImage));
            if (frontImage.sprite == null)
            {
                Debug.Log($"There is no resource__{cardInfo.fRImage} at: " + Path.Combine(Application.dataPath + $"/{StringManager.Instance.attackCardResource}", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child frontImage");
        }

        if (this.transform.GetChild(0).TryGetComponent<Image>(out Image backImage))
        {

            backImage.sprite = Resources.Load<Sprite>(Path.Combine(StringManager.Instance.buffCardResource, cardInfo.bGImage));
            if (backImage.sprite == null)
            {
                Debug.Log($"There is no resource__{cardInfo.bGImage} at: " + Path.Combine(Application.dataPath + "/BuffCardResource/", ""));
            }
        }
        else
        {
            Debug.Log("wrong Path in child backImage");
        }
        //this.transform.GetChild(0).GetChild(1).GetComponent<TextMeshPro>().text = cardInfo.BuffEnumName;
        //this.transform.GetChild(2).GetComponent<TextMeshPro>().text = cardInfo.information;
        //this.transform.GetChild(3).GetComponent<TextMeshPro>().text = cardInfo.description;

        //this.GetComponent<Image>().sprite = cardInfo.FRImage;
        //data = buffManager.SetBuffData(buffCode, stat);
        //Debug.Log(stat);
    }

    // 아래는 인터페이스인데 이거 이렇게 써야 할 필요 있나?
    //public virtual BuffStat BuffUse()
    //{
    //    return new BuffStat();
    //}

    //public virtual BuffStat BuffUp()
    //{
    //    return new BuffStat();
    //}

}
