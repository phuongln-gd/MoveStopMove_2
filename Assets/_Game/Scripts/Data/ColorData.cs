using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Color",menuName ="ScripttableObject/Color")]
public class ColorData : ScriptableObject
{
    [SerializeField] List<Material> materials;

    public Material GetMaterialColor(TypeColor color)
    {
        return materials[(int)color];
    }
}
