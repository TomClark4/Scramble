//18/04/16
//makes sure scripts that utilise this interface have correct functionality

using UnityEngine;
using System.Collections;

public interface IDestroyable
{

	void OnTriggerEnter2D(Collider2D other);

	void DestroySelf();
}
