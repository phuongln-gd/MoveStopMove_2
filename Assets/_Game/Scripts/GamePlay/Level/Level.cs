using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    [SerializeField] int totalBot; // tong so luong bot trong 1 level
    [SerializeField] int maxBot; // so luong bot toi da suot hien trong 1 thoi diem 
    [SerializeField] int spawnBot; // so luong bot da duoc sinh ra
    public int TotalBot => totalBot;
    public int MaxBot => maxBot;
    public int SpawnBot => spawnBot;

    [SerializeField] Transform minPoint, maxPoint;

    List<Bot> bots = new List<Bot>();

    public List<Bot> Bots => bots;

    private int CurrentBot => bots.Count;

    private void Update()
    {
        
    }
    public void OnInit()
    {
        // spawn bot
        for(int i = 0; i < maxBot; i++)
        {
            NewBot();
        }
    }

    public void OnDespawn()
    {
        ClearBot();
    }

    public void NewBot()
    {
        if(spawnBot < totalBot)
        {
            Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot, RandomSpawnPoint(), Quaternion.identity);
            bot.OnInit();
            bots.Add(bot);
            spawnBot +=  1;
        }
    }

    public Vector3 RandomSpawnPoint()
    {
        Vector3 randPoint = Vector3.zero;
        float size = 10f;
        for(int i = 0; i < 30; i++)
        {
            randPoint = RandomPoint();
            if (Vector3.Distance(randPoint,LevelManager.Instance.player.TF.position) < size)
            {
                continue;
            }
            for(int j = 0; j < 20; j++)
            {
                for(int k =0; k< bots.Count; k++)
                {
                    if (Vector3.Distance(randPoint, bots[k].TF.position) < size)
                    {
                        break;
                    }
                }
                if (j == 19)
                {
                    return randPoint;
                }
            }
        }
        return randPoint;
    }
    public Vector3 RandomPoint()
    {
        Vector3 randPoint = Random.Range(minPoint.position.x, maxPoint.position.x) * Vector3.right
            + Random.Range(minPoint.position.z, maxPoint.position.z) * Vector3.forward;
        NavMeshHit hit;
        NavMesh.SamplePosition(randPoint, out hit, float.PositiveInfinity, 1);
        return hit.position;
    }

    public void ClearBot()
    {
        for(int i = 0; i < bots.Count; i++)
        {
            SimplePool.Collect(bots[i]);
        }
        bots.Clear();
    }
}
