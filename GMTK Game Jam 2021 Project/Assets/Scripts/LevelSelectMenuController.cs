using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenuController : MonoBehaviour
{
    void Start()
    {
        AudioManagerScript.instance.StopSound("levelcomplete");
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void selectLevel(Button button)
    {
        SceneManager.LoadSceneAsync(button.name);
    }
}
