using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopMessage : MonoBehaviour
{
    
    public Text popMessageText;
    public static PopMessage instance;
    // Start is called before the first frame update
    
    void Start()
    {
        instance = this;
        gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("CameraCanvas").transform);
        gameObject.transform.position = GameObject.FindGameObjectWithTag("CameraCanvas").transform.GetChild(3).transform.position;
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateText(string text)
    {
        popMessageText.text = text;
       
    }
  
}
