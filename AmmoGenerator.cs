//15/04/16
//creates ammo/projectiles based on player input

using UnityEngine;
using System.Collections;

public class AmmoGenerator : MonoBehaviour
{

	GameObject bulletToLoad;
	GameObject bombToLoad;

	void Start ()
	{
		bulletToLoad = Resources.Load ("BulletToLoad", typeof(GameObject)) as GameObject;
		bombToLoad = Resources.Load ("BombToLoad", typeof(GameObject)) as GameObject;
	}

	void Update ()																				//ammo generated at position of player, on a separate layer
	{
		if (Input.GetMouseButtonDown (0))
		{
			Instantiate (bulletToLoad, transform.position, transform.rotation);
		}

		if (Input.GetMouseButtonDown (1))
		{
			Instantiate (bombToLoad, transform.position, transform.rotation);
		}
	}
}
