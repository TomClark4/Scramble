//15/04/16
//Contains functionality of bombs

using UnityEngine;
using System.Collections;

public class PlayerBombs : PlayerAmmo
{

	float bombSpeed = 6f;
	float bombRotationSpeed = 100f;

	protected override void Start ()
	{
		base.Start();
	}

	void Update ()
	{
		transform.Translate (bombSpeed * Time.deltaTime, 0f, 0f);

		if (transform.eulerAngles.z > 270 || transform.eulerAngles.z == 0)									//stops bomb rotation once they are facing vertically
		{																									//downwards
			transform.RotateAround (transform.position, Vector3.back, bombRotationSpeed * Time.deltaTime);	//rotates bombs in an arc
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Terrain")																//bombs explode on top of terrain rather that inside it
		{
			Instantiate (explosion, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
		else
		{
			Instantiate (explosion, other.transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
