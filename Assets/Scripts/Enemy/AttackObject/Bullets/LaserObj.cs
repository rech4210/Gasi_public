using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserObj : AtkObjStat<LaserObj>, IUseSkill
{
    Material laserMaterial;
    float scaleSpeed = 5f;
    int count = 0 ;
    float time = 0;
    Color emissionColor = new Color(0.5f, 0.5f, 0.5f);

    PlayerData target;

    public override void Initialize(AttackStatus attackStatus, bool skill_1, bool skill_2)
    {
        GetAtkObjPoint(attackStatus);
        if(skill_1)
        {
            //더블 레이저
            Skill();
        }
    }


    void Start()
    {
        laserMaterial = GetComponent<MeshRenderer>().material;
        transform.rotation = new Quaternion(0,Random.rotation.y,0,Random.rotation.w);
        target = GameManager.Instance._PlayerTransform.GetComponent<PlayerData>();
        // 플레이어를 상위 개체가 가지도록 하자.
        StartCoroutine(LaserLock());
        emissionColor *= 1.23f;
    }


    public override void OnHitTarget()
    {
        target = GameObject.FindWithTag("Player")? GetComponent<PlayerData>() : null ;
        Debug.Log("레이저 타격");
    }


    private void OnTriggerStay(Collider other)
    {
        //피격을 통합해서 관리해야할듯
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
    //void Update()
    //{
        
    //}


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
            * ((1 + Mathf.Sin(Time.deltaTime)));

            yield return null;
        }


        GetComponent<BoxCollider>().enabled = true;
        laserMaterial.SetColor("_EmissionColor", emissionColor);
        gameObject.GetComponent<MeshRenderer>().material.shader = laserMaterial.shader;
        // 이궈궈던~~~~~!! 앞으로 변경사항 적용시킬땐 자기 자신 다시 넣어주자..
        //laserMaterial.SetShaderPassEnabled("_EMISSION", false);
        //laserMaterial.SetShaderPassEnabled("_EMISSION", true);

        var scale = transform.lossyScale;
        time = 0f;
        while (true)
        {
            time += Time.deltaTime;
            transform.localScale = scale * ((Mathf.Cos(Time.deltaTime * scaleSpeed)) * 1f + Random.Range(4.5f, 5f));
            laserMaterial.SetColor("_EmissionColor", emissionColor);

            if (time > 0.4f)
            {
                Destroy(gameObject);
                break;
            }
            yield return null;
        }
    }
    public void Skill()
    {
        //transform.Rotate(n9-rew Vector3(0, 100f * Time.deltaTime, 0));
    }

}
