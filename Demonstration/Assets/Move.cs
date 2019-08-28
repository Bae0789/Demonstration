using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]
    [Range(0.5f, 10f)]
    private float forceMod;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalForce = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rb2d.velocity.x) > 5)
        {
            Debug.Log("Du kører for hurtigt!");
            return;
        }


        rb2d.AddForce(Vector2.right * horizontalForce * 15f);

        


        /* 1: Lav en if statement der tjekker om 
         *      horizontalForce er forskellig fra nul.
         *      tip: != betyder 'ikke ens' så 0 != 1 er sandt, fordi 0 er ikke 1.
         * 2: Inde i if statementen, 
         *      brug rigidbody AddForce metoden med horizontalForce som parameter til at få spilleren til at flytte sig.
         *      tip: Jeg har hentet rigidbodien til jer, den hedder rb2d, se linje 16.
         *      tip 2: AddForce forventer en retning, så brug Vector2.Right * horizontalForce
         *      tip 3: husk at forceMod også skal være med.
         * 3: playtest
         *      Virker det som det skal?
         * 4: Sæt en absolut grænse på farten.
         *      brug en ekstra if statement til at se om farten er for høj.
         *      tip: rb2d.velocity.x indeholder den nuværende fart.
         *      tip 2: du kan bruge Debug.Log("besked"); til at skrive en besked hvis farten er for høj.
         *      tip 3: hvis du vil sænke farten kan du bruge rb2d.velocity * 0.95f;
         */

    }
}
