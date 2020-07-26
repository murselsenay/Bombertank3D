using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PowerUps : MonoBehaviour
{

    public bool bombRangeExtender;
    public bool speedUp;
    public bool bombCountExtender;
    public bool hasInfo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            if (bombRangeExtender)
            {
                Tank.bombRange = 0.6f;
                GameManager.instance.ShowPopMessage("Bomb range has been extended.");
                if (hasInfo)
                    GameManager.instance.ShowPanel(GameManager.instance.infoPanelPrefab,true,"This powerup extend \nthe range of the bomb \nby 1 unit.");
                Destroy(gameObject);
            }
            if (speedUp)
            {
                Tank.speed += 0.02f;
                GameManager.instance.ShowPopMessage("Tank speed has been insreased.");
                if (hasInfo)
                    GameManager.instance.ShowPanel(GameManager.instance.infoPanelPrefab, true, "This powerup increase \nthe speed of your \ntank by +1.");
                Destroy(gameObject);

            }
            if (bombCountExtender)
            {
                Tank.droppableBombCount += 1;
                GameManager.instance.UpdateBombCountUIText(Tank.droppableBombCount.ToString());
                GameManager.instance.ShowPopMessage("Droppable bomb count\n has been increased to " + Tank.droppableBombCount);
                if (hasInfo)
                    GameManager.instance.ShowPanel(GameManager.instance.infoPanelPrefab, true, "This powerup increase \ndroppable bomb count \nby +1.");
                Destroy(gameObject);
            }
        }
    }
}
