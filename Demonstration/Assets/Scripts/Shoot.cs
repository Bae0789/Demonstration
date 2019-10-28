using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{

    public UnityEvent shootEvent;

    //Den bullet vi instanciere 
    [SerializeField]
    GameObject bullet;
    //True: Du er spilleren, false: Du er en enemy
    [SerializeField]
    bool playerMode = false;
    //HVor lang tid der går mellem hvert skud
    [SerializeField]
    float cooldown = 1f;

    private Vector3 direction;

    //Knappen man trykker på for at den skyder.
    [SerializeField]
    private KeyCode shootKey = KeyCode.Mouse0;

    //Gør at man ikke kan skyde igen.
    bool _currentlyCoolingDown = false;

    void Awake () {
        shootEvent = new UnityEvent();
    }


    // Start is called before the first frame update
    void Start()
    {
        if(!playerMode)
        {
            shootEvent.AddListener(EnemyShoot);
            StartCoroutine(EnemyShootTimer(cooldown));
        }
        else
        {
            shootEvent.AddListener(PlayerShoot);
        }
    }

    private IEnumerator EnemyShootTimer(float cooldown)
    {
        while (true)
        {
            yield return new WaitForSeconds(cooldown);
            shootEvent.Invoke();
        }
    }

   

    private IEnumerator PlayerShootTimer(float cooldown)
    {
        _currentlyCoolingDown = true;
        yield return new WaitForSeconds(cooldown);
        _currentlyCoolingDown = false;
    }

    private GameObject CreateBulletTowardsTarget(Vector3 position)
    {
        return Instantiate(bullet, transform.position + (position - transform.position).normalized  , Quaternion.identity, null);
    }

    // Update is called once per frame
    void Update()
    {
        //Denne er efterladt tom, 
        if(playerMode && Input.GetKeyDown(shootKey) && !_currentlyCoolingDown)
        {
            shootEvent.Invoke();
        
        }
    }
 private void EnemyShoot()
    {
        var instanciatedBullet = CreateBulletTowardsTarget(GameObject.FindGameObjectWithTag("Player").transform.position);
        instanciatedBullet.GetComponent<Rigidbody2D>().AddForce((GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized * 5f, ForceMode2D.Impulse);
    }
    private void PlayerShoot()
    {
        StartCoroutine(PlayerShootTimer(cooldown));
        GameObject instanciatedBullet = CreateBulletTowardsTarget(GetMousePos());
        instanciatedBullet.GetComponent<Rigidbody2D>().AddForce((GetMousePos() - transform.position).normalized * 5f, ForceMode2D.Impulse);
    }

    private static Vector3 GetMousePos(bool normalized = false)
    {
        Vector3 camvec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        camvec.z = 0f;
        return normalized ? camvec.normalized : camvec;
    }

}
