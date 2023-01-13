using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameUnit : MonoBehaviour
{
    private Transform tf;
    public Transform TF
    {
        get
        {
            // if tf == null, set tf =  gameObject.transform
            tf = tf ?? gameObject.transform;
            return tf;
        }
    }

    public PoolType poolType;
}