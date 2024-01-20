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
}
