using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float speed = 1.0f;
    public GameObject torpedo;
    public GameObject explosionObj;
    GameState gameState;

    public int fireRate = 30;
    private int torpedoDelay;

    public Sprite deathSprite;

    public AudioClip hitSoundEnemy;
    public AudioClip hitSoundFriendly;

    void Update() {
        float h = speed * Time.deltaTime;
        transform.Translate(h, 0, 0);
    }

    void FixedUpdate() {
        if (transform.tag.Equals("Enemy")) {
            if (torpedoDelay <= 0) {
                Transform player = GameObject.FindWithTag("Player").transform;
                if (player != null) {
                    int playerX = (int) player.position.x;
                    int currentX = (int) transform.position.x;
                    if (currentX <= playerX + 3 && currentX >= playerX - 3)
                        Instantiate(torpedo, transform.position, Quaternion.identity);
                }
                torpedoDelay = fireRate;
            }
            else {
                torpedoDelay -= 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Barrel")) {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            gameState = GameObject.FindWithTag("MainCamera").GetComponent<GameState>();

            Quaternion currentRotation = transform.rotation;

            if (transform.tag.Equals("Enemy")) {
                AudioSource.PlayClipAtPoint(hitSoundEnemy, transform.position);

                gameState.changeScore(100);

                transform.rotation = new Quaternion(
                    currentRotation.x,
                    currentRotation.y,
                    currentRotation.z + Random.Range(-0.3f, -0.7f),
                    currentRotation.w);
            }
            if (transform.tag.Equals("Friendly")) {
                AudioSource.PlayClipAtPoint(hitSoundFriendly, transform.position);
                transform.rotation = new Quaternion(
                    currentRotation.x,
                    currentRotation.y,
                    currentRotation.z + Random.Range(0.7f, 1.4f),
                    currentRotation.w);

                gameState.changeTeamkills(1);
                
                GetComponent<SpriteRenderer>().sprite = deathSprite;
            }
            gameState.Shake();

            Instantiate(explosionObj, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}