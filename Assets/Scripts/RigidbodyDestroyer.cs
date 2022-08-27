using UnityEngine;

public class RigidbodyDestroyer : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
            Destroy(other.gameObject);
    }
}