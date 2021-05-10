using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : Enemy
{
    
    ObjectPoolFireworks objectPoolFireworks;
    private void Start() {
        this.objectPoolFireworks = ObjectPoolFireworks.Instance;
    }

    

    public override void Die()
    {
        base.Die();

        this.objectPoolFireworks.StartCoroutine(this.objectPoolFireworks.WaitAndPool(0.01f,this.transform.position));
    
    }
}
