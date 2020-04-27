using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_saver : MonoBehaviour
{
    public int level;
    public int highscore;
    void Start()
    {
        DontDestroyOnLoad(gameObject.transform);
    }

    void Update()
    {
        if (level > highscore)
            highscore = level;
    }
}
