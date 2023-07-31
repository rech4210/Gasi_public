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
        transform.rotation = new Quaternion(0,Random.rotation.y,0,Random.rotation.w);
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
            transform.localScale = scale * ((Mathf.Cos(Time.deltaTime * scaleSpeed)) * 1f + Random.Range(3,6f));
            if (time > 0.4f)
            {
                Destroy(gameObject);
                break;
            }
            yield return null;
        }
    }

    public override void OnHitTarget()
    {
        target = GameObject.FindWithTag("Player").GetComponent<PlayerStat>();
        Debug.Log("레이저 타격");
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            var time = 0f;
            //while (true)
            //{
            //    if (target== null)
            //    {
            //        break;
            //    }

                time = Time.deltaTime;
                if (time > 0.01f)
                {
                    target.GetDamaged(point * 0.1f);
                    time = 0f;
                }

            //}
        }

    }
    void Update()
    {
        
    }
}
