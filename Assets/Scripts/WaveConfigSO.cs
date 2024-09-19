using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config",fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float TimeBetweenEnemySpawns=1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumspawnTIme = 0.2f;
    
    public Transform GetStratingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public List<Transform> GetWaypoint()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float GetMovepeed()
    {
        return moveSpeed;
    }
    public float GetRandomSpawnTime()
    {
        float spawntime = Random.Range(TimeBetweenEnemySpawns - spawnTimeVariance, TimeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawntime,minimumspawnTIme,float.MaxValue);
    }
}
