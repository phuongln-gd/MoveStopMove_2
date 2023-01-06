using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T>
{
    public void OnEnTer(T t);   
    public void OnExecute(T t);
    public void OnExit(T t);

}
