//09/04/16
//Singleton which tracks, updates and displays current score and high score

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{

	public static ScoreTracker instance = null;

	public int currentScore;
	int highScore;

	Text currentScoreText;
	Text highScoreText;

	void Awake()																	//setup of singleton
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
		currentScoreText = transform.GetChild (0).GetComponent<Text> ();
		highScoreText = transform.GetChild (2).GetComponent<Text> ();
	}

	IEnumerator PointsOverTime()													//adds points continuously for surviving in actual level
	{
		while (true)
		{
			yield return new WaitForSeconds (3f);
			currentScore += 10;
			UpdateScore ();
		}
	}

	public void UpdateScore()														//updates current score and high score if need be
	{
		currentScoreText.text = currentScore.ToString ();
		if (currentScore > highScore)
		{
			highScore = currentScore;
			highScoreText.text = highScore.ToString ();
		}
	}
}
