using UnityEngine;
using System.Collections;

using System;

public class Credits : MonoBehaviour
{
	public float speed = 1f;
	public GameObject sp;
	public GameObject credit;
	public bool visible;
	private Vector3 newPosition;
	// Use this for initialization
	void Start () {
		newPosition = transform.position;
		visible = true;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.CompareTag ("des")) {
			visible =false;
		

		}
		
	}
	public void backtomainmenu()
	{
		Application.LoadLevel ("main_menu");
	}
	// Update is called once per frame
	void Update () {

		if (visible == true) {

			newPosition.y += Time.deltaTime * speed;
			transform.position = newPosition;

		}
		if (visible == false) {
			Vector3 pos = sp.transform.position;
			Instantiate (credit, pos, Quaternion.identity);
			visible = true;
			DestroyObject (gameObject);
		}
	}
}