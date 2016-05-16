using UnityEngine;
using System.Collections;

public class PointCheck : MonoBehaviour
{

    public static float PointPosition;
    bool Into = true;
    public GameObject win;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && Into)
        {

            ShowScore.score += 200;
            PlayerPrefs.SetInt("Score", ShowScore.score);
            PlayerPrefs.SetInt("CheckPoint", PlayerPrefs.GetInt("CheckPoint", 0) + 1);
            Into = false;

            if (PlayerPrefs.GetInt("CheckPoint", 0) >= 9)
                Instantiate(win, new Vector3(transform.position.x + 7, 2, -1), Quaternion.identity);

            Destroy(gameObject);
        }
    }
    void Update()
    {
        PointPosition = transform.position.x;
    }
}
