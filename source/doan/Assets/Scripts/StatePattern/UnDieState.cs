using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnDieState : State
{
    private Enemy enemy;
    
    public UnDieState(Enemy e){
        this.enemy = e;
    }
    public void handleRequest(){
        this.enemy.stateEnemy = StateEnemy.UnDie;
        this.enemy.GetComponent<SpriteRenderer>().material.color = Color.red;
        //Debug.Log(this.enemy.name);
        //Debug.Log(this.enemy.stateEnemy);
    }
}
