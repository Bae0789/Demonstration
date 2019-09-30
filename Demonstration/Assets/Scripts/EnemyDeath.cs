using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Health>().deathEvent.AddListener(Remove);    
    }

    private void Remove()
    {
        Destroy(this.gameObject);
    }
}
