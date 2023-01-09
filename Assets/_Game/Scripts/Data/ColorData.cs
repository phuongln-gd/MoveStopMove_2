using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeColor
{
    Green, Cyan, Yellow, Red, Black, Orange, Blue
}

[CreateAssetMenu(fileName = "Color",menuName ="ScripttableObject/Color")]
public class ColorData : ScriptableObject
{
    [SerializeField] List<Material> materials;

    public Material GetMaterialColor(TypeColor color)
    {
        return materials[(int)color];
    }
}
