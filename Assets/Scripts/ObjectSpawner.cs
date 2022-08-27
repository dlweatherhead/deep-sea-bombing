using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	[SerializeField] private GameObject objectToSpawn;
	[SerializeField] private float spawnRate = 1f;
	[SerializeField] private bool spawnOnStart = false;

    private void Start()
    {
        if(spawnOnStart) {
			InvokeRepeating("Spawn", 0, spawnRate);
        }
    }

    void Spawn () {
		Instantiate(objectToSpawn, transform.position, Quaternion.identity);
	}
}
