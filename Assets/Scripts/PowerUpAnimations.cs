using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnimations : MonoBehaviour
{
    public float speed = 100f;
    public bool rotate;
    public bool bounce;
    public bool rotateLeftToRight;
    private Vector3 startPosition;

    private bool canBounce = true;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (rotate)
        {
            transform.Rotate(speed * Time.deltaTime, 0, speed * Time.deltaTime);
        }
        if (bounce)
        {
            if (transform.position.y <= startPosition.y + 0.5f && canBounce)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
            else
            {
                canBounce = false;
            }
            if (transform.position.y >= startPosition.y && !canBounce)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);

            }
            else
            {
                canBounce = true;
            }

        }

    }
}
