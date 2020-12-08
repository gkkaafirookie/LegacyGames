using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float speedDn = -1f;
	public float speedLR = -0.02f;
	private Vector3 newPosition;
	public bool lookAtRight = true;
	public HUD hud;
	public AudioClip sound;

	public GameObject rip;

	// Use this for initialization
	void Start () {
		newPosition = transform.position;
		hud = FindObjectOfType(typeof(HUD)) as HUD; 
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.CompareTag ("Enemy")) {
			hud.dead =true;
			Vector3 pos = transform.position;
			Instantiate (rip, pos, Quaternion.identity);
			DestroyObject (gameObject);
		}
		
	}
	void Awake () {
		// Make the game run as fast as possible in the web player
		Application.targetFrameRate = 300;
	}

	// Update is called once per frame
	void Update () {
		if (hud.dead == true) {

			DestroyObject (gameObject);
		}
		if (hud.start == true) {
			newPosition.y += Time.deltaTime * speedDn;
			
			if (lookAtRight) {

				gameObject.transform.position = new Vector3 (gameObject.transform.position.x + speedLR, newPosition.y, gameObject.transform.position.z);
			} else {
				gameObject.transform.position = new Vector3 (gameObject.transform.position.x - speedLR, newPosition.y, gameObject.transform.position.z);
			}
			
			if (Input.GetMouseButtonDown (0)) {
				
				if (lookAtRight) {
					float rotation = -10f;
					transform.rotation = Quaternion.Euler (Vector3.forward * rotation);
					
				} else if (!lookAtRight) {
					
					float rotation = 10f;
					transform.rotation = Quaternion.Euler (Vector3.forward * rotation);
				}
				
				lookAtRight = !lookAtRight;
				AudioSource.PlayClipAtPoint(sound, transform.position,1f);
			} else {
				speedDn = -1f;
			}
		}
		
	}
	
	
}
