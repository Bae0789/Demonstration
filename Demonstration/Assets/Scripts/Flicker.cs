using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

class Flicker : MonoBehaviour
{
    [SerializeField]
    private float flickerDuration = 1f;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Health>().damageEvent.AddListener(FlickerActivator);
        //Find spriteRenderer componenten.
        sr = GetComponent<SpriteRenderer>();

    }

    /// <summary>
    /// Hvad gør denne funktion?
    /// </summary>
    private void FlickerActivator(float _)
    {

        //Her skal vi have sat flicker tiden ind, led efter den variabel der passer ovenfor ^.
        StartCoroutine(FlickForDuration(flickerDuration));
    }

    private IEnumerator FlickForDuration(float duration)
    {
        float timestamp = GetTimeStamp();
        //Hvis du skal læse den her som en if statement, hvad står der så?
        while  (timestamp + duration > GetTimeStamp())
        {

            sr.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

    }

    /// <summary>
    /// Her skal du sætte tiden lige nu ind, den kan du finde i Time biblioteket
    /// </summary>
    /// <returns>tiden lige nu.</returns>
    private static float GetTimeStamp()
    {
        return Time.time;
    }
}

