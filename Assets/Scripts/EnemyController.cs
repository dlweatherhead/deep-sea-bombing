using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public int direction = 1; // 1 = right; -1 = left.
	public float speed = 1.0f;
	public GameObject torpedo;
	public GameObject explosionObj;
	GameState gs;

	public int fireRate = 30;
	private int torpedoDelay = 0;

	public Sprite deathSprite;

	public AudioClip hitSoundEnemy;
	public AudioClip hitSoundFriendly;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		float h = speed * Time.deltaTime;
		transform.Translate(h, 0, 0);
	}

	void FixedUpdate()
	{
		if(transform.tag.Equals("Enemy"))
		{
			if(torpedoDelay <= 0)
			{
				Transform player = GameObject.FindWithTag("Player").transform;
				if (player != null)
				{
					int playerX = (int)player.position.x;
					int currentX = (int)transform.position.x;
					if((currentX <= playerX + 3) && (currentX >= playerX - 3))
						Instantiate(torpedo, transform.position, Quaternion.identity);
				}
				torpedoDelay = fireRate;
			}
			else
			{
				torpedoDelay -= 1;
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag.Equals("Barrel"))
		{
			GetComponent<Rigidbody2D>().gravityScale = 1;
			gs = GameObject.FindWithTag("MainCamera").GetComponent<GameState>();

			Quaternion currentQ = transform.rotation;

			if(transform.tag.Equals("Enemy"))
			{
				AudioSource.PlayClipAtPoint(hitSoundEnemy, transform.position);

				gs.changeScore(100);
								
				transform.rotation = new Quaternion(
					currentQ.x,
					currentQ.y,
					currentQ.z + Random.Range(-0.3f,-0.7f), 
					currentQ.w);
			}
			if(transform.tag.Equals("Friendly"))
			{
				AudioSource.PlayClipAtPoint(hitSoundFriendly, transform.position);
				transform.rotation = new Quaternion(
					currentQ.x,
					currentQ.y,
					currentQ.z + Random.Range(0.7f,1.4f), 
					currentQ.w);

				gs.changeTeamkills(1);

				GetComponent<SpriteRenderer>().sprite = deathSprite;
			}

			gs.Shake();

			Instantiate(explosionObj, transform.position, Quaternion.identity);
			Destroy(other.gameObject);
		}
	}
}
