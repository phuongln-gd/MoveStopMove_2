using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotate : Bullet
{
    public const float ALIVE_TIME = 1f;
    [SerializeField] Transform child;
    CounterTime counterTime = new CounterTime();

    public override void OnInit(Character character, Vector3 target, float size)
    {
        base.OnInit(character, target, size);
        TF.forward = (target - TF.position).normalized;
        counterTime.Start(OnDespawn, ALIVE_TIME);
    }

    private void Update()
    {
        counterTime.Execute();
        if (isRunning)
        {
            TF.Translate(TF.forward * speed * Time.deltaTime, Space.World);
            child.Rotate(Vector3.up * -6f, Space.Self);
        }
    }

    protected override void OnStop()
    {
        base.OnStop();
        isRunning = false;
    }
}
