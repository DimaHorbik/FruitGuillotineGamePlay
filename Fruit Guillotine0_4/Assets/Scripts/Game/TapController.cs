using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour
{

    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;

    public static int tapForce = -400;
    public float tiltSmooth = 0;
    public Vector3 startPos;
    public AudioSource tapSound;
    public AudioSource scoreSound;
    public AudioSource dieSound;

    Rigidbody2D rigidBody;
    Quaternion downRotation;
    Quaternion forwardRotation;

    GameManager game;
    TrailRenderer trail;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -100);
        game = GameManager.Instance;
        rigidBody.simulated = false;
        rigidBody.gravityScale = -1;
        //trail = GetComponent<TrailRenderer>();
        //trail.sortingOrder = 20; 
    }

    void OnEnable()
    {
        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }

    void OnDisable()
    {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
    }

    void OnGameStarted()
    {
        rigidBody.velocity = Vector3.zero;
        rigidBody.simulated = true;
    }

    void OnGameOverConfirmed()
    {
       // transform.localPosition = startPos;
        transform.rotation = Quaternion.identity;
    }
    public void OnMouseDown()
    {
        rigidBody.velocity = Vector2.zero;
        transform.rotation = forwardRotation;
        rigidBody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
    }

    void Update()
    {
        if (game.GameOver) return;

        if (Input.GetMouseButtonDown(0))
        {
            
           // tapSound.Play();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DeadZone")
        {
            Damage.hp = 100;
            //rigidBody.simulated = false;
            OnPlayerDied();
            
            //dieSound.Play();
        }
    }

}

