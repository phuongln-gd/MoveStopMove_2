using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : GameUnit
{
    [SerializeField] Name nameText;
    [SerializeField] ImageScore imageScore;

    private void LateUpdate()
    {
        TF.LookAt(TF.position + GameManager.Instance.GamePlayCamera.transform.forward);
    }

    public void SetColor(Color c)
    {
        nameText.SetColor(c);
        imageScore.SetColor(c);
    }

    public void SetScore(int newScore)
    {
        imageScore.SetScore(newScore);
    }
}
