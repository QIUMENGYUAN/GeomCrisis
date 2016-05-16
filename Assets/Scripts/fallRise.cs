using UnityEngine;
using System.Collections;

public class fallRise : MonoBehaviour {


    public float speed=2;
    public Vector2 direction=new Vector2(-1, 0);
    Rigidbody2D rb;

    float fallPosition, de;
    int  canFallRise ;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        canFallRise = Random.Range(0, 13);
        fallPosition = Random.Range(4, 12);
    }

    void Update()
    {
        rb.velocity = direction * speed;

        if (transform.position.x <= fallPosition && canFallRise==12)
        {
             speed = 7;
             de = transform.position.y > 0 ? -1 : 1;
             direction = new Vector2(-Random.Range(2, 5)/10f, de);
             canFallRise = 0;
        }
    }

}
