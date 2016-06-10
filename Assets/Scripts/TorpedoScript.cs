using UnityEngine;
using System.Collections;

public class TorpedoScript : MonoBehaviour {

	public AudioClip torpedoSurface;

	public GameObject splashObj;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag.Equals("Surface"))
		{
			//Vector3 splashyPlace = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
			AudioSource.PlayClipAtPoint(torpedoSurface, transform.position);
			Instantiate(splashObj, transform.position, Quaternion.identity);
		}
	}
}
