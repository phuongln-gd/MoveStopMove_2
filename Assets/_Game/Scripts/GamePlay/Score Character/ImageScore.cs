using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageScore : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text textScore;

    public void SetColor(Color c)
    {
        image.color = c;
    }

    public void SetScore(int newScore)
    {
        textScore.text = newScore.ToString();
    }
}
