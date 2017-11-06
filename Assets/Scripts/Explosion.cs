using UnityEngine;

public class Explosion : MonoBehaviour {
    private int killDelay = 10;

    void FixedUpdate() {
        if (killDelay > 0)
            killDelay -= 1;
        else
            Destroy(gameObject);
    }
}