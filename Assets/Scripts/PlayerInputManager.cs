using UnityEngine;
using System.Collections;

public class PlayerInputManager : MonoBehaviour {

	public GameObject player;

	 string UpButton = "Up";
	 string DownButton = "Down";

	public Transform[] TrackPositions;

	int currentTrackPosIndex;

	public bool reversed;

	// Use this for initialization
	void Start () {
		reversed = false;

		currentTrackPosIndex = 1;
		player.transform.position = TrackPositions [currentTrackPosIndex].position;
	
	
	}
	
	// Update is called once per frame
	void Update () {

		if (reversed) {
			if (Input.GetButtonDown (UpButton)) {
				TryMoveDown ();
			}
			if (Input.GetButtonDown (DownButton)) {
				TryMoveUp ();

			}
		} else {
			if(Input.GetButtonDown(UpButton))
				{
					TryMoveUp();
				}
			if (Input.GetButtonDown (DownButton)) {
				TryMoveDown ();
			}
		}

	
	}

	void TryMoveDown()
	{
		if (currentTrackPosIndex > 0) {
			currentTrackPosIndex--;
		}
		player.transform.position = TrackPositions [currentTrackPosIndex].position;
	}

	void TryMoveUp()
	{
		if (currentTrackPosIndex < 2) {
			currentTrackPosIndex++;
		}
		player.transform.position = TrackPositions [currentTrackPosIndex].position;

	}
}
