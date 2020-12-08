using UnityEngine;
using System.Collections;

using System;
public class CameraController : MonoBehaviour {
	public float speed = 1f;
	public Vector3 newPosition;
	public HUD hud;
	

	
	public bool adloaded=true;
	
	
	// Use this for initialization
	void Start () {
		newPosition = transform.position;
		hud = FindObjectOfType(typeof(HUD)) as HUD; 

		adloaded = true;
	}
	
	

	
	// Update is called once per frame
	void Update () {
		if (hud.start == true) {
			newPosition.y -= Time.deltaTime * speed;
			newPosition.x=0;

			transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
		}
		if(hud.dead==true&&adloaded==true)
		{

			adloaded = false;
		}
		else if(hud.dead==false)
		{
			adloaded=true;
		}
		
		
	}
}
