using UnityEngine;
using System.Collections;

public class SceneMenu : MonoBehaviour {
	private bool showMenu;
	private Collider menuScreen;


	// Use this for initialization
	void Start () {
		this.showMenu = false;
		this.menuScreen = GameObject.Find("MenuScreen").GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			this.showMenu = !this.showMenu;
			if (this.showMenu)
				this.menuScreen.enabled = true;
			else
				this.menuScreen.enabled = false;
		}
	}

	void OnGUI() {
		if (this.showMenu) {
			if (GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2 -25-90, 200, 50), "Box"))
				Application.LoadLevel("SimpleThrusters");
			if (GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2 -25-30, 200, 50), "Flying Brick"))
				Application.LoadLevel("FlyingBrick");
			if (GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2 -25+30, 200, 50), "Cruiser"))
				Application.LoadLevel("Cruiser");
			if (GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2 -25+90, 200, 50), "Quit"))
				Application.Quit();
		}
	}
}
