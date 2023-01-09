using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : AbCharacter
{
    [SerializeField] protected float speed;
    [SerializeField] protected Skin skin;
    private string currentAnim;

    public override void OnInit()
    {
    }

    public override void OnDespawn()
    {
    }

    public override void StopMoving()
    {
    }

    public override void OnDeath()
    {
    }

    public override void OnAttack()
    {
    }
    public void ChangeAnim(string animName)
    {
        if(currentAnim!= animName)
        {
            skin.Anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            skin.Anim.SetTrigger(currentAnim);
        }
    }
}
