using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySponer : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float TimebetweenWaves = 0f;
    WaveConfigSO currentWave;
    public bool IsLooping;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                        currentWave.GetStratingWaypoint().position,
                        Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSecondsRealtime(TimebetweenWaves);

            }
        } while (IsLooping);
    }
}
