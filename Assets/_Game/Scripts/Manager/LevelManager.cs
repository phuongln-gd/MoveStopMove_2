using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Level[] levels;
    [SerializeField] Player player;
    Level currentLevel;

    public void Start()
    {
        LoadLevel(0);
    }
    public void OnInit()
    {

    }

    public void OnDespawn()
    {

    }
    private void LoadLevel(int index)
    {
        if (currentLevel != levels[index] && currentLevel != null)
        {
            currentLevel.OnDespawn();
            Destroy(currentLevel.gameObject);
        }
        currentLevel = levels[index];
        if(currentLevel != null)
        {
            currentLevel = Instantiate(currentLevel);
            currentLevel.OnInit();
        }
    }
}
