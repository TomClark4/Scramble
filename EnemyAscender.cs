//17/04/16
//controls functionality of ascender

using UnityEngine;
using System.Collections;

public class EnemyAscender : EnemySpaceships
{

	float ascenderVerticalSpeed = 4f;
	float ascenderHorizontalSpeed = -3f;

	float ascendRange = 6f;

	bool hasAscended = false;

	protected override void Start ()
	{
		base.Start ();
	}

	void Update ()
	{
		transform.Translate (ascenderHorizontalSpeed * Time.deltaTime, 0f, 0f);

		if (Vector2.Distance(transform.position, PlayerPosition.playerPos) < ascendRange && hasAscended == false)
		{
			hasAscended = true;																						//speed is only applied to ship once, when in range
			StartCoroutine (MoveUp());
		}
	}

	IEnumerator MoveUp ()
	{
		while (true)
		{
			transform.Translate (0f, ascenderVerticalSpeed * Time.deltaTime, 0f);									//controls vertical ascender movement
			yield return null;
		}
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
