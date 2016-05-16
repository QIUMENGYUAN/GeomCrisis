using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public  float speed;
    public  Vector2 direction;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = direction * speed;
    }

}
