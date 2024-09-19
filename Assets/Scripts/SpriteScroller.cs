using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Vector2 MoveSpeed;
    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = MoveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
