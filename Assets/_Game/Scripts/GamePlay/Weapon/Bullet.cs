using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameUnit
{
    protected Character character;
    [SerializeField] protected float speed = 9f;
    protected bool isRunning;
    public override void OnInit()
    {
    }
    public override void OnDespawn()
    {
        SimplePool.Despawn(this);
    }

    public virtual void OnInit(Character character,Vector3 target)
    {
        this.character = character;
        TF.forward = (target - TF.position).normalized;
        isRunning = true;
    }
    protected virtual void OnStop()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {
            Debug.Log("kill C");
            OnDespawn();
        }
        if (other.CompareTag(Constant.TAG_OBSTACLE))
        {
            OnStop();
        }
    }
}
