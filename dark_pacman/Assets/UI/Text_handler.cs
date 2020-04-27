using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Text_handler : MonoBehaviour
{
    public TMP_Text level;
    public TMP_Text time;
    public TMP_Text highscore;
    public float time_left;

    // Update is called once per frame
    void Update()
    {
        time_left -= Time.deltaTime;
        level.text = FindObjectOfType<maze_gen_script>().level.ToString();
        time.text = ((int)time_left).ToString();
        highscore.text = FindObjectOfType<Score_saver>().highscore.ToString();
        if (time_left < 1)
            SceneManager.LoadScene("GameOver");
    }
}
