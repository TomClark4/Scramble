//15/04/16
//controls shared functionality of all ammo types

using UnityEngine;
using System.Collections;

public abstract class PlayerAmmo : MonoBehaviour
{

	protected GameObject explosion;

	protected virtual void Start()
	{
		Destroy(gameObject, 2f);
		explosion = Resources.Load ("Explosion", typeof(GameObject)) as GameObject;
	}
}
