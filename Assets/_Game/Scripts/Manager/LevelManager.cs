using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] Level[] levels;
    public Player player;
    Level currentLevel;
    public Level CurrentLevel => currentLevel;
    public void Start()
    {
        LoadLevel(0);
        OnInit();
    }
    public void OnInit()
    {
        player.OnInit();
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
