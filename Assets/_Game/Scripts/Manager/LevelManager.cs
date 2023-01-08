using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Level[] levels;
    [SerializeField] Player player;
    Level currentLevel;
    List<Bot> bots = new List<Bot>();

    public void OnInit()
    {

    }

    public void OnDespawn()
    {

    }
    private void LoadLevel(Level newLevel)
    {
        if (currentLevel != newLevel)
        {
            Destroy(currentLevel.gameObject);
        }
        currentLevel = newLevel;
        if(currentLevel != null)
        {
            currentLevel = Instantiate(currentLevel);
        }
    }

    public void ClearBot()
    {
        bots.Clear();
    }
}
