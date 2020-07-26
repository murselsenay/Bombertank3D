using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crackable : MonoBehaviour
{
    public int hitCount = 1;
    bool _canDamage=true;
    // Start is called before the first frame update
    void Start()
    {
        if (hitCount==2)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.3f, 0.4f, 0.6f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnParticleCollision(GameObject other)
    {
        if (_canDamage)
        {
            hitCount -= 1;
            _canDamage = false;
            StartCoroutine(canDamage());
        }
        if (hitCount<=0)
        {
            
            GameManager.instance.achs[0] -= 1;
            GameManager.instance.UpdateAchTexts();
            //Debug.Log(GameManager.instance.achs[0].ToString());
            Destroy(gameObject);
        }
     
    }
    public IEnumerator canDamage()
    {
        yield return new WaitForSeconds(2);
        _canDamage = true;
    }
}
