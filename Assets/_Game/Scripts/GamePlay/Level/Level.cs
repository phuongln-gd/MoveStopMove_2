using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int totalBot; // tong so luong bot trong 1 level
    [SerializeField] int maxBot; // so luong bot toi da suot hien trong 1 thoi diem 
    [SerializeField] int aliveBot; // so luong bot thuc te trong khi choi
    public int TotalBot => totalBot;
    public int MaxBot => maxBot;
    public int AliveBot => aliveBot;
}
