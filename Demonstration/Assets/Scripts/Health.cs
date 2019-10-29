using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEvent : UnityEvent<float> { }

public class Health : MonoBehaviour
{
    /* <Events> */
    public UnityEvent deathEvent;
    public FloatEvent healEvent;
    public FloatEvent damageEvent;
    /* </Events> */

    [SerializeField] //Hvad gør denne linje?
    [Range(20, 200)] //Hvad gør denne linje?
    private int health = 100;

    /* Immunity */

    //Formålet med denne variabel er..
    [SerializeField]
    public bool EnableImmunity = false;

    [SerializeField]
    private float immunityTime = 1.0f;

    public bool _currentlyImmune = false;

    private SpriteRenderer sr;

    /* </Immunity> */

    // Start is called before the first frame update
    void Awake()
    {
        deathEvent = new UnityEvent();
        healEvent = new FloatEvent();
        damageEvent = new FloatEvent();

        damageEvent.AddListener(TakeDamage);

        sr = GetComponent<SpriteRenderer>();

    }

    /// <summary>
    /// Hvad gør denne funktion?
    /// </summary>
    /// <param name="damageRecieved">Hvad gør denne parameter?</param>
    private void TakeDamage(float damageRecieved)
    {
        
        
            health -= (int)damageRecieved;
            Debug.Log(health);
            if (health <= 0)
            {
                deathEvent.Invoke();
            }

            //Vi skal ikke blive immune, hvis vi ikke kan blive immune.
            
            if (EnableImmunity)
            {
                StartCoroutine(ImmunityTimer(immunityTime));
            }

        
        
    }
    

    public int GetHealth()
    {
        return health;
    }

    IEnumerator ImmunityTimer(float seconds)
    {
        _currentlyImmune = true;

        //StartCoroutine(Flicker());

        yield return new WaitForSeconds(seconds);
        _currentlyImmune = false;

        //sr.enabled = true;

    }

    IEnumerator Flicker()
    {
        while(_currentlyImmune)
        {
            sr.enabled = false;
            yield return new WaitForEndOfFrame();
            sr.enabled = true;
            yield return new WaitForEndOfFrame();
        }
    }

}
