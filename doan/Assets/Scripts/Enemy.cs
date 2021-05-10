using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    public GameObject deathEffect;

    public StateEnemy stateEnemy = StateEnemy.Idle;
    

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
}

