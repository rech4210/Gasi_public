using System.Collections;
using UnityEngine;

public class Bullet : AttackFunc
{
    [SerializeField] GameObject attackObject;

    void Start()
    {
        StartCoroutine(Attack());
    }
    private void Update()
    {
        //ExcuteAttack();
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(_Player.transform.position - transform.position);
    }
    public override void CalcStat(AttackStatus status, AttackCardInfo info)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    public override void Skill_1()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill_2()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill_3()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator Attack()
    {
        while (true)
        {
            ExcuteAttack();
            yield return new WaitForSeconds(0.5f);
        }

    }
    protected override void ExcuteAttack()
    {
        //Instantiate(attackObject,transform);
        Instantiate(attackObject, transform.position + transform.forward ,transform.rotation);

    }
}
