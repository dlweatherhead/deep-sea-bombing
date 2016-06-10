using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private int killDelay = 10;

	// Update is called once per frame
	void Start () {
	}

	void FixedUpdate()
	{
		if(killDelay > 0)
			killDelay -= 1;
		else
			Destroy (gameObject);
	}
}
