using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct PlayerStatStruct
{
    float health;
    float defence;
    float speed;
    float will;

    // when it activated
    float damage;
    float avoidness;
    float blockness;


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
    PlayerStat playerStat;
    public void GetDamaged(float dmg)
    {
        //playerStat.he
    }

    // Start is called before the first frame update
    void Start()
    {
        playerStat = new PlayerStat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
