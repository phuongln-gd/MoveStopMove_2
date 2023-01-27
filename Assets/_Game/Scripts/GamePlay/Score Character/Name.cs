using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Name : MonoBehaviour
{
    [SerializeField] TMP_Text text_name; 

    public void SetColor(Color c)
    {
        text_name.color = c;
    }

    public void ChangeName(string name)
    {
        text_name.text = name;
    }
}
