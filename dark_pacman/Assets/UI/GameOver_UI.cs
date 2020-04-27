using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver_UI : MonoBehaviour
{

    public TMP_Text score;
    public TMP_Text highscore;

    void Start()
    {
        score.text = FindObjectOfType<Score_saver>().level.ToString();
        highscore.text = FindObjectOfType<Score_saver>().highscore.ToString();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
