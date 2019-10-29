using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToTag : MonoBehaviour
{
    [SerializeField]
    private string damageTag;

    [SerializeField]
    private float damageAmount = 34f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(damageTag))
        {
            DealDamage(collision);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag(damageTag))
        {
            DealDamage(collision.collider);
        }
    }

    /// <summary>
    /// Denne funktion skal håndtere damage
    ///  tag en collider parameter
    ///  Find 'Health' componenten på den collider gameobject.
    ///  Lav skade (Health har en event til det)
    ///  Plug DealDamage ind i de to if statements 
    ///   OnCollisionEnter2D og OnTriggerEnter2D
    /// </summary>
    /// <param name="damageableCollider">Collider parameter</param>
    private void DealDamage(Collider2D damageableCollider)
    {
        Health health = damageableCollider.GetComponent<Health>();
        if (!health.EnableImmunity || (health.EnableImmunity && !health._currentlyImmune))
        {
            damageableCollider.GetComponent<Health>().damageEvent.Invoke(damageAmount);
        }

    }


}
