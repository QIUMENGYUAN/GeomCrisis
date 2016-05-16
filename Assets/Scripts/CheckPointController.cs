using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour
{

    public GameObject[] CheckPoints;
    Vector3 StartPosition = new Vector3(8f, -0.25f, -1f);
    GameObject obj;
    void Start()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("CheckPoint", 0) >= 9)
        {
            PlayerPrefs.SetInt("CheckPoint", 9);
            StartPosition = new Vector3(8f, 2f, -1f);
        }

        obj = Instantiate(CheckPoints[PlayerPrefs.GetInt("CheckPoint", 0)], StartPosition, Quaternion.identity) as GameObject;
    }
}
