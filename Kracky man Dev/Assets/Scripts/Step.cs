using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    
    [SerializeField]
    private bool isLeftMover, isRightMover, isBreakable, isSpike, isNormal;

    private float deactivation_y = 5.5f;
    private Animator animator;
     
  
    void Awake()
    {
        if (isBreakable)
            animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        moveUpAndFinish();
    }

    void moveUpAndFinish()
    {
        Vector2 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.y >= deactivation_y)
            Destroy(gameObject);
    }

    IEnumerator DestroyBreakale()
    {
        yield return new WaitForSeconds(0.3f);
        SoundManager.instance.IceBreakSound();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (isSpike)
            {
                Destroy(target.gameObject);
                SoundManager.instance.GameOverSound();
                GameManager.instance.setEndScreenActive();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (isBreakable || isNormal)            
                SoundManager.instance.LandSound();

            if (isBreakable)
                animator.Play("Break");   
        }
        
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            var player = target.gameObject.GetComponent<Player>();
            if (isLeftMover)
                player.PlatformMove(-1f);

            if (isRightMover)
                player.PlatformMove(1f);
        }
    }

}
