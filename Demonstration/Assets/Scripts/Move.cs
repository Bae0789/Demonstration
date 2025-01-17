﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Move : MonoBehaviour
{
    Animator anim;

    public UnityEvent moveEvent;

    [SerializeField]
    [Range(0.5f, 10f)]
    private float forceMod;

    Rigidbody2D rb2d;

    

    SpriteRenderer sr;

    private void Awake()
    {
        moveEvent = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalForce = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rb2d.velocity.x) > 5)
        {
            rb2d.velocity *= 0.95f;
        }


        rb2d.AddForce(Vector2.right * horizontalForce * 15f);

        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));



        if(rb2d.velocity.x != 0f)
        {
            sr.flipX = rb2d.velocity.x < 0f;
            if (GetComponentInChildren<GroundCheck>().Grounded)
            {
                moveEvent.Invoke();
            }
           

        }
        
        

    }
}
