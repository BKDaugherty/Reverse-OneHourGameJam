using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour {


	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Obstacle") {
			Destroy (other.gameObject);
		}
	}
}
