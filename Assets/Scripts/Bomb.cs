using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float counter;
    Vector3 newScale;

    public GameObject bombEffectPrefab;
    void Start()
    {
        newScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
    void Update()
    {
        counter += Time.deltaTime;
        if (Mathf.Round(counter) > 1 )
        {
            transform.localScale += newScale*Time.deltaTime;
            if (Mathf.Round(counter) > 2)
            {
                Instantiate(bombEffectPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    
}
