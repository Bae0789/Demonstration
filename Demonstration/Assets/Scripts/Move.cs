using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Animator anim;


    [SerializeField]
    [Range(0.5f, 10f)]
    private float forceMod;

    Rigidbody2D rb2d;

    

    SpriteRenderer sr;
    
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
        }
        
        

    }
}
