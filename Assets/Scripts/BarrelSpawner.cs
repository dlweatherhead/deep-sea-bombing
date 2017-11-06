using UnityEngine;

public class BarrelSpawner : MonoBehaviour {

	public GameObject barrelObj;
	public float fireRate = 30.0f;

	void FixedUpdate () {
		fireRate -= 1;
		if(fireRate <= 0 && Input.GetKeyDown("space")) {
			Instantiate(barrelObj, transform.position, Quaternion.identity);
			fireRate = 30.0f;
		}
	}
}
