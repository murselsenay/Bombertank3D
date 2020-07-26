using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class Tank : MonoBehaviour
{

    Rigidbody rb;
    bool isVertical;
    internal static float speed = 0.04f;
    public GameObject bombPrefab;
    internal static float bombRange = 0.4f;
    public GameObject explosionPrefab;
    public bool canDrop = true;



    public static int droppableBombCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
#if UNITY_EDITOR
        if (Input.GetAxisRaw("Vertical") > 0f && Input.GetAxisRaw("Horizontal") == 0)
        {
            transform.Translate(Vector3.forward * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxisRaw("Vertical") < 0f && Input.GetAxisRaw("Horizontal") == 0)
        {
            transform.Translate(Vector3.forward * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxisRaw("Horizontal") > 0f && Input.GetAxisRaw("Vertical") == 0)
        {
            transform.Translate(Vector3.forward * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0f && Input.GetAxisRaw("Vertical") == 0)
        {
            transform.Translate(Vector3.forward * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && droppableBombCount > 0)
        {
            Instantiate(bombPrefab, new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z)), Quaternion.identity);
            droppableBombCount--;
            GameObject insPopMessage = Instantiate(GameManager.instance.popMessagePrefab);
            GameManager.instance.UpdateBombCountUIText(droppableBombCount.ToString());
            insPopMessage.GetComponent<PopMessage>().UpdateText(droppableBombCount.ToString() + " bomb left.");
        }

#endif
#if UNITY_ANDROID
        if (CrossPlatformInputManager.GetAxisRaw("Vertical") > 0f && CrossPlatformInputManager.GetAxisRaw("Horizontal") == 0)
        {
            transform.Translate(Vector3.forward * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (CrossPlatformInputManager.GetAxisRaw("Vertical") < 0f && CrossPlatformInputManager.GetAxisRaw("Horizontal") == 0)
        {
            transform.Translate(Vector3.forward * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") > 0f && CrossPlatformInputManager.GetAxisRaw("Vertical") == 0)
        {
            transform.Translate(Vector3.forward * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") < 0f && CrossPlatformInputManager.GetAxisRaw("Vertical") == 0)
        {
            transform.Translate(Vector3.forward * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (CrossPlatformInputManager.GetButtonDown("Bomb") && droppableBombCount > 0)
        {
            if (canDrop)
            {
                Instantiate(bombPrefab, new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z)), Quaternion.identity);
                droppableBombCount -= 1;
                canDrop = false;
                GameObject insPopMessage = Instantiate(GameManager.instance.popMessagePrefab);
                GameManager.instance.UpdateBombCountUIText(droppableBombCount.ToString());
                insPopMessage.GetComponent<PopMessage>().UpdateText(droppableBombCount.ToString() + " bomb left.");
            }

        }
        if (CrossPlatformInputManager.GetButtonUp("Bomb"))
        {
            if (!canDrop)
            {
                canDrop = true;
            }

        }

#endif




    }
    void OnParticleCollision(GameObject other)
    {
        DestroyTank();


    }

    public void DestroyTank()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameManager.instance.GameOverScreen();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyTank")
        {

            GameManager.instance.ShowPopMessage("You have been destroyed by an enemy tank.");
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            DestroyTank();


        }
    }

}
