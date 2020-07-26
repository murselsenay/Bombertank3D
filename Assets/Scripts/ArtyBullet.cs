using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtyBullet : MonoBehaviour
{
    float distance;
    Vector3 direction;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        direction = target.position - transform.position;
        distance = Vector3.Distance(target.position, transform.position);
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,distance*2,0), ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
