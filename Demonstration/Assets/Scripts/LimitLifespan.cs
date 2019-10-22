using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitLifespan : MonoBehaviour
{
    [Range(0.5f, 1.5f)]
    public float LifeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);   
    }

}
