using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyWeapon : WeaponStrategy
{
    public Transform firePoint;
	public GameObject bulletPrefab;
	
    private void Update() {
        
    }

	public override void Shoot ()
	{
		//Debug.Log("PrefabWeapon");
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
