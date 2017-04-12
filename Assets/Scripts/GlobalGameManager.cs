using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalGameManager : MonoBehaviour {

	static GlobalGameManager instance;
	ObstacleSpawner spawner;
	ReverseManager reverse;

	Coroutine spawn;

	public float gameStartWait;
	public float spawnCooldownTime;

	public MoveCamera cam;
	public Text ScoreText;
	public Text GameOverText;

	public float scoreMultiplier = 5f;

	public Button RestartButton;

	public Button StartGameButton;
	public Text StartGameText;

	public Player player;

	Vector3 startPosition;

	float score;


	public static GlobalGameManager Instance{
		get{ return Instance; }
	}

	void Awake()
	{
		if (instance != null) {
			Destroy (this.gameObject);
		} else {
			instance = this;
		}

		spawner = GetComponent<ObstacleSpawner> ();
		reverse = GetComponent<ReverseManager> ();

		startPosition = cam.gameObject.transform.position;
		GameSetup ();

	}

	void GameSetup()
	{
		StartGameText.text = "REVERSE";
		StartGameText.enabled = true;
		GameOverText.enabled = false;
		RestartButton.gameObject.SetActive (false);
		StartGameButton.gameObject.SetActive (true);
		score = 0;
		ScoreText.enabled = false;

	}



	void Update()
	{
		if (gameInPlay) {
			cam.moveCamera ();
			reverse.HandleReverse ();
			score += Time.deltaTime * scoreMultiplier;
			ScoreText.text = "Score: " + (int)score;

		}
		if (player.gameOver) {
			GameOverConditionsMet ();
		}
	}


	public void GameOverConditionsMet()
	{
		gameInPlay = false;
		player.gameObject.SetActive (false);

		spawner.toSpawn = false;
		StopCoroutine (spawn);

		displayFinalScore ();

		//Do other stuff too.

		//Show Score, 
	}

	IEnumerator SpawnObstacle()
	{
		yield return new WaitForSeconds (gameStartWait);
		while (gameInPlay) {
			spawner.SpawnObstacle ();
			yield return new WaitForSeconds (spawnCooldownTime);
		}
	}

	public void GameStart()
	{
		ScoreText.enabled = true;
		StartGameText.enabled = false;
		StartGameButton.gameObject.SetActive (false);
		gameInPlay = true;

		spawner.toSpawn = true;

		spawn = StartCoroutine ("SpawnObstacle");
		score = 0;

		player.gameObject.SetActive (true);






	}

	void displayFinalScore()
	{
		GameOverText.enabled = true;
		GameOverText.text = "GAME OVER! YOUR SCORE IS " + (int)score;
		RestartButton.gameObject.SetActive (true);
	}

	bool gameInPlay;

	public void RestartGame()
	{
		GameOverText.enabled = false;
		RestartButton.gameObject.SetActive (false);
		ScoreText.enabled = true;
		spawner.toSpawn = true;

		cam.gameObject.transform.position = startPosition;
		
		gameInPlay = true;
		spawn = StartCoroutine ("SpawnObstacle");
		score = 0;

		player.gameOver = false;
		player.gameObject.SetActive (true);

	}

	public bool GameInPlay{
		get{ return gameInPlay;}
	}

}
