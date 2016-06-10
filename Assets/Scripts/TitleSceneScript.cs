using UnityEngine;
using System.Collections;

public class TitleSceneScript : MonoBehaviour {

	int score = 0;
	int teamkills = 0;

	int firstTime;

	// Use this for initialization
	void Start () {

		firstTime = PlayerPrefs.GetInt("firstTime");

		if(firstTime == -1)
		{
			PlayerPrefs.SetInt("Score", 0);
			PlayerPrefs.SetInt("Murders", 0);
			firstTime = 1;
			score = 0;
			teamkills = 0;
		}
		else
		{
			score = PlayerPrefs.GetInt ("Score");
			teamkills = PlayerPrefs.GetInt("Murders");
		}
	}

	// Update is called once per frame
	void OnGUI () {

		if(GUI.Button (new Rect(10,10,40,30), "Quit"))
		{
			PlayerPrefs.SetInt("firstTime", -1);
			Application.Quit();
		}

		GUI.Label (new Rect(Screen.width / 2 - 60, 50, 200, 50), "Start Game...?");
		GUI.Label (new Rect(Screen.width / 2 - 60, 100, 200, 50), "High Score: " + score);
		GUI.Label (new Rect(Screen.width / 2 - 60, 150, 200, 50), "Wildlife Murdered: " + teamkills);

		if(teamkills > 0 && teamkills <= 1)
		{
			GUI.Label (new Rect(Screen.width / 2 - 60, 200, 200, 50), "You murderer of the sea!");
		}
		else if(teamkills > 1 && teamkills <= 10)
		{
			GUI.Label (new Rect(Screen.width / 2 - 60, 200, 200, 50), "You are a wild-life serial killer.");
		}
		else if(teamkills > 10 && teamkills <= 20)
		{
			GUI.Label (new Rect(Screen.width / 2 - 60, 200, 200, 50), "Do you have tendencies for mass-murder?");
		}
		else if(teamkills > 20)
		{
			GUI.Label (new Rect(Screen.width / 2 - 60, 200, 200, 50), "G-G-G-Genocide!");
		}

		if (GUI.Button(new Rect(Screen.width / 2 - 60, 250, 100, 30), "Play?"))
		{
			Application.LoadLevel (1);
		}

		GUI.Label (new Rect(Screen.width / 2 - 160, 400, 320, 100), "Left/Right Arrow keys - Move.\n" + 
		           													"Space to drop Explosive Barrels.\n" + 
		           													"Kill submarines for score.\n" + 
		           													"Happy Hunting!");
	}
}
