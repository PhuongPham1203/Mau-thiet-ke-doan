﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObj : MonoBehaviour,IPoolObj
{
    public float upForce = 1f;
    public float sideForce = 0.1f;

    public void OnObjSpawn(){
        float xForce = Random.Range(-sideForce,sideForce);
        float yForce = Random.Range(-upForce/2f,upForce);

        Vector2 force = new Vector2(xForce,yForce);

        this.GetComponent<Rigidbody2D>().velocity = force;
    }
}
