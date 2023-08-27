using Unity.VisualScripting;
using UnityEngine;

public struct PlayerStatStruct
{
    public float health;
    public float defence;
    public float speed;
    public float will;

    
    
    public PlayerStatStruct(float health, float defence, float speed, float will, float damage, float avoid, float block)
    {
        this.health = health;
        this.defence = defence;
        this.speed = speed;
        this.will = will;
        this.damage = damage;
        this.avoidness = avoid;
        this.blockness = block;
    }

    // when it activated
    public float damage;
    public float avoidness;
    public float blockness;
}
public struct PlayerAbilityStruct
{
    int indurance;
    int luck;
    int agility;
    int wisdom;
    int faith;
}
public class PlayerStat : MonoBehaviour
{
    PlayerStatStruct playerStat;
    public void GetDamaged(float dmg)
    {
        playerStat.health -= dmg;
        Debug.Log(playerStat.health);
        if (playerStat.health <= 0f)
        {
            isLive = false;

            DeadEvents.Instance.ExecuteEvent();
        }
    }
    bool isLive = true;

    void Start()
    {
        playerStat = new PlayerStatStruct(50,3,15,0,0,0,0);

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Background")) { }
        else if(isLive)
        {
            //예외처리?
            var attackObject = other.gameObject.GetComponent<AtkObjStat>();
            GetDamaged(attackObject.Point);
            attackObject.OnHitTarget();
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Background")) { }

    //    else 
    //    {
    //        Destroy(collision.gameObject);
    //        GetDamaged(atk.point);
    //    }
    //}
}
