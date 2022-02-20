using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIControllerScript : MonoBehaviour
{
    public PlayerScript ps;
    public Level10Script lc;

    [SerializeField] public TextMeshProUGUI panelText;

    private GameObject panel;
    public bool objectiveFinished;

    private float levelNum;

    void Start()
    {
        AudioManagerScript.instance.StopSound("levelcomplete");
        objectiveFinished = false;
        ps = GameObject.Find("Player Goat").GetComponent<PlayerScript>();

        if(SceneManager.GetActiveScene().name == "Level 10")
        {
            lc = GameObject.Find("Level 10 Controller").GetComponent<Level10Script>();
        }
        else
        {
            lc = null;
        }

        GameObject mainC = GameObject.Find("Main Canvas").gameObject;
        panel = mainC.transform.Find("Panel").gameObject;

        panelText.text = "Game Paused";
    }

    void Update()
    {
        if(objectiveFinished)
            AudioManagerScript.instance.PlaySound("levelcomplete");
    }

    public void pauseButton()
    {
        if (SceneManager.GetActiveScene().name == "Level 10")
        {
            lc.overrideText = true;
        }

        panel.SetActive(true);
        ps.moveEnabled = false;
    }

    public void resumeButton()
    {
        if(objectiveFinished)
        {
            findLevelNum();
            levelNum++;
            SceneManager.LoadSceneAsync("Level " + levelNum);
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Level 10")
            {
                lc.overrideText = false;
            }
            ps.moveEnabled = true;
            panel.SetActive(false);
        }
    }

    public void mainMenuButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void portalReached()
    {
        panelText.text = "Level Complete";
        objectiveFinished = true;
        panel.SetActive(true);
        ps.moveEnabled = false;
    }

    private void findLevelNum()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            levelNum = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            levelNum = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            levelNum = 3.3f;
        }
        else if (SceneManager.GetActiveScene().name == "Level 4.3")
        {
            levelNum = 4.3f;
        }
        else if (SceneManager.GetActiveScene().name == "Level 5.3")
        {
            levelNum = 5.3f;
        }
        else if (SceneManager.GetActiveScene().name == "Level 6.3")
        {
            levelNum = 6;
        }
        else if (SceneManager.GetActiveScene().name == "Level 7")
        {
            levelNum = 7;
        }
        else if (SceneManager.GetActiveScene().name == "Level 8")
        {
            levelNum = 8;
        }
        else if (SceneManager.GetActiveScene().name == "Level 9")
        {
            levelNum = 9;
        }
    }
}
