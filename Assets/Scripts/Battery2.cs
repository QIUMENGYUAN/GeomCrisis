using UnityEngine;
using System.Collections;

public class Battery2 : MonoBehaviour
{
    Transform player;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire = 2f;
    //private bool start = true;
    private Vector2 direction;
    private Quaternion toPlayer;
    private bool isUp = false;


    void Start()
    {
        if (transform.position.y > 0)
            isUp = true;
        GameObject tmp = GameObject.FindWithTag("Player");
        if (tmp != null)
            player = tmp.transform;
    }


    void Update()
    {
        if (player == null)
            return;
        if (isUp)
        {
            direction = transform.position - player.position;
            toPlayer = Quaternion.Euler(0f, 0f, 360f - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);
        }
        else
        {
            direction = player.position - transform.position;
            toPlayer = Quaternion.Euler(0f, 0f, 180f - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);
        }
        
        transform.rotation = Quaternion.Slerp(transform.rotation, toPlayer, .5f);
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject tmp = Instantiate(shot, shotSpawn.position, transform.rotation) as GameObject;
            tmp.GetComponent<Mover>().speed = 3f;
            tmp.GetComponent<Mover>().direction = direction.normalized * (isUp ? -1 : 1);

        }

    }

}
