using UnityEngine;
using System.Collections;

public class BarrelSpawner : MonoBehaviour {

	public GameObject barrelObj;
	public float fireRate = 30.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if((fireRate <= 0) && (Input.GetKeyDown("space")))
		{
			Instantiate(barrelObj, transform.position, Quaternion.identity);
			fireRate = 30.0f;
		}
		fireRate -= 1;
	}
}
