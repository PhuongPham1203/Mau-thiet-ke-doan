using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int health = 100;

    public GameObject deathEffect;

    public StateEnemy stateEnemy = StateEnemy.Idle;

    //! Moving 
    Vector3 posCurrent;
    Vector3 posLeft;
    Vector3 posRight;
    public float range;

    public bool goRight = true;

    public float speed = 5f;
    
    private void Awake() {
        this.posCurrent = this.transform.position;
        this.posLeft = this.posCurrent;
        this.posRight = this.posCurrent;
        this.posLeft.x -= range;
        this.posRight.x += range;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(this.range == 0){
            return;
        }
        this.Moving();
    }

    //! Event
    //public static event Action OnEnemyDie;

    public void TakeDamage(int damage)
    {
        if(this.stateEnemy == StateEnemy.UnDie){
            return;
        }

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
		EventDispatcher.GetInstance().ui_EventEnemyDie.Invoke();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 8){
            other.gameObject.GetComponent<CharacterController2D>().TakeDamage(20);
        }
    }


    public void Moving(){
        if (this.goRight)
        {

            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, posRight, step);
            if (Vector2.Distance(transform.position, posRight) < 0.001f)
            {
                this.goRight = false;
                this.spriteRenderer.flipX=false;
            }
        }
        else
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, posLeft, step);
            if (Vector2.Distance(transform.position, posLeft) < 0.001f)
            {
                this.goRight = true;
                this.spriteRenderer.flipX=true;

            }
        }
    }
}

