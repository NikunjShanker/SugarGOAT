using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;
    [SerializeField] private Button muteButton;

    void Update()
    {
        if (AudioManagerScript.instance.mute)
        {
            muteButton.GetComponent<Image>().sprite = musicOff;
        }
        else
        {
            muteButton.GetComponent<Image>().sprite = musicOn;
        }
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Mute()
    {
        AudioManagerScript.instance.mute = !AudioManagerScript.instance.mute;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
