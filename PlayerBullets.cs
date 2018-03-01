//15/04/16
//Contains functionality of bullets

using UnityEngine;
using System.Collections;

public class PlayerBullets : PlayerAmmo
{

	float bulletSpeed = 10f;

	protected override void Start ()
	{
		base.Start();
	}

	void Update ()
	{
		transform.Translate (bulletSpeed * Time.deltaTime, 0f, 0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Instantiate(explosion, other.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}
