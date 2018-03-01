//09/04/16
//Converts player input to player ship movement

using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

	float playerSpeed = 6f;


	float xBoundaryMax = 8.35f;
	float xBoundaryMin = -8.35f;

	float yBoundaryMax = 4.68f;
	float yBoundaryMin = -4.68f;
		
	void Update ()
	{
		float HorizontalInput = Input.GetAxis ("Horizontal") * playerSpeed * Time.deltaTime;
		float verticalInput = Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime;

		transform.Translate (HorizontalInput, verticalInput, 0f);

		transform.position = new Vector2 															//player cannot venture outside of camera view
							 (																		
							 	Mathf.Clamp (transform.position.x, xBoundaryMin, xBoundaryMax),
							 	Mathf.Clamp (transform.position.y, yBoundaryMin, yBoundaryMax)
							 );
	}
}
