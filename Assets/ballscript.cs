﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    public int speed = 20;
    public Rigidbody2D sesuatu;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        sesuatu.velocity = new Vector2(-1,1)*speed;
        animator.SetBool("IsMove",true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sesuatu.velocity.x > 0){ //bola bergerak ke kanan
            sesuatu.GetComponent<Transform>().localScale = new Vector3(1,1,1);   
        }else
        {
            sesuatu.GetComponent<Transform>().localScale = new Vector3(-1,1,1);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
       if(other.collider.name=="Kanan" || other.collider.name=="Kiri"){
           GetComponent<Transform>().position = new Vector2(0,0);
       } 
    } 
    IEnumerator jeda(){
        sesuatu.velocity = Vector2.zero;
        animator.SetBool("IsMove",false);
        sesuatu.GetComponent<Transform>().position=Vector2.zero;
        yield return new WaitForSeconds(1);
        sesuatu.velocity = new Vector2(-1,-1)*speed;
        animator.SetBool("IsMove", true);
    }
}
