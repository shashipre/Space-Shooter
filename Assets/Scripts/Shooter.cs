using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float ProjectileSpeed;
    [SerializeField] float ProjectileLifeTime;
    [SerializeField] float FiringRate;
    [SerializeField]  bool useAI;
    [SerializeField] float FireRateVariance;
    [SerializeField] float MinimumFireRate;
    public bool IsFiring;
    Coroutine fireCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            IsFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }
    float RandomFireRate()
    {
        float rFireRate = UnityEngine.Random.Range(FiringRate-FireRateVariance,FiringRate+FireRateVariance);
        return Mathf.Clamp(rFireRate, MinimumFireRate, float.MaxValue);
    }
    void Fire()
    {
        if(IsFiring == true && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(IsFiring == false && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
       while(true)
        {
            GameObject instant = Instantiate(projectilePrefab,transform.position, Quaternion.identity);
            Rigidbody2D rb = instant.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * ProjectileSpeed; 
            }

            Destroy(instant,ProjectileLifeTime);
            if (useAI )
            {
                yield return new WaitForSeconds(RandomFireRate());
            }
            else
            {
                audioPlayer.PlayShootingClip();
                yield return new WaitForSeconds(FiringRate);
            }
            
        }
       
    }
}
