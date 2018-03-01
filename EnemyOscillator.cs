//17/04/16
//controls functionality of oscillator

using UnityEngine;
using System.Collections;

public class EnemyOscillator : EnemySpaceships
{

	float oscillatorVerticalSpeed = 7f;
	float oscillatorHorizontalSpeed = -3f;

	float oscillatePosition = 3f;

	protected override void Start ()
	{
		base.Start ();
		StartCoroutine (MoveDown ());																	//applies an initial movement
	}

	void Update ()																						//oscillates between chosen values
	{
		transform.Translate (oscillatorHorizontalSpeed * Time.deltaTime, 0f, 0f);

		if (transform.position.y >= oscillatePosition)
		{
			StopAllCoroutines();
			StartCoroutine (MoveDown());
		}
		else if (transform.position.y <= -oscillatePosition)
		{
			StopAllCoroutines();
			StartCoroutine (MoveUp());
		}
	}

	IEnumerator MoveDown ()
	{
		StopCoroutine (MoveUp ());
		while (true)
		{
			transform.Translate (0f, -oscillatorVerticalSpeed * Time.deltaTime, 0f);
			yield return null;
		}
	}

	IEnumerator MoveUp ()
	{
		StopCoroutine(MoveDown());
		while (true)
		{
			transform.Translate (0f, oscillatorVerticalSpeed * Time.deltaTime, 0f);
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
