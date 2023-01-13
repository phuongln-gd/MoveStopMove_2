using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameUnit
{
    protected Character character;
    [SerializeField] protected float speed = 9f;
    protected bool isRunning;
    [SerializeField] protected Transform child;
    protected Weapon weapon;
    public virtual void OnDespawn()
    {
        SimplePool.Despawn(this);
        weapon.SetEnable();
    }

    public virtual void OnInit(Character character,Vector3 target,Weapon weapon)
    {
        this.character = character;
        this.weapon = weapon;
        TF.forward = (target - TF.position).normalized;
        isRunning = true;
    }
    protected virtual void OnStop()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag(Constant.TAG_OBSTACLE))
        {
            OnStop();
        }
        if (other.CompareTag(Constant.TAG_CHARACTER))
        {

        }*/
    }
}
