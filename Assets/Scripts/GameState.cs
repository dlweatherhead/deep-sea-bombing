using UnityEngine;

public class GameState : MonoBehaviour {
    public GameObject explosionObj;
    
    float score;
    int lives = 3;
    int teamkills;
    Vector3 originPosition;
    Quaternion originRotation;
    float shake_decay;
    float shake_intensity;
    bool written;

    void Update() {
        score += Time.deltaTime;
        if (lives <= 0) {
            if (written == false) {
                PlayerPrefs.SetInt("Score", (int) score);
                PlayerPrefs.SetInt("Murders", (int) teamkills);

                GameObject playerTemp = GameObject.FindWithTag("Player");
                playerTemp.GetComponent<Rigidbody2D>().gravityScale = 1;
                playerTemp.transform.rotation = new Quaternion(
                    playerTemp.transform.rotation.x,
                    playerTemp.transform.rotation.y,
                    playerTemp.transform.rotation.z - 0.3f,
                    playerTemp.transform.rotation.w);

                written = true;
            }

            for (int i = 0; i < 6; i++) {
                Vector3 cam = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), -5);
                GameObject expNew = Instantiate(explosionObj, cam, Quaternion.identity);
                int randomNumber = Random.Range(2, 8);
                Vector3 temp = new Vector3(randomNumber, randomNumber, 1);
                expNew.transform.localScale = temp;
            }

            Invoke("LoadMainMenu", 3f);
        }

        if (shake_intensity > 0) {
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;

            transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-shake_intensity, shake_intensity) * 0.2f,
                originRotation.y + Random.Range(-shake_intensity, shake_intensity) * 0.2f,
                originRotation.z + Random.Range(-shake_intensity, shake_intensity) * 0.2f,
                originRotation.w + Random.Range(-shake_intensity, shake_intensity) * 0.2f);
            shake_intensity -= shake_decay;
        }

        if (Input.GetKey("escape")) {
            PlayerPrefs.SetInt("firstTime", -1);
            Application.CancelQuit();
        }
    }

    public void LoadMainMenu()
    {
        Application.LoadLevel(0);
    }

public void changeLives(int livesLost) {
        lives += livesLost;
    }

    public void changeScore(float numbers) {
        score += numbers;
    }

    public void changeTeamkills(int kill) {
        teamkills += kill;
    }

    public void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 75), "Score: " + (int) (score));
        GUI.Label(new Rect(100, 10, 190, 75), "Lives: " + lives);
        GUI.Label(new Rect(190, 10, 280, 75), "Murders: " + teamkills);
    }

    public void Shake() {
        originPosition = transform.position;
        originRotation = transform.rotation;
        shake_intensity = 0.04f;
        shake_decay = 0.003f;
    }
}