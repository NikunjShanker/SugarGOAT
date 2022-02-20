using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public UIControllerScript uiCS;

    void Start()
    {
        uiCS = GameObject.Find("UI Controller").GetComponent<UIControllerScript>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            uiCS.portalReached();
            collision.gameObject.SetActive(false);
        }
    }
}
