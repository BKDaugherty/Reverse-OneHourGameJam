using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject obstaclePrefab;

	public float spawnCooldownTime;
	public float gameStartWait;

	public bool toSpawn = true;

	public Transform [] spawnPoints;

	public void SpawnObstacle()
	{
			Instantiate (obstaclePrefab, spawnPoints [(int)Random.Range (0f, 2.4f)].position, Quaternion.identity);
	}
}
