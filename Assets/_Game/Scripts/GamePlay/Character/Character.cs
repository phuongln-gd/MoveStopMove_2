using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : AbCharacter
{
    public static float TIME_DELAY_ATTACK = 0.4f;
    public static float ATTACK_RANGE = 5f;

    [SerializeField] protected float speed;
    [SerializeField] protected Skin skin;
    private string currentAnim;
    private bool isDead;
    public bool IsDead => isDead;

    private List<Character> targets = new List<Character>();
    protected Character target;
    private Vector3 targetPosition;

    public bool CanAttack => skin.CurrentWeapon.IsCanAttack;

    protected float size = 1f;
    public override void OnInit()
    {
        isDead = false;
    }

    public override void OnDespawn()
    {
    }

    public override void StopMoving()
    {
    }

    public override void OnDeath()
    {
        isDead = true;
        ChangeAnim(Constant.ANIM_DEAD);
    }

    public void Throw()
    {
        skin.CurrentWeapon.Throw(this,targetPosition,size);
    }

    public override void OnAttack()
    {
        target = null;
        target = FindTargetInRange();
        if(target!= null && !target.IsDead && CanAttack)
        {
            targetPosition = target.TF.position;
            TF.LookAt(targetPosition + (TF.position.y - target.TF.position.y) * Vector3.up);
            ChangeAnim(Constant.AMIM_ATTACK);
        }
    }

    public void ResetAnim()
    {
        currentAnim = "";
    }
    public virtual void AddTarget(Character target)
    {
        targets.Add(target);
    }

    public virtual void RemoveTarget(Character target)
    {
        targets.Remove(target);
        this.target = null;
    }
    private Character FindTargetInRange()
    {
        Character rs = null;
        float distance = float.PositiveInfinity;
        for(int i =0; i < targets.Count; i++)
        {
            if (targets[i] != null && !targets[i].IsDead
                && Vector3.Distance(TF.position, targets[i].TF.position) < ATTACK_RANGE)
            {
                float dis = Vector3.Distance(TF.position, targets[i].TF.position);
                if(dis < distance)
                {
                    distance = dis;
                    rs = targets[i];
                }
            }
        }
        return rs;
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
