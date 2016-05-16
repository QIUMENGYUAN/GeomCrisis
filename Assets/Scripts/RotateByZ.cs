using UnityEngine;
using System.Collections;

public class RotateByZ : MonoBehaviour
{
    public float rotateSpeed;
    void Update() 
    {
        transform.Rotate(Vector3.forward * rotateSpeed, Space.World);    //Rotate By Z
        //transform.Rotate(Vector3.right * rotateSpeed, Space.World);      //Rotate By X
        //transform.Rotate(Vector3.up * rotateSpeed, Space.World);         //Rotate By Y

        
	}
}
