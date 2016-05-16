using UnityEngine;
using System.Collections;

public class RadiationController : MonoBehaviour
{


    public float speed = 0.2f;
    public Vector2 direction = new Vector2(-1, 0);
    public Vector2 TriggerDirection = new Vector2(-0.2f, -1);
    Rigidbody2D rb;
    float StopPisition;
    public float FallSpeed = 10;
    public float FallDistance = 2;
    void Awake()
    {
        StopPisition = transform.position.y - FallDistance;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }

    void Update()
    {
        rb.velocity = direction * speed;

        if (Mathf.Abs(transform.position.x - PlayerController.playerPosition.x) <= 1f)
        {

            speed = FallSpeed;
            //int de = PlayerController.playerPosition.y - transform.position.y > 0 ? 1 : -1;
            direction = TriggerDirection;
        }

        if (transform.position.y <= StopPisition)
        {
            speed = 1.2f;
            direction = new Vector2(-1, 0);
        }
    }

}
