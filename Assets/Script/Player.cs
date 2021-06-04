using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //速さ

    public float speed = 3f;

    //方向転換スピード

    public float rotateSpeed = 200f;

    public Rigidbody rigid;
    private Animator animator;

    void Start()

    {

        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        animator.SetFloat("walk", Input.GetAxis("Vertical"));
        // animator.SetFloat("walk", Input.GetAxis("Horizontal"));
    }
        void FixedUpdate()

    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(0, 0, v);

        // キャラクターのローカル空間での方向に変換

        velocity = transform.TransformDirection(velocity);

        //この間に移動処理
        // キャラクターの回転

        transform.Rotate(0, h * rotateSpeed * Time.fixedDeltaTime, 0);
        rigid.MovePosition(transform.position+velocity*speed*Time.deltaTime);
    }
}
