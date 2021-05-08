using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private Enemy enemy;

    public IdleState(Enemy e)
    {
        this.enemy = e;
    }
    public void handleRequest()
    {
        this.enemy.stateEnemy = StateEnemy.Idle;
        this.enemy.GetComponent<SpriteRenderer>().material.color = Color.white;

    }
}
