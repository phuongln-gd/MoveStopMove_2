using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_BULLET))
        {
            Bullet bullet = Cache.GetBullet(other);
            bullet.StopBullet();
        }
    }
}
