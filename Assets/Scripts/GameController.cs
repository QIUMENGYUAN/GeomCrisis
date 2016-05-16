using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject battery;
    public GameObject battery2;
    public GameObject battery3;
    public GameObject radiation;
    public GameObject Hint;

    public float startWait;
    public float spawnWait;             //The interval time before init enemy
    public float waveWait;              //Enemy interval time per wave
    public float batteryWait;

    public Vector2 spawnEnemy;          //The position X where enemy init
    public Vector2 spawnBattery;
    public Vector2 spawnBattery2;
    public Vector2 spawnBattery3;

    float obstacleX1, obstacleX2;       //The position X where obstacle init
    public float obstacleYFrom, obstacleYTO;
    public float beginWait, repeate;

    private float nextSpawn = 5f;


    void Start()
    {
        if (PlayerPrefs.GetInt("FirstTime", 0) == 0)
        {
            Destroy( Instantiate(Hint, new Vector3(6.5f, 0, -1), Quaternion.identity) as GameObject,2);
            PlayerPrefs.SetInt("FirstTime", 1);
        }

        InvokeRepeating("CreateRadiation", beginWait, Random.Range(25f, 35f));
        StartCoroutine(SpawnWaves());
    }

    void CreateRadiation()
    {
        if (Random.Range(1, 5) == 4)
            for (int i = 0; i < Random.Range(1, 4); ++i)
            {
                Instantiate(radiation, new Vector3(17 + i * 1.2f, 2.8f, -0.2f), Quaternion.identity);
            }
    }

    void FixedUpdate()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.fixedTime + Random.Range(10f, 25f);
            int select = Random.Range(1, 7);
            switch (select)
            {
                case 1:
                    for (int i = 0; i < Random.Range(1, 3); ++i)
                    {
                        Instantiate(battery, new Vector3(spawnBattery.x, spawnBattery.y, -1.1f), Quaternion.identity);
                        spawnBattery.x += 1f;
                    }
                    break;
                case 2:
                    int num = Random.Range(0, 2);
                    spawnBattery2.y *= (num == 0) ? 1 : -1;
                    Instantiate(battery2, new Vector3(spawnBattery2.x, spawnBattery2.y, -1.1f), Quaternion.Euler(0f, 0f, num == 0 ? 0 : 180));
                    break;
                case 3:
                    Instantiate(battery2, new Vector3(spawnBattery2.x, spawnBattery2.y, -1.1f), Quaternion.identity);
                    spawnBattery2.y *= -1;
                    Instantiate(battery2, new Vector3(spawnBattery2.x, spawnBattery2.y, -1.1f), Quaternion.Euler(0f, 0f, 180f));
                    break;
                case 4:
                    GameObject tmp1 = Instantiate(battery3, new Vector3(spawnBattery3.x, spawnBattery3.y, -1.1f), Quaternion.identity) as GameObject;
                    tmp1.GetComponentInChildren<RotateByZ>().rotateSpeed = 1;

                    spawnBattery3.y *= -1;
                    GameObject tmp2 = Instantiate(battery3, new Vector3(spawnBattery3.x, spawnBattery3.y, -1.1f), Quaternion.Euler(0f, 0f, 180f)) as GameObject;
                    tmp2.GetComponentInChildren<RotateByZ>().rotateSpeed = -1;
                    break;
                default:
                    break;
            }

        }
    }


    IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(startWait);
            int num = Random.Range(1, 4);
            for (int i = 0; i < num; ++i)
            {
                Vector2 spawnPosition = new Vector2(spawnEnemy.x, Random.Range(-2.7f, 2.7f));
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }


}



