using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : GameUnit
{
    [SerializeField] Animator anim;
    public Animator Anim => anim;

    [SerializeField] SkinnedMeshRenderer colorBody;

    [SerializeField] Transform weaponPosition;
    
    public override void OnInit()
    {

    }

    public override void OnDespawn()
    {

    }

    public void ChangeColorBody(TypeColor color)
    {
        colorBody.material.color = GameManager.Instance.colorData.GetMaterialColor(color).color;
    }

    
}
