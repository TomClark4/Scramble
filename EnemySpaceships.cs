//18/04/16
//controls shared functionality of all enemy spaceships

using UnityEngine;
using System.Collections;

public class EnemySpaceships : MonoBehaviour, IDestroyable
{

	int scoreToUpdateBy = 100;

	protected virtual void Start ()
	{
		DestroySelf();
	}

	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ammo")
		{
			ScoreTracker.instance.currentScore += scoreToUpdateBy;						//update score held in singleton by chosen value
			ScoreTracker.instance.UpdateScore ();
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

	public virtual void DestroySelf()													//destroys itself if player did not destroy once off screen
	{
		Destroy (gameObject, 7f);
	}
}
