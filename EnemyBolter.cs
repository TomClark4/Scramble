//17/04/16
//controls functionality of bolter

using UnityEngine;
using System.Collections;

public class EnemyBolter : EnemySpaceships
{

	float bolterSpeed = -12f;

	protected override void Start ()
	{
		base.Start ();
	}

	void Update ()
	{
		transform.Translate (bolterSpeed * Time.deltaTime, 0f, 0f);											//controls bolter movement
	}

	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D (other);
	}

	public override void DestroySelf()
	{
		base.DestroySelf ();
	}
}
