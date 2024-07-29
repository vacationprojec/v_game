using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLOgic : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;
    public float speed;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y= Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
       Vector2 nextVec = inputVec.normalized*speed*Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
}
