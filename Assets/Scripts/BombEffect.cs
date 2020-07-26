using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{

    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;

    // Start is called before the first frame update
    void Start()
    {
        var main1 = ps1.main;
        var main2 = ps2.main;
        var main3 = ps3.main;
        var main4 = ps4.main;
        main1.startLifetime = Tank.bombRange;
        main2.startLifetime = Tank.bombRange;
        main3.startLifetime = Tank.bombRange;
        main4.startLifetime = Tank.bombRange;
        Tank.droppableBombCount += 1;
        GameManager.instance.UpdateBombCountUIText(Tank.droppableBombCount.ToString());
        GameManager.instance.ShowPopMessage(Tank.droppableBombCount.ToString() + " bomb left.");
        Destroy(gameObject, 1.2f);
        
    }

    // Update is called once per frame
    void Update()
    {
      
       
    }
    
}
