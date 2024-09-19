using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySponer enemysponer;
    WaveConfigSO waveConfig;
    List<Transform> wavepoints;
    int wavepointIndex = 0;
    void Awake()
    {
       enemysponer = FindAnyObjectByType<EnemySponer>();
    }
    void Start()
    {
        waveConfig = enemysponer.GetCurrentWave();
        wavepoints = waveConfig.GetWaypoint();
        transform.position = wavepoints[wavepointIndex].position;
    }

    
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (wavepointIndex < wavepoints.Count)
        {
            Vector3 targetPosition = wavepoints[wavepointIndex].position;
            float delta = waveConfig.GetMovepeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                wavepointIndex++;
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
