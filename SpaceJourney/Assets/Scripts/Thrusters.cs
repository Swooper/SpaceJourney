using UnityEngine;
using System.Collections;

public class Thrusters : MonoBehaviour {
	public GameObject AftThruster;
	public GameObject BowThruster;
	public GameObject KeelThruster;
	public GameObject PortThruster;
	public GameObject StarboardThruster;
	public GameObject TopThruster;

	public GameObject[] AftThrusters;
	public GameObject[] BowThrusters;
	public GameObject[] KeelThrusters;
	public GameObject[] PortThrusters;
	public GameObject[] StarboardThrusters;
	public GameObject[] TopThrusters;
	
	public float AftThrusterValue;
	public float BowThrusterValue;
	public float KeelThrusterValue;
	public float PortThrusterValue;
	public float StarboardThrusterValue;
	public float TopThrusterValue;

	public float[] AftThrusterValues;
	public float[] BowThrusterValues;
	public float[] KeelThrusterValues;
	public float[] PortThrusterValues;
	public float[] StarboardThrusterValues;
	public float[] TopThrusterValues;

	public float Scale;

	private enum ThrusterTypes {AFT_TH, BOW_TH, KEEL_TH, PORT_TH, STARBOARD_TH, TOP_TH};

	private int maxThrusters;

	// Use this for initialization
	void Start () {
		maxThrusters = 10;
		FindThrusters ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W))
			IncreaseThrust(ThrusterTypes.KEEL_TH);
		if (Input.GetKeyDown(KeyCode.S))
			DecreaseThrust(ThrusterTypes.KEEL_TH);
		if (Input.GetKeyDown(KeyCode.Q))
			IncreaseThrust(ThrusterTypes.TOP_TH);
		if (Input.GetKeyDown(KeyCode.A))
			DecreaseThrust(ThrusterTypes.TOP_TH);

		// Apply force to each thruster
		for (int i = 0; i<maxThrusters; i++) {
			if(AftThrusters[i] != null)
				this.AftThrusters [i].rigidbody.AddForce (-this.AftThrusters[i].transform.forward * this.Scale * this.AftThrusterValues[i]);
			if(BowThrusters[i] != null)
				this.BowThrusters [i].rigidbody.AddForce (-this.BowThrusters[i].transform.forward * this.Scale * this.BowThrusterValues[i]);
			if(KeelThrusters[i] != null)
				this.KeelThrusters [i].rigidbody.AddForce (-this.KeelThrusters[i].transform.forward * this.Scale * this.KeelThrusterValues[i]);
			if(PortThrusters[i] != null)
				this.PortThrusters [i].rigidbody.AddForce (-this.PortThrusters[i].transform.forward * this.Scale * this.PortThrusterValues[i]);
			if(StarboardThrusters[i] != null)
				this.StarboardThrusters [i].rigidbody.AddForce (-this.StarboardThrusters[i].transform.forward * this.Scale * this.StarboardThrusterValues[i]);
			if(TopThrusters[i] != null)
				this.TopThrusters [i].rigidbody.AddForce (-this.TopThrusters[i].transform.forward * this.Scale * this.TopThrusterValues[i]);
		}
	}
	
	void IncreaseThrust(ThrusterTypes thrusterTypes, int i) {
		switch (thrusterTypes) {
			case(ThrusterTypes.AFT_TH):
				if (this.AftThrusterValues[i] < 1.0f)
					this.AftThrusterValues[i] += 0.25f;
				break;
			case(ThrusterTypes.BOW_TH):
				if (this.BowThrusterValues[i] < 1.0f)
					this.BowThrusterValues[i] += 0.25f;
				break;
			case(ThrusterTypes.KEEL_TH):
				if (this.KeelThrusterValues[i] < 1.0f)
					this.KeelThrusterValues[i] += 0.25f;
				break;
			case(ThrusterTypes.PORT_TH):
				if (this.PortThrusterValues[i] < 1.0f)
					this.PortThrusterValues[i] += 0.25f;
				break;
			case(ThrusterTypes.STARBOARD_TH):
				if (this.StarboardThrusterValues[i] < 1.0f)
					this.StarboardThrusterValues[i] += 0.25f;
				break;
			case(ThrusterTypes.TOP_TH):
				if (this.TopThrusterValues[i] < 1.0f)
					this.TopThrusterValues[i] += 0.25f;
				break;
		}
	}
	
	void DecreaseThrust(ThrusterTypes thrusterTypes, int i) {
		switch (thrusterTypes) {
		case(ThrusterTypes.AFT_TH):
			if (this.AftThrusterValues[i] < 1.0f)
				this.AftThrusterValues[i] -= 0.25f;
			break;
		case(ThrusterTypes.BOW_TH):
			if (this.BowThrusterValues[i] < 1.0f)
				this.BowThrusterValues[i] -= 0.25f;
			break;
		case(ThrusterTypes.KEEL_TH):
			if (this.KeelThrusterValues[i] < 1.0f)
				this.KeelThrusterValues[i] -= 0.25f;
			break;
		case(ThrusterTypes.PORT_TH):
			if (this.PortThrusterValues[i] < 1.0f)
				this.PortThrusterValues[i] -= 0.25f;
			break;
		case(ThrusterTypes.STARBOARD_TH):
			if (this.StarboardThrusterValues[i] < 1.0f)
				this.StarboardThrusterValues[i] -= 0.25f;
			break;
		case(ThrusterTypes.TOP_TH):
			if (this.TopThrusterValues[i] < 1.0f)
				this.TopThrusterValues[i] -= 0.25f;
			break;
		}
	}

	void FindThrusters() {
		string[] thrusterSets = {"Aft", "Bow", "Keel", "Port", "Starboard", "Top"};
		GameObject thruster;

		foreach (string direction in thrusterSets) {

			for (int i = 0; i<maxThrusters; i++) {
				thruster = GameObject.Find (direction+"Thruster_" + i);
				switch(direction) {
					case("Aft"):
						AftThrusters[i] = thruster;
						break;
					case("Bow"):
						BowThrusters[i] = thruster;
						break;
					case("Keel"):
						KeelThrusters[i] = thruster;
						break;
					case("Port"):
						PortThrusters[i] = thruster;
						break;
					case("Starboard"):
						StarboardThrusters[i] = thruster;
						break;
					case("Top"):
						TopThrusters[i] = thruster;
						break;
				}
			}
		}
	}
}
