using UnityEngine;
using System.Collections;

public class CheckLine : MonoBehaviour {

    public GameObject NextCheckPoint;
    Vector3 StartPosition ;
    bool Into = true;

    void Start()
    {
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && Into)
        {

            StartPosition = new Vector3(PointCheck.PointPosition + 10f, -0.25f, -0.1f); 
            
            if (PlayerPrefs.GetInt("CheckPoint", 0) <8)
                Instantiate(NextCheckPoint, StartPosition, Quaternion.identity);
            Into = false;
            Destroy(gameObject);
        }
    }

}
