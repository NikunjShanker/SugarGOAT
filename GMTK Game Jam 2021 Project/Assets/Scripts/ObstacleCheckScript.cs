using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCheckScript : MonoBehaviour
{
    public PlayerScript ps;
    
    private bool blockDetected;

    private GameObject blockObject;
    private string blockObjectTag;

    void Start()
    {
        blockDetected = false;
        ps = GameObject.Find("Player Goat").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if(ps.type==blockObjectTag && blockDetected)
        {
            if(Input.GetMouseButtonDown(0))
            {
                AudioManagerScript.instance.PlaySound("bite");
                ScreenShakeScript.instance.shakeCamera(0.5f, 0.1f);
                Destroy(blockObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int length = collision.gameObject.name.Length;
        if(length > 7)
        {
            if (collision.gameObject.name.Substring(length - 5, 5) == "Block")
            {
                blockDetected = true;
                blockObject = collision.gameObject;
                blockObjectTag = blockObject.tag;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Red" || collision.gameObject.tag == "Blue" || collision.gameObject.tag == "Green" || collision.gameObject.tag == "Purple")
        {
            blockObject = null;
            blockObjectTag = "";
            blockDetected = false;
        }
    }
}
