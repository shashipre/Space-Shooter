using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    [SerializeField] float ShakeDuration = 1.0f;
    [SerializeField] float ShakeMagnitude = 0.5f;

    Vector3 InitialPosition;

    private void Start()
    {
        InitialPosition = transform.position;   
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

     IEnumerator Shake()
    {
        float elapsedtimes = 0f;
        while (elapsedtimes < ShakeDuration)
        {
            transform.position = InitialPosition + (Vector3)UnityEngine.Random.insideUnitCircle * ShakeMagnitude;
            elapsedtimes += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        
    }
}


