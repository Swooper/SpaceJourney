using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    private GameObject spaceShip;       // The space ship to rotate around
    private float x;                    // The x axis rotation
    private float y;                    // The y axis rotation
    private float distance = 10.0f;     // The distance from the ship

    public float xSpeed = 250.0f;       // X axis speed
    public float ySpeed = 120.0f;       // Y axis speed
    public float scrollSpeed = 10.0f;   // Scroll wheel speed

    public float yMinLimit = -80.0f;    // The minimum allowed y rotation
    public float yMaxLimit = 80.0f;     // The maximum allowed y rotation

    public float scrollMinLimit = 2.0f; // The minimum allowed scroll distance
    public float scrollMaxLimit = 20.0f;// The maximum allowed scroll distance

	private GameObject HUD;

	// Use this for initialization
	void Start () {
        this.spaceShip = GameObject.Find("SpaceShip");
        this.x = transform.eulerAngles.y;
        this.y = transform.eulerAngles.x;

        // Make the rigid body not change rotation
        if (rigidbody)
            rigidbody.freezeRotation = true;

		HUD = GameObject.Find("HUD Manager");
	}

	void Update() {
	}

	void OnGUI() {
		RaycastHit hit;
		// Ray selected = new Ray(transform.position, transform.forward+transform.up);
		// Ray selected = Camera.main. ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
		Ray selected = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(selected, out hit, 100.0f))
		{
			if (hit.collider.tag == "Thruster") {
				GUI.Button(new Rect(Screen.width/2 - 70, 145, 140, 30), hit.collider.gameObject.name);
				HUD.SendMessage("HighlightThruster", hit.collider.gameObject.name);
			}
		}
	}
	
	// Update is called once per frame
    void LateUpdate() {
        // Check if the player presses or releases the right mouse button
        if (Input.GetMouseButtonDown(1))
            Screen.lockCursor = true;
        else if (Input.GetMouseButtonUp(1))
            Screen.lockCursor = false;

        // If the player is pressing the mouse button apply rotation
        if (Screen.lockCursor) {
            this.x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            this.y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
        }

        // Always apply the scroll wheel
        float newDistance = this.distance - Input.GetAxis("Mouse ScrollWheel") * this.scrollSpeed;
        if (newDistance < this.scrollMaxLimit && newDistance > this.scrollMinLimit)
            this.distance = newDistance;

        // Finaly apply the rotation and distance to the camera
        if (this.spaceShip) {
            this.y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * (new Vector3(0.0f, 0.0f, -distance)) + spaceShip.transform.position;

            transform.rotation = rotation;
            transform.position = position;
        }
	}

    float ClampAngle(float angle, float min, float max) {
	    if (angle < -360)
		    angle += 360;
	    if (angle > 360)
		    angle -= 360;
	    return Mathf.Clamp(angle, min, max);
    }
}
