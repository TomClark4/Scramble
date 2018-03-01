//09/04/16
//Contains functionality of main menu scene

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuLevelChanger : MonoBehaviour 
{

	public void EnterLevel1()
	{
		SceneManager.LoadSceneAsync (1);
		LifeTracker.instance.ResetLives ();
		ScoreTracker.instance.StartCoroutine ("PointsOverTime");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
