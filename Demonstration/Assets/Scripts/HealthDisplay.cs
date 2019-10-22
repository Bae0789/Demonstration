using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    GameObject player;

    Text text;

    public float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        text = GetComponent<Text>();

        player.GetComponent<Health>().damageEvent.AddListener(SetDisplay);
        health = (float)player.GetComponent<Health>().GetHealth();
        text.text = health.ToString();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    void SetDisplay(float damage)
    {
        health -= damage;
        text.text = health.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
