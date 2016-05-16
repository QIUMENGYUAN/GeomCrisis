using UnityEngine;
using System.Collections;

public class BatteryShot : MonoBehaviour
{
    public float fireRate = 0.5f;
    public GameObject shot;
    public Transform shotSpawn;

    private float nextFire = 0f;


    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
        }
    }
}
