//19/04/16
//Switches between ship events and controls spawning events of oscillator and bolter

using UnityEngine;
using System.Collections;

public class ShipGenerator : MonoBehaviour
{

	GameObject bolterToSpawn;
	GameObject oscillatorToSpawn;

	IEnumerator currentEvent;

	public static int eventToLoad;

	void Start ()
	{
		bolterToSpawn = Resources.Load ("Bolter", typeof(GameObject)) as GameObject;
		oscillatorToSpawn = Resources.Load ("Oscillator", typeof(GameObject)) as GameObject;

		InvokeRepeating ("ChangeEvent", 5f, 5f);															//delays enemy ships spawning to give player time to get
	}																										//their bearings, then changes events consistently
		
	void ChangeEvent()
	{
		eventToLoad = Random.Range (1, 4);
		if (currentEvent != null)
		{
			StopCoroutine (currentEvent);
		}

		switch (eventToLoad)																				//changes randomly between each event
		{																									//an event here is a certain type of ship spawning multiple
		case 1:																								//clones over 5 seconds
			currentEvent = BolterEvent();
			StartCoroutine (currentEvent);
			break;
		case 2:
			currentEvent = OscillatorEvent();
			StartCoroutine (currentEvent);
			break;
		case 3:
			break;
		}
	}

	IEnumerator BolterEvent()
	{
		while (true)
		{
			Instantiate (bolterToSpawn, new Vector2 (9.641f, Random.Range (-3.25f, 3.25f)), Quaternion.identity);
			yield return new WaitForSeconds (0.5f);
		}
	}

	IEnumerator OscillatorEvent()
	{
		while (true)
		{
			Instantiate (oscillatorToSpawn, new Vector2 (9.641f, Random.Range (-2f, 2f)), Quaternion.identity);
			yield return new WaitForSeconds (1f);
		}
	}
}
