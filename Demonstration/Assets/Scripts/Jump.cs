using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Jump : MonoBehaviour
{
    [SerializeField]
    private float forceMod = 10f;

    private Rigidbody2D rb2d;

    private GroundCheck gc;

    public UnityEvent jumpEvent;
    

    void Awake(){
        jumpEvent = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        gc = GetComponentInChildren<GroundCheck>(); //Der skal stå noget andet her.
        jumpEvent.AddListener(DoJump);
    }

    // Update is called once per frame
    void Update()
    {

        // Hvis space bar er trykket ned denne frame...
        if(Input.GetKeyDown(KeyCode.Space) && gc.Grounded == true)
        {
            jumpEvent.Invoke();
            
        }


    }

    private void DoJump()
    {
        rb2d.AddForce(Vector2.up * forceMod, ForceMode2D.Impulse);
    }
}
