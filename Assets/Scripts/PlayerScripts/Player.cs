using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 direction;
    Vector3 desVector;
    Vector3 refValue = Vector3.zero;
    Rigidbody rigid;

    [SerializeField] private float velocityLimit = 0.3f;
    private float walkDeaccelerationOnX;
    private float walkDeaccelerationOnZ;
    [SerializeField] private float walkDeacceleration = 3f;

    [Range(5, 30)] private float movePower = 13;

    Vector3 normalizedVector; // 노말라이즈 변수
    private Dictionary<KeyCode, Vector3> keyValuePairs = new Dictionary<KeyCode, Vector3>();
    

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * movePower;
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector3(Mathf.SmoothDamp(direction.x, 0, ref walkDeaccelerationOnX,walkDeacceleration),0,
                                     Mathf.SmoothDamp(direction.z, 0,ref walkDeaccelerationOnZ,walkDeacceleration));
        if (rigid.velocity.magnitude < velocityLimit)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
        //rigid.velocity = Vector3.SmoothDamp(rigid.velocity, direction, ref refValue, .2f) * Time.fixedDeltaTime * movePower;
    }

    Vector3 vector_Normalized(Vector3 vector3)
    {
        return normalizedVector = vector3 * movePower; //대각선 움직임을 부드럽게 하기위한 벡터 노말라이즈 과정
        // 물리 충돌 수정, 로컬 좌표계로 이동시 각도에따른 방향 이동 제어
    }
}
