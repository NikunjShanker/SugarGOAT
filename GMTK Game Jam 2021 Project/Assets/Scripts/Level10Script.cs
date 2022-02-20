using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level10Script : MonoBehaviour
{
    public PlayerScript ps;

    [SerializeField] private TextMeshProUGUI topText;
    [SerializeField] private TextMeshProUGUI killCountText;
    public bool overrideText = false;

    void Start()
    {
        ps = GameObject.Find("Player Goat").GetComponent<PlayerScript>();

        topText.text = "- Secret Goat Warehouse -";
        killCountText.text = "Level 10?";
        topText.fontSize = 40;
    }

    void Update()
    {
        if(ps.goatDeathCount == 1)
        {
            topText.text = "Nice Kill!";
        }
        else if (ps.goatDeathCount == 2)
        {
            topText.text = "Double Kill!";
        }
        else if (ps.goatDeathCount == 3)
        {
            topText.text = "Triple Kill!";
        }
        else if (ps.goatDeathCount == 4)
        {
            topText.text = "Super Kill!";
        }
        else if (ps.goatDeathCount == 5)
        {
            topText.text = "Mega Kill!";
        }
        else if (ps.goatDeathCount == 6)
        {
            topText.text = "Frenzy Kill!";
        }
        else if (ps.goatDeathCount == 8)
        {
            topText.text = "MONSTER KILL!";
            topText.fontSize = 45;
        }
        else if (ps.goatDeathCount == 10)
        {
            topText.text = "MERCILESS!";
        }
        else if (ps.goatDeathCount == 12)
        {
            topText.text = "RUTHLESS!";
        }
        else if (ps.goatDeathCount == 14)
        {
            topText.text = "BRUTAL!!";
            topText.fontSize = 50;
        }
        else if (ps.goatDeathCount == 16)
        {
            topText.text = "NUCLEAR!!";
            topText.fontSize = 51;
        }
        else if (ps.goatDeathCount == 18)
        {
            topText.text = "UNSTOPPABLE!!";
            topText.fontSize = 52;
        }
        else if (ps.goatDeathCount == 20)
        {
            topText.fontSize = 53;
            topText.text = "GODLIKE!!";
        }
        else if (ps.goatDeathCount == 22)
        {
            topText.fontSize = 54;
            topText.text = "LITERAL DEMON-SPAWN!!";
        }
        else if (ps.goatDeathCount == 24)
        {
            topText.fontSize = 60;
            topText.text = "!! ABSOLUTE KILLING MACHINE !!";
            killCountText.text = "Satan would like to speak with you";
            AudioManagerScript.instance.PlaySound("levelcomplete");
            StartCoroutine(removeText());
        }

        if(ps.goatDeathCount != 0 && ps.goatDeathCount != 24)
        {
            killCountText.text = "Kill Count: " + ps.goatDeathCount;
        }

        if(overrideText)
        {
            killCountText.text = "";
            topText.text = "";
        }
    }

    IEnumerator removeText()
    {
        yield return new WaitForSeconds(7f);
        ps.goatDeathCount = 0;
        killCountText.text = "";
        topText.text = "";
    }
}
