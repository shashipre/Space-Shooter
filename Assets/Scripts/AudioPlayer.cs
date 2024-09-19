using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip Shooting;
    [SerializeField][Range(0f, 1f)] float ShootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip Damageclip;
    [SerializeField][Range(0f,1f)] float DamageclipVolume = 1f;

    public void PlayShootingClip()
    {
        if (Shooting != null)
        {
            AudioSource.PlayClipAtPoint(Shooting,
                Camera.main.transform.position,
                ShootingVolume);
        }
    }
    public void PLayDamageCLip()
    {
        if (Damageclip != null)
        {
            AudioSource.PlayClipAtPoint(Damageclip, Camera.main.transform.position, DamageclipVolume);
        }
    }

}