using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool gameOver = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Obstacle") {

			gameOver = true;
		}
	}
}
