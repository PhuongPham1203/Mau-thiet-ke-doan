using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuaController : Enemy
{
    private EnemyContext enemyContext;
    // Start is called before the first frame update
    void Start()
    {
        this.enemyContext = new EnemyContext();


        InvokeRepeating("UnDie2s", 1.0f, 2f);

    }
    

    public void UnDie2s()
    {

        if (this.stateEnemy == StateEnemy.Idle)
        {
            //Debug.Log("run idle");
            enemyContext.setState(new UnDieState(this));
            enemyContext.applyState();
        }
        else if (this.stateEnemy == StateEnemy.UnDie)
        {
            //Debug.Log("run undie");

            enemyContext.setState(new IdleState(this));
            enemyContext.applyState();

        }
    }

}
