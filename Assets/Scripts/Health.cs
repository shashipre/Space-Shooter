using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool IsPlayer;
    [SerializeField] int score = 50;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem HitEffect;
    [SerializeField] bool ApplyCameraShake;
    CameraShake CameraShake;
    AudioPlayer AudioPlayer;
    ScoreCard ScoreCard;
    private void Awake()
    {
        CameraShake = Camera.main.GetComponent<CameraShake>();
        AudioPlayer = FindObjectOfType<AudioPlayer>();
        ScoreCard = FindObjectOfType<ScoreCard>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer);
            damageDealer.Hit();
            SHakeCamera();
            PlayHItEffect();
            AudioPlayer.PLayDamageCLip();
        }
    }

    private void SHakeCamera()
    {
        if (ApplyCameraShake)
        {
            CameraShake.Play();
        }
    }

    void TakeDamage(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0 )
        {
            Die();
            
        }
    }

    private void Die()
    {
        if (IsPlayer)
        {
            ScoreCard.ScoreReset();
        }
        else
        {
            ScoreCard.ScoreIncrease(score);
        }
        Destroy(gameObject);
    }

    void PlayHItEffect()
    {
        if (HitEffect != null)
        {
            ParticleSystem instant = Instantiate(HitEffect,transform.position,Quaternion.identity);
            Destroy(instant, instant.main.duration+instant.main.startLifetime.constantMax);
        }
    }
    public int GetHealth()
    {
        return health;
    }
}
