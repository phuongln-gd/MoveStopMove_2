using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IHit 
{
    public void OnHit(UnityAction hitAction);
}
