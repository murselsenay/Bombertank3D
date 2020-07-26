using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform targetObj;
    public float speed = 0.125f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (targetObj!=null)
        {
            Vector3 pos = targetObj.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, pos, speed);
            transform.position = smoothPos;
        }
       
    }
}
