using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 10.0f;
    public GameObject explosionObj;
    public AudioClip shipHit;
    
    GameState gs;
    private bool directionLeft;
    
    void Update() {
        float h = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(h, 0, 0);
        if (h < 0 && !directionLeft) {
            Vector3 s = transform.localScale;
            s.x *= -1;
            transform.localScale = s;
            directionLeft = true;
        }
        if (h > 0 && directionLeft) {
            Vector3 s = transform.localScale;
            s.x *= -1;
            transform.localScale = s;
            directionLeft = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Torpedo")) {
            AudioSource.PlayClipAtPoint(shipHit, transform.position);

            gs = GameObject.FindWithTag("MainCamera").GetComponent<GameState>();
            gs.changeLives(-1);
            gs.Shake();

            Instantiate(explosionObj, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}