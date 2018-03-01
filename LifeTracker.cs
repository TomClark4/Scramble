//16/04/16
//Singleton which tracks, updates and displays current lives

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeTracker : MonoBehaviour
{

	public static LifeTracker instance = null;

	float maxLives = 3f;

	public float currentLives;

	Image playerLives;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} 

		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}
		
	void Start ()
	{
		playerLives = transform.GetChild (0).GetComponent<Image> ();
		currentLives = maxLives;
	}

	public void LifeDeductor()
	{
		currentLives--;

		playerLives.fillAmount = currentLives / maxLives;

		if (currentLives == 0)
		{
			Invoke ("BackToMenu", 1f);
		}
	}

	void BackToMenu()
	{
		SceneManager.LoadSceneAsync (0);
		ScoreTracker.instance.currentScore = 0;
		ScoreTracker.instance.UpdateScore ();
		ScoreTracker.instance.StopCoroutine ("PointsOverTime");
	}

	public void ResetLives()
	{
		currentLives = 3f;
		playerLives.fillAmount = currentLives / maxLives;
	}
}
