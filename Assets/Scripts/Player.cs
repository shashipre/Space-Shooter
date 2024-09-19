using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    Vector2  rawData;
    Rigidbody2D rd;
    [SerializeField] float moveSpeed = 5;
    Vector2 minBound;
    Vector2 maxBound;

    [SerializeField] float paddingleft;
    [SerializeField] float paddindright;
    [SerializeField] float paddindtop;
    [SerializeField] float paddindbottom;


    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {

        initBounds();
    }
    void Update()
    {
        MoveMent();
    }
    void initBounds()
    {
        Camera maincamera = Camera.main;
        minBound = maincamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBound = maincamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    private void MoveMent()
    {
        Vector3 delta = rawData * moveSpeed * Time.deltaTime;
        Vector2 newpos = new Vector2();
        newpos.x = Mathf.Clamp(transform.position.x+delta.x, minBound.x+paddingleft, maxBound.x-paddindright);
        newpos.y = Mathf.Clamp(transform.position.y+delta.y, minBound.y+paddindbottom, maxBound.y-paddindtop);
        transform.position = newpos;
    }

    void OnMove(InputValue value) {
        rawData = value.Get<Vector2>();
    }
    
    void OnFire(InputValue val)
    {
        if (shooter != null)
        {
            shooter.IsFiring = val.isPressed;
        }
    }
}
