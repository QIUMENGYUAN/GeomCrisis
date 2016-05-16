using UnityEngine;
using System.Collections;

public class DynamicScale : MonoBehaviour
{

    public float ScaleSpeed = 0.01f;
    public float DangerDistance = 1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - PlayerController.playerPosition.x) <= DangerDistance)
        {
            transform.localScale += new Vector3(0.01f, ScaleSpeed, 0);
        }

    }
}
