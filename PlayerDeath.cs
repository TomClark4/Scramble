//16/04/16
//Contains player death functionality

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

	GameObject explosion;

	void Start ()
	{
		explosion = Resources.Load ("Explosion", typeof(GameObject)) as GameObject;
	}

	void Update ()
	{
		if (FuelTracker.fuelFullImage.fillAmount == 0)
		{
			PlayerDies ();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Instantiate (explosion, transform.position, Quaternion.identity);
		PlayerDies ();
	}

	void PlayerDies()
	{
		LifeTracker.instance.LifeDeductor ();

		ScoreTracker.instance.StopCoroutine ("PointsOverTime");							//prevents points from being gained after death but before next life

		gameObject.SetActive (false);
		Invoke ("ReloadScene", 2f);
	}

	void ReloadScene()
	{
		SceneManager.LoadSceneAsync (1);
		ScoreTracker.instance.StartCoroutine ("PointsOverTime");
	}
}
