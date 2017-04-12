using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public float cameraSpeedMult;

	// Update is called once per frame

	public void moveCamera()
	{
		transform.position += Vector3.right * Time.deltaTime * cameraSpeedMult;
	}
}
