//19/04/16
//Tracks the player position so that the ascender knows to take off when nearby

using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour
{

	public static Vector2 playerPos;

	void Update ()
	{
		playerPos = transform.position;
	}
}
