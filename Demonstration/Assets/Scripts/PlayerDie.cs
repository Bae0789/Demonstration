using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{

    public int loseScene=0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Health>().deathEvent.AddListener(Reload);
    }

    private void Reload()
    {
        SceneManager.LoadScene(loseScene);
    }
    
}
