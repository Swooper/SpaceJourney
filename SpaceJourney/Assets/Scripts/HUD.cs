using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	private Thrusters thrusters;

	private string[] hotkeysAft = {"A","S","D","F","G","H","J","K","L","Æ"};
	private string[] hotkeysBow = {"Ctrl+A","Ctrl+S","Ctrl+D","Ctrl+F","Ctrl+G","Ctrl+H","Ctrl+J","Ctrl+K","Ctrl+L","Ctrl+Æ"};
	private string[] hotkeysKeel = {"Q","W","E","R","T","Y","U","I","O","P"};
	private string[] hotkeysPort = {"Ctrl+Z","Ctrl+X","Ctrl+C","Ctrl+V","Ctrl+B","Ctrl+N","Ctrl+M","Ctrl+,","Ctrl+.","Ctrl+Þ"};
	private string[] hotkeysStarboard = {"Z","X","C","V","B","N","M",",",".","Þ"};
	private string[] hotkeysTop = {"Ctrl+Q","Ctrl+W","Ctrl+E","Ctrl+R","Ctrl+T","Ctrl+Y","Ctrl+U","Ctrl+I","Ctrl+O","Ctrl+P"};

	// Use this for initialization
	void Start () {
		thrusters = GameObject.Find ("SpaceShip").GetComponent<Thrusters>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		// Draw aft thrusters HUD
		int thrCount = 0;
		foreach(GameObject thruster in thrusters.AftThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				DrawQuad(new Rect(800+(thrCount*50), Screen.height-140, 50, 140), Color.grey);
				DrawQuad(new Rect(810+(thrCount*50), Screen.height-120, 30, 100), Color.black);
				float value = thrusters.AftThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(810+(thrCount*50), Screen.height-20-(100*value), 30, 100*value), Color.red);
				}
				GUI.Label (new Rect(820+(thrCount*50), Screen.height-140, 40, 20), hotkeysAft[thrCount]);
			}
			thrCount++;
		}

		// Draw bow thrusters HUD
		thrCount = 0;
		foreach(GameObject thruster in thrusters.BowThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				DrawQuad(new Rect(800+(thrCount*50), 0, 50, 140), Color.grey);
				DrawQuad(new Rect(810+(thrCount*50), 20, 30, 100), Color.black);
				float value = thrusters.BowThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(810+(thrCount*50), 120-(100*value), 30, 100*value), Color.red);
				}
				GUI.Label (new Rect(805+(thrCount*50), 0, 40, 20), hotkeysBow[thrCount]);
			}
			thrCount++;
		}

		// Draw keel thrusters HUD
		thrCount = 0;
		foreach(GameObject thruster in thrusters.KeelThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				DrawQuad(new Rect(0+(thrCount*50), Screen.height-140, 50, 140), Color.grey);
				DrawQuad(new Rect(10+(thrCount*50), Screen.height-120, 30, 100), Color.black);
				float value = thrusters.KeelThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(10+(thrCount*50), Screen.height-20-(100*value), 30, 100*value), Color.red);
				}
				GUI.Label (new Rect(20+(thrCount*50), Screen.height-140, 40, 20), hotkeysKeel[thrCount]);
			}
			thrCount++;
		}

		// Draw port thrusters HUD
		thrCount = 0;
		foreach(GameObject thruster in thrusters.PortThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				DrawQuad(new Rect(0, 180+(thrCount*60), 140, 60), Color.grey);
				DrawQuad(new Rect(20, 200+(thrCount*60), 100, 30), Color.black);
				float value = thrusters.PortThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(20, 200+(thrCount*60), 100*value, 30), Color.red);
				}
				GUI.Label (new Rect(45, 180+(thrCount*60), 40, 20), hotkeysPort[thrCount]);
			}
			thrCount++;
		}

		// Draw starboard thrusters HUD
		thrCount = 0;
		foreach(GameObject thruster in thrusters.StarboardThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				DrawQuad(new Rect(Screen.width-140, 180+(thrCount*60), 140, 60), Color.grey);
				DrawQuad(new Rect(Screen.width-120, 200+(thrCount*60), 100, 30), Color.black);
				float value = thrusters.StarboardThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(Screen.width-120, 200+(thrCount*60), 100*value, 30), Color.red);
				}
				GUI.Label (new Rect(Screen.width-70, 180+(thrCount*60), 40, 20), hotkeysStarboard[thrCount]);
			}
			thrCount++;
		}

		// Draw top thrusters HUD
		thrCount = 0;
		foreach(GameObject thruster in thrusters.TopThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				DrawQuad(new Rect(0+(thrCount*50), 0, 50, 140), Color.grey);
				DrawQuad(new Rect(10+(thrCount*50), 20, 30, 100), Color.black);
				float value = thrusters.TopThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(10+(thrCount*50), 120-(100*value), 30, 100*value), Color.red);
				}
				GUI.Label (new Rect(5+(thrCount*50), 0, 40, 20), hotkeysTop[thrCount]);
			}
			thrCount++;
		}
	}

	// This function courtesy of kblood, from 
	// http://forum.unity3d.com/threads/116348-Draw-a-simple-rectangle-filled-with-a-color
	void DrawQuad(Rect position, Color color) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}
}
