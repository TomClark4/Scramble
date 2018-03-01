//09/04/16
//controls decrease of fuel over time, possible increases and fuel bar display

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuelTracker : MonoBehaviour
{

	public static Image fuelFullImage;

	float fuelDecreaseRate = 30f;

	void Start ()
	{
		fuelFullImage = transform.GetChild (2).GetComponent<Image> ();
	}

	void Update ()
	{
		fuelFullImage.fillAmount -= 1.0f / fuelDecreaseRate * Time.deltaTime;
	}
}
