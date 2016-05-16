using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;

}


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float fireRate = 0.5f;
    public Boundary boundary;
    public GameObject shot;

    private Rigidbody2D rb;
    private float nextFire = 0f;
    public GUISkin skin;
    public static Vector3 playerPosition;
    Vector3 TouchPosition = Vector3.zero;


    void Awake()
    {
        skin.button.normal.background = null;
        rb = GetComponent<Rigidbody2D>();

    }
    //Screen Position To World Position;
    //var posi = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));

    void OnGUI()
    {

        //if (GUI.RepeatButton(new Rect(Screen.width * 7 / 9, Screen.height * 5 / 9, 200, 200), "Fire", skin.button)
        //    && (Time.time > nextFire))
        //{
        //    nextFire = Time.time + fireRate;
        //    Instantiate(shot, new Vector3(playerPosition.x + 0.7f, playerPosition.y, -2), Quaternion.Euler(0, 0, 90));
        //}

        //else
        //{
        //    if (Event.current.type == EventType.MouseDown)
        //    {
        //        first = Event.current.mousePosition;
        //    }
        //    if (Event.current.type == EventType.MouseDrag)
        //    {
        //        second = Event.current.mousePosition;

        //        Offset.x = second.x - first.x;
        //        Offset.y = first.y - second.y;
        //        first = second;
        //        //transform.position += new Vector3(Offset.x, Offset.y, 0) * 0.03f;
        //        transform.Translate(Offset.x * 0.03f, Offset.y * 0.03f, 0);
        //    }
        //}


    }
    void Update()
    {
        playerPosition = transform.position;
        if (Input.GetButton("Fire1") && (Time.time > nextFire))
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, new Vector3(playerPosition.x + 0.7f, playerPosition.y, -2), Quaternion.Euler(0, 0, 90));
        }


        if (Input.touchCount > 0 && (
            Input.GetTouch(0).phase == TouchPhase.Moved ||
            Input.GetTouch(0).phase == TouchPhase.Began ||
            Input.GetTouch(0).phase == TouchPhase.Stationary))
        {
            TouchPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(new Vector3(TouchPosition.x, TouchPosition.y, 0) * 0.1f);

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, new Vector3(playerPosition.x + 0.7f, playerPosition.y, -2), Quaternion.Euler(0, 0, 90));
            }
        }

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector2
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin + 1.2f, boundary.yMax - 1.2f)
        );
        //if (Input.touchCount > 0 && (
        //    Input.GetTouch(0).phase == TouchPhase.Moved ||
        //    Input.GetTouch(0).phase == TouchPhase.Began ||
        //    Input.GetTouch(0).phase == TouchPhase.Stationary))
        //{
        //    TouchPosition = Input.GetTouch(0).deltaPosition;
        //    transform.Translate(new Vector3(TouchPosition.x, TouchPosition.y, 0) * 0.1f);

        //    if (Time.time > nextFire)
        //    {
        //        nextFire = Time.time + fireRate;
        //        Instantiate(shot, new Vector3(playerPosition.x + 0.7f, playerPosition.y, -2), Quaternion.Euler(0, 0, 90));
        //    }
        //}
    }
}


