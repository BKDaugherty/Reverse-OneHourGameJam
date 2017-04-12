using UnityEngine;
using System.Collections;

public class ReverseManager : MonoBehaviour {
	PlayerInputManager playerInput;

	public float timeMaxToRestart;
	public float timeMinToRestart;

	bool reversed;
	bool justReversed;

	float carryTime = 0f;
	float currentReverseTime = 0f;

	public Camera mainCam;

	// Use this for initialization
	void Awake () {
		playerInput = GetComponent<PlayerInputManager> ();
		currentReverseTime = Random.Range (timeMinToRestart, timeMaxToRestart);
		reversed = false;
	}

	void ReverseInput()
	{
		playerInput.reversed = !playerInput.reversed;
	}

	void Update()
	{
		
	}

	//Per update
	public void HandleReverse()
	{
		carryTime += Time.deltaTime;

		if (carryTime > currentReverseTime) {
			currentReverseTime = Random.Range (timeMinToRestart, timeMaxToRestart);
			carryTime = 0f;
			ReverseInput ();
			reversed = !reversed;
			justReversed = true;

		}

		if (reversed && justReversed) {
			Camera.main.backgroundColor = Color.red;
			justReversed = false;
		} else if(justReversed){
			Camera.main.backgroundColor = Color.blue;
			justReversed = false;

		}
	}




}
