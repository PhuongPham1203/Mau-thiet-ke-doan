using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : WeaponStrategy {

	public Transform firePoint;
	public int damage = 40;
	public GameObject impactEffect;
	public LineRenderer lineRenderer;
	void Update () {
		
		/*if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
		*/
	}
	

	public override void Shoot(){
		//Debug.Log("RayCastWeapon");

		StartCoroutine(IEnumeratorShoot());

	}

	IEnumerator IEnumeratorShoot ()
	{
		RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

		if (hitInfo)
		{
			Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}

			Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, hitInfo.point);
		} else
		{
			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
		}

		lineRenderer.enabled = true;

		yield return 0;

		lineRenderer.enabled = false;
	}
}
