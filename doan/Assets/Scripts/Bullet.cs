using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,IBullet {

	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;

		//Debug.Log(CharacterController2D.getInstance().name);
		Destroy(gameObject,5f);
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		this.Hit(damage,hitInfo);
	}

	public void Hit(int dame,Collider2D hitInfo){
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(dame);
		}

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}
	
}
