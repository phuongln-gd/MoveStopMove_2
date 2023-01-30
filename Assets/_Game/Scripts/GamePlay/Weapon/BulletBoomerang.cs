using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoomerang : Bullet
{
    public enum State { forward, backward, Stop }
    State currentState;
    private Vector3 target;
    public override void OnInit(Character character, Vector3 target, Weapon weapon, float size)
    {
        base.OnInit(character, target,weapon,size);
        this.target = (target - character.TF.position).normalized
            * (Character.ATTACK_RANGE + 1)  + character.TF.position;
        currentState = State.forward;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.forward:
                TF.position = Vector3.MoveTowards(TF.position, target, speed * Time.deltaTime);
                child.RotateAround(child.position, Vector3.up, 540 * Time.deltaTime);
                if (Vector3.Distance(TF.position,target) < 0.1f)
                {
                    currentState = State.backward;
                }
                break;
            case State.backward:
                TF.position = Vector3.MoveTowards(TF.position, character.TF.position, speed * Time.deltaTime);
                child.RotateAround(child.position, Vector3.up, 540 * Time.deltaTime);
                if (Vector3.Distance(TF.position, character.TF.position) < 0.1f || character.IsDead)
                {
                    OnDespawn();
                }
                break;
            case State.Stop:
                break;
        }
    }

    protected override void OnStop()
    {
        base.OnStop();
        currentState = State.Stop;
        Invoke(nameof(OnDespawn), 0.5f);
    }
}
