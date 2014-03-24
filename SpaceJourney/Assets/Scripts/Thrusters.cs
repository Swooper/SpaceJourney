using UnityEngine;
using System.Collections;

public class Thrusters : MonoBehaviour {
	public GameObject AftThruster;
	public GameObject BowThruster;
	public GameObject KeelThruster;
	public GameObject PortThruster;
	public GameObject StarboardThruster;
	public GameObject TopThruster;

	
	public float AftThrusterValue;
	public float BowThrusterValue;
	public float KeelThrusterValue;
	public float PortThrusterValue;
	public float StarboardThrusterValue;
	public float TopThrusterValue;


	public float Scale;


	private enum ThrusterTypes {AFT_TH, BOW_TH, KEEL_TH, PORT_TH, STARBOARD_TH, TOP_TH};

	// Use this for initialization
	void Start () {
	
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
		this.KeelThruster.rigidbody.AddForce(-this.KeelThruster.transform.forward*this.Scale*this.KeelThrusterValue);
		this.TopThruster.rigidbody.AddForce(-this.TopThruster.transform.forward*this.Scale*this.TopThrusterValue);
	}
	
	void IncreaseThrust(ThrusterTypes thrusterTypes) {
		if (thrusterTypes == ThrusterTypes.KEEL_TH)
			if (this.KeelThrusterValue < 1.0f)
				this.KeelThrusterValue += 0.25f;
		if (thrusterTypes == ThrusterTypes.TOP_TH)
			if (this.TopThrusterValue < 1.0f)
				this.TopThrusterValue += 0.25f;
	}
	
	void DecreaseThrust(ThrusterTypes thrusterTypes) {
		if (thrusterTypes == ThrusterTypes.KEEL_TH)
			if (this.KeelThrusterValue > 0.0f)
				this.KeelThrusterValue -= 0.25f;
		if (thrusterTypes == ThrusterTypes.TOP_TH)
			if (this.TopThrusterValue > 0.0f)
				this.TopThrusterValue -= 0.25f;
	}
}
