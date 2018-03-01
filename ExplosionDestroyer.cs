//18/04/16
//Controls duration and movement of explosions

using UnityEngine;
using System.Collections;

public class ExplosionDestroyer : MonoBehaviour
{

	float explosionSpeed = -3f;

	void Start ()
	{
		Destroy (gameObject, 1f);
	}

	void Update ()
	{
		transform.Translate (explosionSpeed * Time.deltaTime, 0f, 0f);
	}
}
