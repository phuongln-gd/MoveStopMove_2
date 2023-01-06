using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Transform tf;
    [SerializeField] protected float speed;

    [SerializeField] Animator anim;

    private string currentAnim;

    public virtual void OnInit()
    {
        ChangeAnim(Constant.ANIM_IDLE);
    }

    public virtual void OnDespawn()
    {

    }
    public void ChangeAnim(string animName)
    {
        if(currentAnim!= animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
}
