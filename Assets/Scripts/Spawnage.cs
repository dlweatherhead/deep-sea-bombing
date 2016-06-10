using UnityEngine;
using System.Collections;

public class Spawnage : MonoBehaviour {

	public GameObject[] gameObj;
	public float spawnMin = 2f;
	public float spawnMax = 10f;
	public int objDirection = 1;

	// Use this for initialization
	void Start () {
		Spawn();
	}

	void Spawn () {
		Instantiate(gameObj[Random.Range (0, gameObj.GetLength(0))], transform.position, Quaternion.identity);
		Invoke("Spawn", Random.Range (spawnMin, spawnMax));
	}
}
