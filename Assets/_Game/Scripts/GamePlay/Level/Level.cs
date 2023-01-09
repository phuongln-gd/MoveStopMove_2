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

    private int CurrentBot => bots.Count;

    [SerializeField] Bot botPrefab;

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
        Vector3 randPoint = RandomPoint();
        if(spawnBot < totalBot)
        {
            Bot bot = Instantiate(botPrefab, randPoint, Quaternion.identity);
            bots.Add(bot);
            spawnBot +=  1;
        }
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
        bots.Clear();
    }
}
