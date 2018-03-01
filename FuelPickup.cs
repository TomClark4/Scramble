//17/04/16
//controls functionality of fuel pickups

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FuelPickup : MonoBehaviour, IDestroyable
{

	float fuelSpeed = -3f;

	float fuelIncreaseAmount = 0.15f;

	int scoreToUpdateBy = 50;

	void Start ()
	{
		DestroySelf ();
	}

	void Update ()
	{
		transform.Translate (fuelSpeed * Time.deltaTime, 0f, 0f);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ammo")											//destroying fuel pickups acts as collecting fuel
		{
			FuelTracker.fuelFullImage.fillAmount += fuelIncreaseAmount;
			Destroy (other.gameObject);
			Destroy (gameObject);
			ScoreTracker.instance.currentScore += scoreToUpdateBy;
			ScoreTracker.instance.UpdateScore ();
		}
	}

	void ReloadScene()
	{
		SceneManager.LoadSceneAsync (1);
	}

	public void DestroySelf()
	{
		Destroy (gameObject, 7f);
	}
}
