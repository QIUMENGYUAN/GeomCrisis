using UnityEngine;
using System.Collections;

public class MoveLoop : MonoBehaviour
{

    public float speed;
    public Vector2 direction;
    private Rigidbody2D rb;
    float rotate = 0;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = direction * speed;
        transform.rotation = new Quaternion(0, rotate, 0, 0);
        if (Mathf.Abs(transform.position.x) >= 9f)
        {
            float decrease = transform.position.x > 0 ? 0.5f : -0.5f;
            transform.position -= new Vector3(decrease, 0, 0);
            direction *= -1;
            rotate += transform.position.x > 0 ? 180 : -180;
        }
    }
}
