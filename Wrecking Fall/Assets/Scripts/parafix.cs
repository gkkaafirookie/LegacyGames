using UnityEngine;
using System.Collections;

public class parafix : MonoBehaviour {
	public HUD hud;
	public GameObject rip;
	// Use this for initialization
	void Start () {
		hud = FindObjectOfType(typeof(HUD)) as HUD; 
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Point")) {
			hud.points++; 
			AudioSource.PlayClipAtPoint(hud.Point_sound, transform.position);
		} else if (other.CompareTag ("Enemy")) {
			Vector3 pos = transform.position;
			Instantiate (rip, pos, Quaternion.identity);
			hud.dead =true;
			AudioSource.PlayClipAtPoint(hud.Dead_sound, transform.position);
			DestroyObject (gameObject);
		}
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
