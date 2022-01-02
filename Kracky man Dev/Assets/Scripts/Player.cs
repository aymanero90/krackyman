using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;
    private bool isTimerActive = false;
    private float currentTime = 0;
    [SerializeField]
    private Text scoreTimer;

    [SerializeField]
    private float speed = 2f;
   
    private float max_X = 2.66f, min_X = -2.62f, min_Y = -5.7f;
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        isTimerActive = true;
    }

    void Update()
    {
        if (isTimerActive)
            currentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        scoreTimer.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
    }



    void FixedUpdate()
    {
        checkBoundaries();
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        }

    }

    void checkBoundaries()
    {
        
        Vector2 temp = transform.position;

        if (temp.y < min_Y)
        {
            Destroy(gameObject);
            SoundManager.instance.GameOverSound();
            GameManager.instance.setEndScreenActive();
        }
        if(temp.x > max_X)        
            temp.x = max_X;

        if (temp.x < min_X)
            temp.x = min_X;

        transform.position = temp;

        

    }

    public void PlatformMove (float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "TopSpikes")
        {
            Destroy(gameObject);
             SoundManager.instance.GameOverSound();
             GameManager.instance.setEndScreenActive();
        }
    }

    public void setTimerActive(bool setActive)
    {
        isTimerActive = setActive;
    }
}
