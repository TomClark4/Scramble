//13/04/16
//controls the semi-random generation and destruction of terrain and controls spawning event of ascender

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
	
	Vector2 startPositionBottom = new Vector2(9.641f, -4.75f);											//terrain spawns at positions just to right of screen
	Vector2 startPositionBottom2 = new Vector2(9.641f, -4.25f);
	Vector2 startPositionBottom3 = new Vector2(9.641f, -3.75f);

	Vector2 startPositionTop = new Vector2(9.641f, 4.75f);
	Vector2 startPositionTop2 = new Vector2(9.641f, 4.25f);
	Vector2 startPositionTop3 = new Vector2(9.641f, 3.75f);

	float terrainSpeed = -3f;

	GameObject terrainBasicToLoad;

	GameObject terrainInstanceBottom;
	GameObject terrainInstanceTop;

	public List<GameObject> terrainBasicsBottom = new List<GameObject>();								//all terrain pieces are tracked in lists
	public List<GameObject> terrainBasicsTop = new List<GameObject>();

	int terrainHeightBottom = 1;
	int terrainHeightTop = 1;

	GameObject ascenderToSpawn;

	Vector2 ascenderSpawnPosition;

	int previousTerrainHeight;

	float yValueAscender = -4.056f;

	void Start ()
	{
		terrainBasicToLoad = Resources.Load ("TerrainBasicToLoad", typeof(GameObject)) as GameObject;
		ascenderToSpawn = Resources.Load ("Ascender", typeof(GameObject)) as GameObject;

		ShipGenerator.eventToLoad = 0;																	//makes sure ascenders aren't spawned after the player dies
																										//at the beginning of the reloaded Level1 scene
		StartCoroutine (AddTerrain ());
		StartCoroutine (RemoveTerrain ());

	}

	void Update ()																						//applies speed to each terrain piece
	{
		foreach (GameObject terrainInList in terrainBasicsBottom)
		{
			terrainInList.transform.Translate (terrainSpeed * Time.deltaTime, 0f, 0f);	
		}

		foreach (GameObject terrainInList in terrainBasicsTop)
		{
			terrainInList.transform.Translate (terrainSpeed * Time.deltaTime, 0f, 0f);
		}
	}

	IEnumerator AddTerrain()
	{
		int spawnAscenderChance;
		int stayTheSameChanceBottom;
		int stayTheSameChanceTop;

		while (true)
		{
			terrainInstanceBottom = Instantiate (terrainBasicToLoad, startPositionBottom, transform.rotation) as GameObject;
			terrainBasicsBottom.Add (terrainInstanceBottom);

			previousTerrainHeight = terrainHeightBottom;

			stayTheSameChanceBottom = Random.Range (1, 3);												//creates a larger chance for terrain to stay the same height

			if (stayTheSameChanceBottom != 1)
			{
				terrainHeightBottom = Random.Range (1, 4);
			}

			if (terrainHeightBottom == previousTerrainHeight)											//spawns fuel if 2 terrain columns are the same height
			{
				FuelGenerator.SpawnFuel();
			}
				
			spawnAscenderChance = Random.Range (1, 6);													//only spawns ascenders on 20% of terrain during an ascender event

			if (ShipGenerator.eventToLoad == 3 && spawnAscenderChance == 1)
			{
				ascenderSpawnPosition = new Vector2 (9.191f, yValueAscender);

				StartCoroutine (AscenderEvent());
			}
				
			switch (terrainHeightBottom)
			{
			case 1:
				FuelGenerator.yValueChangeFuel = -4.121f;
				yValueAscender = -4.056f;
				break;
			case 2:
				terrainInstanceBottom = Instantiate (terrainBasicToLoad, startPositionBottom2, transform.rotation) as GameObject;
				terrainBasicsBottom.Add (terrainInstanceBottom);

				FuelGenerator.yValueChangeFuel = -3.621f;
				yValueAscender = -3.556f;
				break;
			case 3:				
				terrainInstanceBottom = Instantiate (terrainBasicToLoad, startPositionBottom2, transform.rotation) as GameObject;
				terrainBasicsBottom.Add (terrainInstanceBottom);

				terrainInstanceBottom = Instantiate (terrainBasicToLoad, startPositionBottom3, transform.rotation) as GameObject;
				terrainBasicsBottom.Add (terrainInstanceBottom);

				FuelGenerator.yValueChangeFuel = -3.121f;
				yValueAscender = -3.056f;
				break;
			}

			terrainInstanceTop = Instantiate (terrainBasicToLoad, startPositionTop, transform.rotation) as GameObject;
			terrainBasicsTop.Add (terrainInstanceTop);

			stayTheSameChanceTop = Random.Range (1, 3);

			if (stayTheSameChanceTop != 1)
			{
				terrainHeightTop = Random.Range (1, 4);
			}

			switch (terrainHeightTop)
			{
			case 1:
				break;
			case 2:
				terrainInstanceTop = Instantiate (terrainBasicToLoad, startPositionTop2, transform.rotation) as GameObject;
				terrainBasicsTop.Add (terrainInstanceTop);
				break;
			case 3:
				terrainInstanceTop = Instantiate (terrainBasicToLoad, startPositionTop2, transform.rotation) as GameObject;
				terrainBasicsTop.Add (terrainInstanceTop);

				terrainInstanceTop = Instantiate (terrainBasicToLoad, startPositionTop3, transform.rotation) as GameObject;
				terrainBasicsTop.Add (terrainInstanceTop);
				break;
			}
			yield return new WaitForSeconds (0.135f);
		}
	}

	IEnumerator RemoveTerrain()
	{
		yield return new WaitForSeconds (8f);

		while (true)
		{
			switch (terrainHeightBottom)
			{
			case 1:
				GameObject terrainBottomToRemove = terrainBasicsBottom [0];

				terrainBasicsBottom.RemoveAt (0);
	
				Destroy (terrainBottomToRemove);

				break;
			case 2:
				GameObject terrainBottomToRemove2 = terrainBasicsBottom [0];
				GameObject terrainBottomToRemove2A = terrainBasicsBottom [1];

				terrainBasicsBottom.RemoveRange (0, 2);

				Destroy (terrainBottomToRemove2);
				Destroy (terrainBottomToRemove2A);

				break;
			case 3:
				GameObject terrainBottomToRemove3 = terrainBasicsBottom [0];
				GameObject terrainBottomToRemove3A = terrainBasicsBottom [1];
				GameObject terrainBottomToRemove3B = terrainBasicsBottom [2];
				
				terrainBasicsBottom.RemoveRange (0, 3);
				
				Destroy (terrainBottomToRemove3);
				Destroy (terrainBottomToRemove3A);
				Destroy (terrainBottomToRemove3B);
				
				break;
			}
			switch (terrainHeightTop)
			{
			case 1:
				GameObject terrainTopToRemove = terrainBasicsTop [0];

				terrainBasicsTop.RemoveAt (0);

				Destroy (terrainTopToRemove);		

				break;
			case 2:
				GameObject terrainTopToRemove2 = terrainBasicsTop [0];
				GameObject terrainTopToRemove2A = terrainBasicsTop [1];

				terrainBasicsTop.RemoveRange (0, 2);

				Destroy (terrainTopToRemove2);
				Destroy (terrainTopToRemove2A);

				break;
			case 3:
				GameObject terrainTopToRemove3 = terrainBasicsTop [0];
				GameObject terrainTopToRemove3A = terrainBasicsTop [1];
				GameObject terrainTopToRemove3B = terrainBasicsTop [2];
				
				terrainBasicsTop.RemoveRange (0, 3);
				
				Destroy (terrainTopToRemove3);
				Destroy (terrainTopToRemove3A);
				Destroy (terrainTopToRemove3B);
				
				break;
			}
			yield return new WaitForSeconds (0.135f);
		}
	}
		
	public IEnumerator AscenderEvent()
	{
		Instantiate (ascenderToSpawn, ascenderSpawnPosition, Quaternion.identity);
		yield return null;
	}
}
