using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : WeaponStrategy {

	
	public GameObject bulletPrefab;
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
		*/
	}

	public override void Shoot ()
	{
		//Debug.Log("PrefabWeapon");
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
