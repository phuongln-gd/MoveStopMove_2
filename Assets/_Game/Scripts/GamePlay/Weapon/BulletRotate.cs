using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotate : Bullet
{
    public const float ALIVE_TIME = 1f;
    CounterTime counterTime = new CounterTime();

    public override void OnInit(Character character, Vector3 target, Weapon weapon)
    {
        base.OnInit(character, target, weapon);
        TF.forward = (target - TF.position).normalized;
        counterTime.Start(OnDespawn, ALIVE_TIME);
    }

    private void Update()
    {
        counterTime.Execute();
        if (isRunning)
        {
            TF.Translate(TF.forward * speed * Time.deltaTime, Space.World);
            child.RotateAround(child.position, Vector3.up, 540 * Time.deltaTime);
        }
    }

    protected override void OnStop()
    {
        base.OnStop();
        isRunning = false;
    }
}
