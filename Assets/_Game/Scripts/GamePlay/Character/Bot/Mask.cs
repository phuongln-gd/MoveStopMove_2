using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    [SerializeField] GameObject child;

    public void SetEnable(bool flag)
    {
        child.SetActive(flag);
    }
}
