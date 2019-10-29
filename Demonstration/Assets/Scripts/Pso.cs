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
                GetPlayer().GetComponent<Jump>().jumpEvent.AddListener(Play);
                break;
            case SoundEnums.Shoot:
                GetPlayer().GetComponent<Shoot>().shootEvent.AddListener(PlayI);
                break;
            case SoundEnums.Hit:
                GetPlayer().GetComponent<Health>().damageEvent.AddListener(PlayF);
                break;
            case SoundEnums.Move:
                GetPlayer().GetComponent<Move>().moveEvent.AddListener(Play);
                break;
            case SoundEnums.Land:
                GetPlayer().GetComponentInChildren<GroundCheck>().landEvent.AddListener(Play);
                break;
            case SoundEnums.EnemyShoot:
                GetComponentInParent<Shoot>().shootEvent.AddListener(Play);
                break;
            case SoundEnums.EnemyHit:
                GetComponentInParent<Health>().damageEvent.AddListener(PlayF);
                break;
            case SoundEnums.EnemyMove:
                //GetComponentInParent<Shoot>().shootEvent.AddListener(Play);
                break;
            default:
                break;
        }

    }

    private static GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    void Play()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        
    }

    void PlayF(float _)
    {
        Play();
    }

    void PlayI()
    {
        audioSource.Stop();
        audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
