using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	
	private Texture2D texture;

	private Thrusters thrusters;

	private string[] hotkeysAft = {"A","S","D","F","G","H","J","K","L","Æ"};
	private string[] hotkeysBow = {"Ctrl+A","Ctrl+S","Ctrl+D","Ctrl+F","Ctrl+G","Ctrl+H","Ctrl+J","Ctrl+K","Ctrl+L","Ctrl+Æ"};
	private string[] hotkeysKeel = {"Q","W","E","R","T","Y","U","I","O","P"};
	private string[] hotkeysPort = {"Ctrl+Z","Ctrl+X","Ctrl+C","Ctrl+V","Ctrl+B","Ctrl+N","Ctrl+M","Ctrl+,","Ctrl+.","Ctrl+Þ"};
	private string[] hotkeysStarboard = {"Z","X","C","V","B","N","M",",",".","Þ"};
	private string[] hotkeysTop = {"Ctrl+Q","Ctrl+W","Ctrl+E","Ctrl+R","Ctrl+T","Ctrl+Y","Ctrl+U","Ctrl+I","Ctrl+O","Ctrl+P"};

	private bool[] highlightAft = {false, false, false, false, false, false, false, false, false, false};
	private bool[] highlightBow = {false, false, false, false, false, false, false, false, false, false};
	private bool[] highlightKeel = {false, false, false, false, false, false, false, false, false, false};
	private bool[] highlightPort = {false, false, false, false, false, false, false, false, false, false};
	private bool[] highlightStarboard = {false, false, false, false, false, false, false, false, false, false};
	private bool[] highlightTop = {false, false, false, false, false, false, false, false, false, false};

	// Use this for initialization
	void Start () {
		thrusters = GameObject.Find ("SpaceShip").GetComponent<Thrusters>();
		this.texture = new Texture2D(1, 1);
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
				if(highlightAft[thrCount]) {
					// Find way to use other colours...
					DrawQuad(new Rect(800+(thrCount*50), Screen.height-140, 50, 140), Color.white);
				}
				else {
					DrawQuad(new Rect(800+(thrCount*50), Screen.height-140, 50, 140), Color.grey);
				}
				DrawQuad(new Rect(810+(thrCount*50), Screen.height-120, 30, 100), Color.black);
				float value = thrusters.AftThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(810+(thrCount*50), Screen.height-20-(100*value), 30, 100*value), Color.red);
				}
				GUI.Label (new Rect(820+(thrCount*50), Screen.height-140, 40, 20), hotkeysAft[thrCount]);
			}
			thrCount++;
		}
		GUI.Label (new Rect( (thrCount * 25)+760, Screen.height-20, 100, 20), "Aft thrusters");


		// Draw bow thrusters HUD
		thrCount = 0;
		foreach(GameObject thruster in thrusters.BowThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				if(highlightBow[thrCount]) {
					// Find way to use other colours...
					DrawQuad(new Rect(800+(thrCount*50), 0, 50, 140), Color.white);
				}
				else {
					DrawQuad(new Rect(800+(thrCount*50), 0, 50, 140), Color.grey);
				}
				DrawQuad(new Rect(810+(thrCount*50), 20, 30, 100), Color.black);
				float value = thrusters.BowThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(810+(thrCount*50), 120-(100*value), 30, 100*value), Color.red);
				}
				GUI.Label (new Rect(805+(thrCount*50), 0, 40, 20), hotkeysBow[thrCount]);
			}
			thrCount++;
		}
		GUI.Label (new Rect( (thrCount * 25)+760, 120, 100, 20), "Bow thrusters");

		// Draw keel thrusters HUD
		thrCount = 0;
		foreach(GameObject thruster in thrusters.KeelThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				if(highlightKeel[thrCount]) {
					// Find way to use other colours...
					DrawQuad(new Rect(0+(thrCount*50), Screen.height-140, 50, 140), Color.white);
				}
				else {
					DrawQuad(new Rect(0+(thrCount*50), Screen.height-140, 50, 140), Color.grey);
				}
				DrawQuad(new Rect(10+(thrCount*50), Screen.height-120, 30, 100), Color.black);
				float value = thrusters.KeelThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(10+(thrCount*50), Screen.height-20-(100*value), 30, 100*value), Color.red);
				}
				GUI.Label (new Rect(20+(thrCount*50), Screen.height-140, 40, 20), hotkeysKeel[thrCount]);
			}
			thrCount++;
		}
		GUI.Label (new Rect( (thrCount * 25)-40, Screen.height-20, 100, 20), "Keel thrusters");

		// Draw port thrusters HUD
		thrCount = 0;
		DrawQuad(new Rect(0, 160, 140, 20), Color.grey);
        GUI.Label(new Rect(0, 160, 140, 20), "Port thrusters");
		foreach(GameObject thruster in thrusters.PortThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				if(highlightPort[thrCount]) {
					// Find way to use other colours...
					DrawQuad(new Rect(0, 180+(thrCount*60), 140, 60), Color.white);
				}
				else {
					DrawQuad(new Rect(0, 180+(thrCount*60), 140, 60), Color.grey);
				}
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
		DrawQuad(new Rect(Screen.width-140, 160, 140, 20), Color.gray);
		GUI.Label(new Rect(Screen.width-140, 160, 140, 20), "Starboard thrusters");
		foreach(GameObject thruster in thrusters.StarboardThrusters) {
			if(thruster == null) {
				break;
			}
			else {
				if(highlightStarboard[thrCount]) {
					// Find way to use other colours...
					DrawQuad(new Rect(Screen.width-140, 180+(thrCount*60), 140, 60), Color.white);
				}
				else {
					DrawQuad(new Rect(Screen.width-140, 180+(thrCount*60), 140, 60), Color.grey);
				}
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
				if(highlightTop[thrCount]) {
					// Find way to use other colours...
					DrawQuad(new Rect(0+(thrCount*50), 0, 50, 140), Color.white);
				}
				else {
					DrawQuad(new Rect(0+(thrCount*50), 0, 50, 140), Color.grey);
				}
				DrawQuad(new Rect(10+(thrCount*50), 20, 30, 100), Color.black);
				float value = thrusters.TopThrusterValues[thrCount];
				if(value != 0) {
					DrawQuad (new Rect(10+(thrCount*50), 120-(100*value), 30, 100*value), Color.red);
				}
				GUI.Label (new Rect(5+(thrCount*50), 0, 40, 20), hotkeysTop[thrCount]);
			}
			thrCount++;
		}
		GUI.Label (new Rect( (thrCount * 25)-40, 120, 100, 20), "Top thrusters");
	}

	// This function courtesy of kblood, from 
	// http://forum.unity3d.com/threads/116348-Draw-a-simple-rectangle-filled-with-a-color
	void DrawQuad(Rect position, Color color) {
		this.texture.SetPixel(0,0,color);
		this.texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.Box(position, GUIContent.none);
	}

	void HighlightThruster(string thrusterName) {
		string[] split = thrusterName.Split('_');
		string position = split[0];
		int number = int.Parse(split[1]);
		switch(position){
			case("AftThruster"):
				highlightAft[number]=true;
				break;
			case("BowThruster"):
				highlightBow[number]=true;
				break;
			case("KeelThruster"):
				highlightKeel[number]=true;
				break;
			case("PortThruster"):
				highlightPort[number]=true;
				break;
			case("StarboardThruster"):
				highlightStarboard[number]=true;
				break;
			case("TopThruster"):
				highlightTop[number]=true;
				break;
		}
	}

	void UnHighlightThruster(string thrusterName) {

		string[] split = thrusterName.Split('_');
		string position = split[0];
		int number = int.Parse(split[1]);
		switch(position){
			case("AftThruster"):
				highlightAft[number]=false;
				break;
			case("BowThruster"):
				highlightBow[number]=false;
				break;
			case("KeelThruster"):
				highlightKeel[number]=false;
				break;
			case("PortThruster"):
				highlightPort[number]=false;
				break;
			case("StarboardThruster"):
				highlightStarboard[number]=false;
				break;
			case("TopThruster"):
				highlightTop[number]=false;
				break;
		}
	}
}
