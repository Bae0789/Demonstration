using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SoundEnums {
    Jump,
    Shoot,
    Hit,
    Move,
    Land,
    EnemyShoot,
    EnemyHit,
    EnemyMove
}


[RequireComponent(typeof(AudioSource))]
public class Pso : MonoBehaviour
{

    public SoundEnums sEnum;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        switch (sEnum)
        {
            case SoundEnums.Jump:
                GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>().jumpEvent.AddListener(Play);
                break;
            case SoundEnums.Shoot:
                break;
            case SoundEnums.Hit:
                break;
            case SoundEnums.Move:
                break;
            case SoundEnums.Land:
                break;
            case SoundEnums.EnemyShoot:
                GetComponentInParent<Shoot>().shootEvent.AddListener(Play);
                break;
            case SoundEnums.EnemyHit:
                break;
            case SoundEnums.EnemyMove:
                break;
            default:
                break;
        }

    }


    void Play() {
        Debug.Log("Invoked");
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        
    }

    void PlayF(float _)
    {
        Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
