using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObj : AtkObjStat
{
    Vector3 RandomPose()
    {
        return new Vector3(
        UnityEngine.Random.Range(17f, -17f),
        0.1f,
        UnityEngine.Random.Range(1.2f, -20f));
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = RandomPose();
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
        gameObject.GetComponent<MeshRenderer>().material.color= Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
