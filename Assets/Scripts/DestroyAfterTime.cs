using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	float lifeTime = 0f;
	public float maxLife = 2f;

	void Update()
	{
		lifeTime += Time.deltaTime;

		if (lifeTime > maxLife) {
			Destroy (gameObject);
		}
	}
}
