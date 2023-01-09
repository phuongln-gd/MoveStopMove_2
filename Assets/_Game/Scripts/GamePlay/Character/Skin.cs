using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] Animator anim;
    public Animator Anim => anim;

    [SerializeField] SkinnedMeshRenderer colorBody;

    public void ChangeColorBody(TypeColor color)
    {
        colorBody.material.color = GameManager.Instance.colorData.GetMaterialColor(color).color;
    }
}
