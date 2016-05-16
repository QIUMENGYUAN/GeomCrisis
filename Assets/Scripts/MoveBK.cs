using UnityEngine;
using System.Collections;

public class MoveBK : MonoBehaviour
{
    //public Vector2 speed = new Vector2(1, 1);
    //public Vector2 direction = new Vector2(1, 0);
    //private Vector2 movement;

    //void Update()
    //{
    //    // 1 - Movement
    //    movement = new Vector2(speed.x * direction.x,speed.y * direction.y);
    //    if (transform.position.x >= 24.8)
    //    {
    //        transform.position = new Vector2(-10.8f, transform.position.y);
    //    }
    //}
    //void FixedUpdate()
    //{
    //    GetComponent<Rigidbody2D>().velocity = movement;
    //}


    public float moveSpeed = 0.5f;
    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (transform.position.x <= -11f)
        {
            transform.position = new Vector2(24.4f, transform.position.y);
            if (gameObject.name == "com")
                Destroy(gameObject);
        }
    }
}