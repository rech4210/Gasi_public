using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObj : AtkObjStat
{
    Material laserMaterial;
    float scaleSpeed = 5f;
    int count = 0 ;
    float time = 0;

    PlayerStat target;
    // Start is called before the first frame update
    void Start()
    {
        laserMaterial = GetComponent<MeshRenderer>().material;
        transform.rotation = new Quaternion(0,Random.Range(0f,180f),0,0);
        StartCoroutine(LaserLock());
    }

    IEnumerator LaserLock()
    {
        var time = 0f;
        while (true)
        {
            time += Time.deltaTime;
            if (time > 1f)
            {
                break;
            }

            laserMaterial.color
            = new Color(Random.Range(.0f, 1), Random.Range(.0f, 1), Random.Range(.0f, 1))
            * ((1 + Mathf.Sin(Time.deltaTime)) * 0.5f);

            yield return null;
        }

        GetComponent<BoxCollider>().enabled = true;
        var scale = transform.lossyScale;
        time = 0f;
        while (true)
        {
            time += Time.deltaTime;
            if (time > 1f)
            {
                break;
            }
            transform.localScale = scale * ((Mathf.Cos(Time.deltaTime * scaleSpeed)) * 1f + 10f);
            yield return null;
        }
    }

    public override void OnHitTarget()
    {
        Debug.Log("레이저 타격");
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (target == null)
            {
                target = other.GetComponent<PlayerStat>();
            }

            var time = 0f;
            while (true)
            {
                if (target== null)
                {
                    break;
                }

                time = Time.deltaTime;
                if (time > 0.1f)
                {
                    target.GetDamaged(point * 0.1f);
                    time = 0f;
                }

            }
        }

    }
    void Update()
    {
        
    }
}
