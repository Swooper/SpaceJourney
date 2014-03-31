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

    public float[] AftThrusterScales;
    public float[] BowThrusterScales;
    public float[] KeelThrusterScales;
    public float[] PortThrusterScales;
    public float[] StarboardThrusterScales;
    public float[] TopThrusterScales;

	public float Scale;
	public AudioClip ThrusterSound;

	private enum ThrusterTypes {AFT_TH, BOW_TH, KEEL_TH, PORT_TH, STARBOARD_TH, TOP_TH};
	public int maxThrusters;

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

        AftThrusterScales = new float[maxThrusters];
        BowThrusterScales = new float[maxThrusters];
        KeelThrusterScales = new float[maxThrusters];
        PortThrusterScales = new float[maxThrusters];
        StarboardThrusterScales = new float[maxThrusters];
        TopThrusterScales = new float[maxThrusters];

        for (int i = 0; i < maxThrusters; i++) {
            AftThrusterScales[i] = 1.0f;
            BowThrusterScales[i] = 1.0f;
            KeelThrusterScales[i] = 1.0f;
            PortThrusterScales[i] = 1.0f;
            StarboardThrusterScales[i] = 1.0f;
            TopThrusterScales[i] = 1.0f;
        }

        this.AftThrusterScales[4] = 100f;

		FindThrusters ();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate() {
		// Apply force to each thruster
		for (int i = 0; i<maxThrusters; i++) {
			if(AftThrusters[i] != null)
				this.AftThrusters[i].rigidbody.AddForce(-this.AftThrusters[i].transform.forward * this.Scale * this.AftThrusterValues[i] * this.AftThrusterScales[i]);
			if(BowThrusters[i] != null)
                this.BowThrusters[i].rigidbody.AddForce(-this.BowThrusters[i].transform.forward * this.Scale * this.BowThrusterValues[i] * this.BowThrusterScales[i]);
			if(KeelThrusters[i] != null)
                this.KeelThrusters[i].rigidbody.AddForce(-this.KeelThrusters[i].transform.forward * this.Scale * this.KeelThrusterValues[i] * this.KeelThrusterScales[i]);
			if(PortThrusters[i] != null)
                this.PortThrusters[i].rigidbody.AddForce(-this.PortThrusters[i].transform.forward * this.Scale * this.PortThrusterValues[i] * this.PortThrusterScales[i]);
			if(StarboardThrusters[i] != null)
                this.StarboardThrusters[i].rigidbody.AddForce(-this.StarboardThrusters[i].transform.forward * this.Scale * this.StarboardThrusterValues[i] * this.StarboardThrusterScales[i]);
			if(TopThrusters[i] != null)
                this.TopThrusters[i].rigidbody.AddForce(-this.TopThrusters[i].transform.forward * this.Scale * this.TopThrusterValues[i] * this.TopThrusterScales[i]);
		}
    }

	void OnGUI () {
		// Af einhverjum astæðum þarf þessi koði að vera her en ekki i Update()
		Event e = Event.current;
		if (e.isKey && e.type == EventType.KeyUp) {
			switch (e.keyCode) {
				//Top & keel thrusters
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
				case(KeyCode.R):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 3);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 3);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 3);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 3);
						}
					}
					break;
				case(KeyCode.T):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 4);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 4);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 4);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 4);
						}
					}
					break;
				case(KeyCode.Y):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 5);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 5);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 5);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 5);
						}
					}
					break;
				case(KeyCode.U):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 6);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 6);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 6);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 6);
						}
					}
					break;
				case(KeyCode.I):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 7);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 7);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 7);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 7);
						}
					}
					break;
				case(KeyCode.O):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 8);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 8);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 8);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 8);
						}
					}
					break;
				case(KeyCode.P):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.TOP_TH, 9);
						}
						else {
							DecreaseThrust(ThrusterTypes.KEEL_TH, 9);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.TOP_TH, 9);
						}
						else {
							IncreaseThrust (ThrusterTypes.KEEL_TH, 9);
						}
					}
					break;
				// Aft & bow thrusters
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
				case(KeyCode.F):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.BOW_TH, 3);
						}
						else {
							DecreaseThrust(ThrusterTypes.AFT_TH, 3);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.BOW_TH, 3);
						}
						else {
							IncreaseThrust (ThrusterTypes.AFT_TH, 3);
						}
					}
					break;
				case(KeyCode.G):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.BOW_TH, 4);
						}
						else {
							DecreaseThrust(ThrusterTypes.AFT_TH, 4);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.BOW_TH, 4);
						}
						else {
							IncreaseThrust (ThrusterTypes.AFT_TH, 4);
						}
					}
					break;
				case(KeyCode.H):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.BOW_TH, 5);
						}
						else {
							DecreaseThrust(ThrusterTypes.AFT_TH, 5);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.BOW_TH, 5);
						}
						else {
							IncreaseThrust (ThrusterTypes.AFT_TH, 5);
						}
					}
					break;
				case(KeyCode.J):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.BOW_TH, 6);
						}
						else {
							DecreaseThrust(ThrusterTypes.AFT_TH, 6);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.BOW_TH, 6);
						}
						else {
							IncreaseThrust (ThrusterTypes.AFT_TH, 6);
						}
					}
					break;
				case(KeyCode.K):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.BOW_TH, 7);
						}
						else {
							DecreaseThrust(ThrusterTypes.AFT_TH, 7);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.BOW_TH, 7);
						}
						else {
							IncreaseThrust (ThrusterTypes.AFT_TH, 7);
						}
					}
                    break;
                case (KeyCode.L):
                    if (e.shift)
                    {
                        if (e.control)
                        {
                            DecreaseThrust(ThrusterTypes.BOW_TH, 8);
                        }
                        else
                        {
                            DecreaseThrust(ThrusterTypes.AFT_TH, 8);
                        }
                    }
                    else
                    {
                        if (e.control)
                        {
                            IncreaseThrust(ThrusterTypes.BOW_TH, 8);
                        }
                        else
                        {
                            IncreaseThrust(ThrusterTypes.AFT_TH, 8);
                        }
                    }
                    break;
                case (KeyCode.BackQuote):
                    if (e.shift)
                    {
                        if (e.control)
                        {
                            DecreaseThrust(ThrusterTypes.BOW_TH, 9);
                        }
                        else
                        {
                            DecreaseThrust(ThrusterTypes.AFT_TH, 9);
                        }
                    }
                    else
                    {
                        if (e.control)
                        {
                            IncreaseThrust(ThrusterTypes.BOW_TH, 9);
                        }
                        else
                        {
                            IncreaseThrust(ThrusterTypes.AFT_TH, 9);
                        }
                    }
                    break;

				// Port & starboard thrusters
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
				case(KeyCode.V):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.PORT_TH, 3);
						}
						else {
							DecreaseThrust(ThrusterTypes.STARBOARD_TH, 3);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.PORT_TH, 3);
						}
						else {
							IncreaseThrust (ThrusterTypes.STARBOARD_TH, 3);
						}
					}
					break;
				case(KeyCode.B):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.PORT_TH, 4);
						}
						else {
							DecreaseThrust(ThrusterTypes.STARBOARD_TH, 4);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.PORT_TH, 4);
						}
						else {
							IncreaseThrust (ThrusterTypes.STARBOARD_TH, 4);
						}
					}
					break;
				case(KeyCode.N):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.PORT_TH, 5);
						}
						else {
							DecreaseThrust(ThrusterTypes.STARBOARD_TH, 5);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.PORT_TH, 5);
						}
						else {
							IncreaseThrust (ThrusterTypes.STARBOARD_TH, 5);
						}
					}
					break;
				case(KeyCode.M):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.PORT_TH, 6);
						}
						else {
							DecreaseThrust(ThrusterTypes.STARBOARD_TH, 6);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.PORT_TH, 6);
						}
						else {
							IncreaseThrust (ThrusterTypes.STARBOARD_TH, 6);
						}
					}
					break;
				case(KeyCode.Comma):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.PORT_TH, 7);
						}
						else {
							DecreaseThrust(ThrusterTypes.STARBOARD_TH, 7);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.PORT_TH, 7);
						}
						else {
							IncreaseThrust (ThrusterTypes.STARBOARD_TH, 7);
						}
					}
                    break;
                case (KeyCode.Period):
                    if (e.shift)
                    {
                        if (e.control)
                        {
                            DecreaseThrust(ThrusterTypes.PORT_TH, 8);
                        }
                        else
                        {
                            DecreaseThrust(ThrusterTypes.STARBOARD_TH, 8);
                        }
                    }
                    else
                    {
                        if (e.control)
                        {
                            IncreaseThrust(ThrusterTypes.PORT_TH, 8);
                        }
                        else
                        {
                            IncreaseThrust(ThrusterTypes.STARBOARD_TH, 8);
                        }
                    }
                    break;
				case(KeyCode.Minus):
					if(e.shift) {
						if(e.control) {
							DecreaseThrust(ThrusterTypes.PORT_TH, 9);
						}
						else {
							DecreaseThrust(ThrusterTypes.STARBOARD_TH, 9);
						}
					}
					else {
						if(e.control) {
							IncreaseThrust(ThrusterTypes.PORT_TH, 9);
						}
						else {
							IncreaseThrust (ThrusterTypes.STARBOARD_TH, 9);
						}
					}
					break;
			}
		}
		
	}
	
	void IncreaseThrust(ThrusterTypes thrusterTypes, int i) {
		switch (thrusterTypes) {
			case(ThrusterTypes.AFT_TH):
				if (this.AftThrusterValues[i] < 1.0f) {
					this.AftThrusterValues[i] += 0.25f;
                    this.AftThrusters[i].particleEmitter.maxEnergy += 0.25f;
                    this.AftThrusters[i].particleEmitter.minEmission += 25.0f;
                    this.AftThrusters[i].particleEmitter.maxEmission += 25.0f;
                }
				break;
			case(ThrusterTypes.BOW_TH):
				if (this.BowThrusterValues[i] < 1.0f) {
					this.BowThrusterValues[i] += 0.25f;
                    this.BowThrusters[i].particleEmitter.maxEnergy += 0.25f;
                    this.BowThrusters[i].particleEmitter.minEmission += 25.0f;
                    this.BowThrusters[i].particleEmitter.maxEmission += 25.0f;
                }
				break;
			case(ThrusterTypes.KEEL_TH):
                if (this.KeelThrusterValues[i] < 1.0f) {
                    this.KeelThrusterValues[i] += 0.25f;
                    this.KeelThrusters[i].particleEmitter.maxEnergy += 0.25f;
                    this.KeelThrusters[i].particleEmitter.minEmission += 25.0f;
                    this.KeelThrusters[i].particleEmitter.maxEmission += 25.0f;
                }
				break;
			case(ThrusterTypes.PORT_TH):
				if (this.PortThrusterValues[i] < 1.0f) {
					this.PortThrusterValues[i] += 0.25f;
                    this.PortThrusters[i].particleEmitter.maxEnergy += 0.25f;
                    this.PortThrusters[i].particleEmitter.minEmission += 25.0f;
                    this.PortThrusters[i].particleEmitter.maxEmission += 25.0f;
                }
				break;
			case(ThrusterTypes.STARBOARD_TH):
				if (this.StarboardThrusterValues[i] < 1.0f) {
					this.StarboardThrusterValues[i] += 0.25f;
                    this.StarboardThrusters[i].particleEmitter.maxEnergy += 0.25f;
                    this.StarboardThrusters[i].particleEmitter.minEmission += 25.0f;
                    this.StarboardThrusters[i].particleEmitter.maxEmission += 25.0f;
                }
				break;
			case(ThrusterTypes.TOP_TH):
				if (this.TopThrusterValues[i] < 1.0f) {
                    this.TopThrusterValues[i] += 0.25f;
                    this.TopThrusters[i].particleEmitter.maxEnergy += 0.25f;
                    this.TopThrusters[i].particleEmitter.minEmission += 25.0f;
                    this.TopThrusters[i].particleEmitter.maxEmission += 25.0f;
                }
				break;
		}
		//audio.clip = ThrusterSound;
		//audio.loop = true;
		AudioSource.PlayClipAtPoint(ThrusterSound, transform.position);
	}
	
	void DecreaseThrust(ThrusterTypes thrusterTypes, int i) {
		switch (thrusterTypes) {
			case(ThrusterTypes.AFT_TH):
				if (this.AftThrusterValues[i] > 0.0f) {
					this.AftThrusterValues[i] -= 0.25f;
                    this.AftThrusters[i].particleEmitter.maxEnergy -= 0.25f;
                    this.AftThrusters[i].particleEmitter.minEmission -= 25.0f;
                    this.AftThrusters[i].particleEmitter.maxEmission -= 25.0f;
                }
				break;
			case(ThrusterTypes.BOW_TH):
				if (this.BowThrusterValues[i] > 0.0f) {
					this.BowThrusterValues[i] -= 0.25f;
                    this.BowThrusters[i].particleEmitter.maxEnergy -= 0.25f;
                    this.BowThrusters[i].particleEmitter.minEmission -= 25.0f;
                    this.BowThrusters[i].particleEmitter.maxEmission -= 25.0f;
                }
				break;
			case(ThrusterTypes.KEEL_TH):
				if (this.KeelThrusterValues[i] > 0.0f) {
					this.KeelThrusterValues[i] -= 0.25f;
                    this.KeelThrusters[i].particleEmitter.maxEnergy -= 0.25f;
                    this.KeelThrusters[i].particleEmitter.minEmission -= 25.0f;
                    this.KeelThrusters[i].particleEmitter.maxEmission -= 25.0f;
                }
				break;
			case(ThrusterTypes.PORT_TH):
				if (this.PortThrusterValues[i] > 0.0f) {
					this.PortThrusterValues[i] -= 0.25f;
                    this.PortThrusters[i].particleEmitter.maxEnergy -= 0.25f;
                    this.PortThrusters[i].particleEmitter.minEmission -= 25.0f;
                    this.PortThrusters[i].particleEmitter.maxEmission -= 25.0f;
                }
				break;
			case(ThrusterTypes.STARBOARD_TH):
				if (this.StarboardThrusterValues[i] > 0.0f) {
					this.StarboardThrusterValues[i] -= 0.25f;
                    this.StarboardThrusters[i].particleEmitter.maxEnergy -= 0.25f;
                    this.StarboardThrusters[i].particleEmitter.minEmission -= 25.0f;
                    this.StarboardThrusters[i].particleEmitter.maxEmission -= 25.0f;
                }
				break;
			case(ThrusterTypes.TOP_TH):
				if (this.TopThrusterValues[i] > 0.0f) {
                    this.TopThrusterValues[i] -= 0.25f;
                    this.TopThrusters[i].particleEmitter.maxEnergy -= 0.25f;
                    this.TopThrusters[i].particleEmitter.minEmission -= 25.0f;
                    this.TopThrusters[i].particleEmitter.maxEmission -= 25.0f;
                }
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
