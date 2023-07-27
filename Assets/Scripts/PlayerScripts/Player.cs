using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    Vector3 Mytransform;

    Rigidbody Myrigid;
    [Range(5, 20)] public float _MovePower = 15;
    [Range(5, 20)] public float _JumpPower = 5;

    Vector3 normalizedVector; // 노말라이즈 변수
    private Dictionary<KeyCode, Vector3> keyValuePairs = new Dictionary<KeyCode, Vector3>();
    

    void Start()
    {
        AddDictionary();
        Mytransform = this.gameObject.transform.position;
        Myrigid = GetComponent<Rigidbody>();
        Myrigid.MovePosition(Mytransform);  // 게임 오브젝트의 초기 위치로 이동
    }


    void FixedUpdate()
    {
        Mytransform = transform.position;

        if (Input.anyKey)
        {
            KeySetting();
        }
    }


    void KeySetting()
    {
        foreach (var dic in keyValuePairs)
        {
            if (Input.GetKey(dic.Key))
            {
                vector_Normalized(dic.Value);
            }
        }
    }

    void vector_Normalized(Vector3 vector3)
    {

        normalizedVector = vector3.normalized * _MovePower * Time.deltaTime; //대각선 움직임을 부드럽게 하기위한 벡터 노말라이즈 과정
        Mytransform += normalizedVector;
        Myrigid.MovePosition(Mytransform);


        // 물리 충돌 수정, 로컬 좌표계로 이동시 각도에따른 방향 이동 제어
    }

    public void AddDictionary()
    {
        keyValuePairs.Add(KeyCode.W, transform.forward);
        keyValuePairs.Add(KeyCode.A, -transform.right);
        keyValuePairs.Add(KeyCode.S, -transform.forward);
        keyValuePairs.Add(KeyCode.D, transform.right);
    }
}
