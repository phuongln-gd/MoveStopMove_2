using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask obstacleLayer;
    public Mask currentMask;

    CounterTime delayTime = new CounterTime();
    public CounterTime DelayTime => delayTime;

    public override void OnInit()
    {
        base.OnInit();
        score.SetColor(skin.ColorBody.material.color);
        score_int = 1;
        StopMoving();
        skin.ChangeWeapon(TypeWeapon.W_Boomerang);
        isAttacking = false;
        currentMask = null;
        SetSize(MIN_SIZE);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
    }
    private void Update()
    {
        if (!IsDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                delayTime.Cancel();
            }
            if (Input.GetMouseButton(0) && JoystickControl.direct != Vector3.zero)
            {
                Moving();
            }
            else
            {
                delayTime.Execute();
            }
            if (Input.GetMouseButtonUp(0))
            {
                StopMoving();
            }
            if(!isMoving && CanAttack)
            {
                if (!isAttacking)
                {
                    OnAttack();
                }
            }
            FindMaskInRange();
        }
    }

    public override void OnDeath()
    {
        base.OnDeath();
        if (currentMask != null)
        {
            currentMask.SetEnable(false);
        }
    }

    public override void AddTarget(Character target)
    {
        base.AddTarget(target);
    }

    public override void RemoveTarget(Character target)
    {
        base.RemoveTarget(target);
    }
    public override void OnAttack()
    {
        base.OnAttack();
        ResetAnim();
        if(target != null && CanAttack)
        {
            isAttacking = true;
            delayTime.Start(Throw, TIME_DELAY_ATTACK);
        }
    }

    public void FindMaskInRange()
    {
        Character targ = FindTargetInRange();
        if (targ != null)
        {
            SetMask((targ as Bot).MaskBot);
        }
        else
        {
            SetMask(null);
        }
    }
    private void Moving()
    {
        IsAttacking = false;
        isMoving = true;
        rb.MovePosition(rb.position + JoystickControl.direct * speed * Time.deltaTime);
        TF.position = rb.position;
        TF.forward = JoystickControl.direct;
        ChangeAnim(Constant.ANIM_RUN);
    }
    public override void StopMoving()
    {
        base.StopMoving();
        JoystickControl.direct = Vector3.zero;
        rb.velocity = Vector3.zero;
        ChangeAnim(Constant.ANIM_IDLE);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Constant.TAG_OBSTACLE)|| collision.collider.CompareTag(Constant.TAG_WALL))
        {
            StopMoving();
        }
    }

    public void SetMask(Mask maskTarget)
    {
        if(currentMask != null)
        {
            currentMask.SetEnable(false);
        }
        currentMask = maskTarget;
        if (maskTarget != null)
        {
            currentMask.SetEnable(true);
        }
    }
}
