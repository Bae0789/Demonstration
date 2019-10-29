using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
public class AudioOnMove : MonoBehaviour
{

    [SerializeField]
    [Range(0.5f, 3f)]
    float speedThreshold = 1f;

    public UnityEvent moveEvent;
    AIPath aip;


    private void Awake()
    {
        moveEvent = new UnityEvent();
    }


    // Start is called before the first frame update
    void Start()
    {
        aip = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if(aip.velocity.magnitude > speedThreshold)
        {
            moveEvent.Invoke();
        }
    }
}
