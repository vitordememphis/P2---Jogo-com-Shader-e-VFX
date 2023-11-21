using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void SelectNone()
    {
        if (GameManager.instance.playerShape == 0)
        {
            GameManager.instance.playerShape = 1;
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MenuScene");
    }


}
