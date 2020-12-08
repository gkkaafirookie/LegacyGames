using UnityEngine;
using System.Collections;

public class pully_slide : MonoBehaviour {

	public float speed = 1f;
	private Vector3 newPosition;
	public Vector3 pos;
	Vector3 current_pos;
	
	public bool right=true;
	public float range = 2f;
	
	public float distance;
	public float time; 
	// Use this for initialization
	void Start () {
		newPosition = transform.position;
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		current_pos = transform.position;
		distance = Vector3.Distance (pos, current_pos);
		time += Time.deltaTime;
		if (time >= 5) {
			if (right == true) {
				
				newPosition.x += Time.deltaTime * speed;
				transform.position = newPosition;
				
			}
		}
		
		if (distance >= range) {
			right = false;
		}
	}
}
