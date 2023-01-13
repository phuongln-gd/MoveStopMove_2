using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    private IState<Bot> currentState;
    [SerializeField] NavMeshAgent agent;

    private CounterTime delayTime = new CounterTime();
    public CounterTime DelayTime => delayTime;

    private Vector3 destination;
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public override void OnInit()
    {
        base.OnInit();
        RandomItem();
        bool t = Utilities.Chance(50, 100);
        if (t)
        {
            ChangeState(new IdleState());
        }
        else
        {
            ChangeState(new PatronState());
        }
        StopMoving();
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
    }

    public override void StopMoving()
    {
        base.StopMoving();
        agent.enabled = false;
        ChangeAnim(Constant.ANIM_IDLE);
    }

    public void RandomItem()
    {
        skin.ChangeColorBody(Utilities.RandomEnumValue<TypeColor>());
        ChangeWeapon();
    }
    public void ChangeWeapon()
    {
        skin.ChangeWeapon(Utilities.RandomEnumValue<TypeWeapon>());
        //skin.CurrentWeapon.SetMeshRenderer
          //  (GameManager.Instance.SkinWeaponData.GetMaterial(skin.CurrentWeapon.Type,
            //Random.Range(0, GameManager.Instance.SkinWeaponData.GetSkinAmount(skin.CurrentWeapon.Type))));
    }
    public bool IsDestination => Vector3.Distance(TF.position.x * Vector3.right + TF.position.z * Vector3.forward
        , destination.x * Vector3.right + destination.z * Vector3.forward) < 0.1f;
    public void SetDestination(Vector3 pos)
    {
        destination = pos;
        agent.enabled = true;
        agent.SetDestination(destination);
        ChangeAnim(Constant.ANIM_RUN);
    }
   
    public void ChangeState(IState<Bot> newState)
    {
        if(currentState != newState && currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnTer(this);
        }
    }
}
