using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStrategy : MonoBehaviour,IWeaponStrategy
{

    public Transform firePoint;
    /*
    void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}
    */
    public virtual void Shoot(){

    }
}
