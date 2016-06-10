using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10.0f;
	public GameObject gameState;
	public GameObject explosionObj;
	GameState gs;
	private bool direction = false; // looking right.

	public AudioClip shipHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		transform.Translate(h ,0, 0);
		if (h < 0 && direction == false)
		{
			Vector3 s = transform.localScale;
			s.x *= -1;
			transform.localScale = s;
			direction = true; // look left.
		}
		if (h > 0 && direction == true)
		{
			Vector3 s = transform.localScale;
			s.x *= -1;
			transform.localScale = s;
			direction = false; // look left.
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag.Equals("Torpedo"))
		{
			AudioSource.PlayClipAtPoint(shipHit, transform.position);

			gs = GameObject.FindWithTag("MainCamera").GetComponent<GameState>();
			gs.changeLives(-1);
			gs.Shake();

			Instantiate(explosionObj, transform.position, Quaternion.identity);
			Destroy(other.gameObject);
		}
	}
}
