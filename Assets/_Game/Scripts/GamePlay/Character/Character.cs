using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Character : AbCharacter,IHit
{
    public static float TIME_DELAY_ATTACK = 0.3f;
    public static float ATTACK_RANGE = 5f;

    public static float MAX_SIZE = 4F;
    public static float MIN_SIZE = 1F;

    [SerializeField] protected float speed;
    [SerializeField] protected Skin skin;

    public Skin SkinCharacter => skin;
    private string currentAnim;
    private bool isDead;
    public bool IsDead => isDead;

    private List<Character> targets = new List<Character>();
    public List<Character> Targets => targets;
    protected Character target;
    private Vector3 targetPosition;

    [SerializeField] Transform weakPoint;
    public Transform WeakPoint => weakPoint;
    public bool CanAttack => skin.CurrentWeapon.IsCanAttack;

    [SerializeField] protected Score score;
    public int score_int = 1;
    
    protected float size = 1f;
    public float Size => size;

    protected bool isMoving, isAttacking;

    public bool IsAttacking
    {
        get { return isAttacking; }
        set { isAttacking = value; }
    }
    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }
    public override void OnInit()
    {
        isDead = false;
    }

    public override void OnDespawn()
    {
    }

    public override void StopMoving()
    {
        isMoving = false;
    }

    public override void OnDeath()
    {
        ChangeAnim(Constant.ANIM_DEAD);
        LevelManager.Instance.CharacterDeath(this);
    }

    public void SetSize(float newSize)
    {
        newSize = Mathf.Clamp(newSize, MIN_SIZE, MAX_SIZE);
        size = newSize;
        TF.localScale = size * Vector3.one;
    }

    public virtual void Throw()
    {
        skin.CurrentWeapon.Throw(this,targetPosition,size);
    }

    public override void OnAttack()
    {
        target = FindTargetInRange();
        if (target != null && CanAttack && !target.isDead && !isMoving)
        {
            targetPosition = target.weakPoint.position;
            TF.LookAt(target.TF.position + (TF.position.y - target.TF.position.y) * Vector3.up);
            ChangeAnim(Constant.AMIM_ATTACK);
            Debug.Log("sfsafsa");
        }
    }

    public void SetScore(int newScore)
    {
        score_int += newScore;
        score.SetScore(score_int);
        SetSize(1 + score_int * 0.05f);
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

    public void ClearTarget()
    {
        targets.Clear();
    }
    public Character FindTargetInRange()
    {
        Character character = null;
        float distance = float.PositiveInfinity;
        for(int i = 0; i< targets.Count; i++)
        {
            float dis = Vector3.Distance(TF.position, targets[i].TF.position);
            if (targets[i] != null && targets[i] != this && !targets[i].isDead && dis <= ATTACK_RANGE * size + targets[i].size)
            {
                if (dis < distance)
                {
                    distance = dis;
                    character = targets[i];
                }
            }
        }
        return character;
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

    public void OnHit(UnityAction hitAction)
    {
        if (!isDead)
        {
            isDead = true;
            if(hitAction != null)
            {
                hitAction.Invoke();
            }
            OnDeath();
        }
    }
}
