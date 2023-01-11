using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinWeapon", menuName = "ScripttableObject/SkinWeapon")]
public class SkinWeaponData : ScriptableObject
{
    [SerializeField]WeaponType[] weapons;

    public int GetSkinAmount(TypeWeapon type)
    {
        return weapons[(int)type-2].materials.Length;
    }
    public Material GetMaterial(TypeWeapon weaponType, int index)
    {
        Debug.Log(weapons[(int)weaponType - 2].materials[index].name);
        return weapons[(int)weaponType - 2].materials[index];
    }

   
}

[System.Serializable]
public class WeaponType
{
    public TypeWeapon type;
    public Material[] materials;
}