//19/04/16
//generates fuel pickups in viable positions semi-randomly

using UnityEngine;
using System.Collections;

public class FuelGenerator : MonoBehaviour
{

	static GameObject fuelToSpawn;

	static int decreaseFuelChance = 800;
	static int lowestFuelValue = 700;

	static Vector2 fuelSpawnPosition;

	public static float yValueChangeFuel = -4.121f;

	void Awake()
	{
		fuelToSpawn = Resources.Load ("FuelPickup", typeof(GameObject)) as GameObject;
	}

	public static void SpawnFuel()
	{
		int chanceToSpawn = Random.Range (1, decreaseFuelChance);								//spawns in fuel pickups at a steadily decreasing frequency up to a maximum
																								//of 100 fuel pickups
		if (chanceToSpawn > lowestFuelValue)
		{
			fuelSpawnPosition = new Vector2 (9.406f, yValueChangeFuel);							//position of fuel set by LevelGenerator script to ensure correct
																								//positioning on top of terrain
			Instantiate (fuelToSpawn, fuelSpawnPosition, Quaternion.identity);

			decreaseFuelChance--;
		}
	}
}
