using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject)
		{
			if(other.tag.Equals("Player"))
			{
				Application.LoadLevel (0);
				return;
			}
			Destroy(other.gameObject);
		}
	}
}
