using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask obstacleLayer;

    private bool isMoving;
    CounterTime counterTime = new CounterTime();
    public CounterTime CounterTime => counterTime;

    private void Start()
    {
        OnInit();
    }
    public override void OnInit()
    {
        base.OnInit();
        StopMoving();
        skin.ChangeWeapon(TypeWeapon.W_Knife);
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
                counterTime.Cancel();
            }
            if (Input.GetMouseButton(0) && JoystickControl.direct != Vector3.zero)
            {
                Moving();
            }
            else
            {
                counterTime.Execute();
            }
            if (Input.GetMouseButtonUp(0))
            {
                StopMoving();
                OnAttack();
            }
        }
    }

    public override void OnAttack()
    {
        base.OnAttack();
        if(!isMoving && target != null && CanAttack)
        {
            counterTime.Start(Throw, TIME_DELAY_ATTACK);
            ResetAnim();
        }
    }

    private void Moving()
    {
        isMoving = true;
        rb.MovePosition(rb.position + JoystickControl.direct * speed * Time.deltaTime);
        TF.position = rb.position;
        TF.forward = JoystickControl.direct;
        ChangeAnim(Constant.ANIM_RUN);
    }
    public override void StopMoving()
    {
        base.StopMoving();
        isMoving = false;
        JoystickControl.direct = Vector3.zero;
        rb.velocity = Vector3.zero;
        ChangeAnim(Constant.ANIM_IDLE);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Constant.TAG_OBSTACLE))
        {
            StopMoving();
        }
    }
}
