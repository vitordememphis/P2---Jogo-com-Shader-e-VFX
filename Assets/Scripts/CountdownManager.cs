using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour
{
    int timerInt;
    public TextMeshProUGUI timerText;

    public GameObject gameOverText;
    public GameObject PlayAgainButton;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.timer = 30;
        GameManager.instance.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.timer = GameManager.instance.timer - Time.deltaTime;
        timerInt = Mathf.RoundToInt(GameManager.instance.timer);
        timerText.text = "Tempo: " + timerInt.ToString("00");

        if (timerInt <= 0)
        {
            GameManager.instance.timer = 0;
            GameOver();
        }
    }


    void GameOver()
    {
        if(GameManager.instance.timer <= 0)
        {
            gameOverText.SetActive(true);
            PlayAgainButton.SetActive(true);
        }
    }
}
