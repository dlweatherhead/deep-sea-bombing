using UnityEngine;

public class TorpedoScript : MonoBehaviour {
    public AudioClip torpedoSurface;
    public GameObject splashObj;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Surface")) {
            AudioSource.PlayClipAtPoint(torpedoSurface, transform.position);
            Instantiate(splashObj, transform.position, Quaternion.identity);
        }
    }
}