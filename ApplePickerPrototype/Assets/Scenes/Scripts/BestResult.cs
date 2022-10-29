using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestResult : MonoBehaviour
{
    private void Update()
    {
        Text record = this.GetComponent<Text>();
        record.text = "Best result:" + HighScore.score;
        if (HighScore.score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("Best result", HighScore.score);
        }
    }
}
 