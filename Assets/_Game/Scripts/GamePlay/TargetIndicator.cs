using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetIndicator : GameUnit
{
    [SerializeField] TMP_Text textScore;
    [SerializeField] Image background;
    [SerializeField] Image arrow;

    public void OnInit(Color c, string score)
    {
        SetColorIndicator(c);
        SetScore(score);
    }
    public void SetColorIndicator(Color c)
    {
        background.color = c;
        arrow.color = c;
    }

    public void SetScore(string score)
    {
        textScore.text = score;
    }
}
