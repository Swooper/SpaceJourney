using UnityEngine;
using System.Collections;

public class Thrusters : MonoBehaviour {
	public GameObject[] AftThrusters;
	public GameObject[] BowThrusters;
	public GameObject[] KeelThrusters;
	public GameObject[] PortThrusters;
	public GameObject[] StarboardThrusters;
	public GameObject[] TopThrusters;

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

		AftThrusters = new GameObject[maxThrusters];
		BowThrusters = new GameObject[maxThrusters];
		KeelThrusters = new GameObject[maxThrusters];
		PortThrusters = new GameObject[maxThrusters];
		StarboardThrusters = new GameObject[maxThrusters];
		TopThrusters = new GameObject[maxThrusters];

		AftThrusterValues = new float[maxThrusters];
		BowThrusterValues = new float[maxThrusters];
		KeelThrusterValues = new float[maxThrusters];
		PortThrusterValues = new float[maxThrusters];
		StarboardThrusterValues = new float[maxThrusters];
		TopThrusterValues = new float[maxThrusters];

		FindThrusters ();
	}
	
	// Update is called once per frame
	void Update () {
		// Er ekki hægt að gera þetta fallegar, einhvern veginn?
		/**if (Input.GetKeyDown(KeyCode.Q))
			IncreaseThrust(ThrusterTypes.KEEL_TH, 0);
		if (Input.GetKeyDown(KeyCode.W))
			DecreaseThrust(ThrusterTypes.KEEL_TH, 1);
		if (Input.GetKeyDown(KeyCode.E))
			IncreaseThrust(ThrusterTypes.KEEL_TH, 2);
		if (Input.GetKeyDown(KeyCode.R))
			DecreaseThrust(ThrusterTypes.KEEL_TH, 3);
		if (Input.GetKeyDown(KeyCode.T))
			DecreaseThrust(ThrusterTypes.KEEL_TH, 4);

		if (Input.GetKeyDown(KeyCode.Y))
			DecreaseThrust(ThrusterTypes.KEEL_TH, 5);
		if (Input.GetKeyDown(KeyCode.U))
			DecreaseThrust(ThrusterTypes.KEEL_TH, 6);
		if (Input.GetKeyDown(KeyCode.I))
			DecreaseThrust(ThrusterTypes.KEEL_TH, 7);
		if (Input.GetKeyDown(KeyCode.O))
			DecreaseThrust(ThrusterTypes.KEEL_TH, 8);
		if (Input.GetKeyDown(KeyCode.P))
			DecreaseThrust(ThrusterTypes.KEEL_TH, 9);

		if (Input.GetKeyDown(KeyCode.A))
			DecreaseThrust(ThrusterTypes.AFT_TH, 0);
		if (Input.GetKeyDown(KeyCode.S))
			DecreaseThrust(ThrusterTypes.AFT_TH, 1);
		if (Input.GetKeyDown(KeyCode.D))
			DecreaseThrust(ThrusterTypes.AFT_TH, 2);
		if (Input.GetKeyDown(KeyCode.F))
			DecreaseThrust(ThrusterTypes.AFT_TH, 3);
		if (Input.GetKeyDown(KeyCode.G))
			DecreaseThrust(ThrusterTypes.AFT_TH, 4);
		if (Input.GetKeyDown(KeyCode.H))
			DecreaseThrust(ThrusterTypes.AFT_TH, 5);
		if (Input.GetKeyDown(KeyCode.J))
			DecreaseThrust(ThrusterTypes.AFT_TH, 6);
		if (Input.GetKeyDown(KeyCode.K))
			DecreaseThrust(ThrusterTypes.AFT_TH, 7);
		if (Input.GetKeyDown(KeyCode.L))
			DecreaseThrust(ThrusterTypes.AFT_TH, 8);
		// vantar æ - hvernig gerir maður það?

		if (Input.GetKeyDown(KeyCode.Z))
			DecreaseThrust(ThrusterTypes.STARBOARD_TH, 0);
		if (Input.GetKeyDown(KeyCode.X))
			DecreaseThrust(ThrusterTypes.STARBOARD_TH, 1);
		if (Input.GetKeyDown(KeyCode.C))
			DecreaseThrust(ThrusterTypes.STARBOARD_TH, 2);
		if (Input.GetKeyDown(KeyCode.V))
			DecreaseThrust(ThrusterTypes.STARBOARD_TH, 3);
		if (Input.GetKeyDown(KeyCode.B))
			DecreaseThrust(ThrusterTypes.STARBOARD_TH, 4);
		if (Input.GetKeyDown(KeyCode.N))
			DecreaseThrust(ThrusterTypes.STARBOARD_TH, 5);
		if (Input.GetKeyDown(KeyCode.M))
			DecreaseThrust(ThrusterTypes.STARBOARD_TH, 6);*/
		// vantar fleiri takka, punkt, kommu osfrv

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

	void OnGUI () {
		// Af einhverjum astæðum þarf þessi koði að vera her en ekki i Update()
		// Virkar, en incrementar tvisvar i hvert skipti, þ.e. fer ur 0.0 i 0.5 en ekki 0.25 eins og það ætti að gera
		// Saurblöndulausn: Breyta Increase og DecreaseThrust föllunum svo þau bæti bara 0.125 við? :P
		Event e = Event.current;
		if (e.isKey) {
			switch (e.keyCode) {
				case(KeyCode.Q):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 0);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 0);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 0);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 0);
						}
					}
					break;
				case(KeyCode.W):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 1);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 1);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 1);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 1);
						}
					}
					break;
				case(KeyCode.E):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 2);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 2);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 2);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 2);
						}
					}
					break;
				// Bæta inn R-P
				case(KeyCode.A):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.BOW_TH, 0);
						}
						else {
							DecreaseThrust(ThrusterTypes.AFT_TH, 0);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.BOW_TH, 0);
						}
						else {
							IncreaseThrust (ThrusterTypes.AFT_TH, 0);
						}
					}
					break;
				case(KeyCode.S):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.BOW_TH, 1);
						}
						else {
							DecreaseThrust(ThrusterTypes.AFT_TH, 1);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.BOW_TH, 1);
						}
						else {
							IncreaseThrust (ThrusterTypes.AFT_TH, 1);
						}
					}
					break;
				case(KeyCode.D):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.BOW_TH, 2);
						}
						else {
							DecreaseThrust(ThrusterTypes.AFT_TH, 2);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.BOW_TH, 2);
						}
						else {
							IncreaseThrust (ThrusterTypes.AFT_TH, 2);
						}
					}
					break;
				// Bæta inn F-Æ
				case(KeyCode.Z):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.PORT_TH, 0);
						}
						else {
							DecreaseThrust(ThrusterTypes.STARBOARD_TH, 0);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.PORT_TH, 0);
						}
						else {
							IncreaseThrust (ThrusterTypes.STARBOARD_TH, 0);
						}
					}
					break;
			case(KeyCode.X):
				if(e.shift) {
					if(e.control) {
						DecreaseThrust(ThrusterTypes.PORT_TH, 1);
					}
					else {
						DecreaseThrust(ThrusterTypes.STARBOARD_TH, 1);
					}
				}
				else {
					if(e.control) {
						IncreaseThrust(ThrusterTypes.PORT_TH, 1);
					}
					else {
						IncreaseThrust (ThrusterTypes.STARBOARD_TH, 1);
					}
				}
				break;
			case(KeyCode.C):
				if(e.shift) {
					if(e.control) {
						DecreaseThrust(ThrusterTypes.PORT_TH, 2);
					}
					else {
						DecreaseThrust(ThrusterTypes.STARBOARD_TH, 2);
					}
				}
				else {
					if(e.control) {
						IncreaseThrust(ThrusterTypes.PORT_TH, 2);
					}
					else {
						IncreaseThrust (ThrusterTypes.STARBOARD_TH, 2);
					}
				}
				break;
				// Bæta inn V-.
			}
		}

		//if (e.isKey && !e.shift && e.keyCode == KeyCode.Q) {
		//	IncreaseThrust(ThrusterTypes.KEEL_TH, 0);
		//}
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
				if (this.AftThrusterValues[i] > 0.0f)
					this.AftThrusterValues[i] -= 0.25f;
				break;
			case(ThrusterTypes.BOW_TH):
				if (this.BowThrusterValues[i] > 0.0f)
					this.BowThrusterValues[i] -= 0.25f;
				break;
			case(ThrusterTypes.KEEL_TH):
				if (this.KeelThrusterValues[i] > 0.0f)
					this.KeelThrusterValues[i] -= 0.25f;
				break;
			case(ThrusterTypes.PORT_TH):
				if (this.PortThrusterValues[i] > 0.0f)
					this.PortThrusterValues[i] -= 0.25f;
				break;
			case(ThrusterTypes.STARBOARD_TH):
				if (this.StarboardThrusterValues[i] > 0.0f)
					this.StarboardThrusterValues[i] -= 0.25f;
				break;
			case(ThrusterTypes.TOP_TH):
				if (this.TopThrusterValues[i] > 0.0f)
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
