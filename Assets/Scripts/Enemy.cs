using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 0f;
    private Rigidbody rb;
    public Vector3 dir;
    public LayerMask isObstacle;
    bool canUpdate = true;
    public float maxDistanceFromWall = 0f;



    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = ChooseDirection(randomNumber());
        transform.rotation = Quaternion.LookRotation(dir);

    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = dir * moveSpeed;

        if (Physics.Raycast(transform.position, transform.forward, 0.8f, isObstacle) && Physics.Raycast(transform.position, transform.right, 0.8f, isObstacle) && Physics.Raycast(transform.position, -transform.right, 0.8f, isObstacle))
        {
            
            dir = ChooseDirection(1);
            transform.rotation = Quaternion.LookRotation(dir);
            //Debug.Log("close");
        }
        if (Physics.Raycast(transform.position, transform.forward, maxDistanceFromWall, isObstacle))
        {
            
            dir = ChooseDirection(randomNumber());
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
         
    int randomNumber()
    {
        System.Random rnd = new System.Random();
        int i = rnd.Next(0, 3);
        return i;
    }

    Vector3 ChooseDirection(int d)
    {

        Vector3 temp = new Vector3();
        if (d == 0)
        {
            temp = transform.forward;
        }
        else if (d == 1)
        {
            temp = -transform.forward;
        }
        else if (d == 2)
        {
            temp = transform.right;
        }
        else if (d == 3)
        {
            temp = -transform.right;
        }
        return temp;
    }

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("triggered");
        if (other.gameObject.tag=="BombEffect")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (canUpdate)
            {
                GameManager.instance.achs[1] -= 1;
                GameManager.instance.UpdateAchTexts();
                canUpdate = false;
            }

        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="EnemyTank")
        {
            dir = ChooseDirection(1);
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}
