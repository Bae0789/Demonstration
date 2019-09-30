using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public bool Grounded = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    /// <summary>
    /// Lalala
    /// </summary>
    /// <param name="col">Col er ....</param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ground") && Grounded != true)
        {
            Grounded = true;

            anim.SetBool("isGrounded", Grounded);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground") && Grounded != false)
        {
            Grounded = false;

            anim.SetBool("isGrounded", Grounded);

        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        
        OnTriggerEnter2D(col);
    }
    

}
