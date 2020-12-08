using UnityEngine;
using System.Collections;

public class Game_logic : MonoBehaviour {
	public GameObject gem;
	public GameObject outer_ring;
	public GameObject Cam;
	public GameObject shatter;

	public float speedDn = -1f;
	private Vector3 newPosition;
	public Vector3 newPosition_cam;
	public bool pressed;
	public bool pressable;
	public float time;
	public float dlay;
	bool timer=false;
	public HUD hud;

	Animator animator;
	// Use this for initialization
	void Start () {
		newPosition = transform.position;
		newPosition_cam = Cam.transform.position;
		hud = FindObjectOfType(typeof(HUD)) as HUD; 
		pressable =true;
		animator = GetComponent<Animator> ();
		hud.mode=1;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.CompareTag ("Enemy")) {
			if(hud.sound_ ==false )
			{
			AudioSource.PlayClipAtPoint(hud.Dead_sound, transform.position,0.5f);
			}

			hud.restartDialog.SetActive (true);
			hud.Points_dlg.SetActive (false);
			Vector3 pos = gem.transform.position;
		

		
				Instantiate (shatter, pos, Quaternion.identity);
				hud.dead =true ;
			DestroyObject (gem);

		}
		else if (other.CompareTag ("point")){
			hud.points++;

			pressable=true;
			if(hud.sound_ ==false )
			{
			AudioSource.PlayClipAtPoint(hud.Point_sound, transform.position,0.5f);
			}
		}
		else if (other.CompareTag ("inner")){
			pressable = true;
		}
		
	}
	public void c_pressed()
	{
		pressed=true;
		time=0f;
	}
	public void n_pressed()
	{
		pressed=false;
		pressable=false;
		time=0f;
	}
	
	// Update is called once per frame
	void Update () {
		time = Time.deltaTime;
		if(timer==true)
		{
		dlay +=Time.deltaTime;
		}
		newPosition_cam.x=0;
		if (hud.start == true) {

		

		if(pressed==true)
		{
			if(pressable==true)
			{
				animator.SetBool ("stopped", true);
			time=0f;
			transform.position = Vector3.Lerp(transform.position,transform.position, time * 0);

			}
			else if (pressable==false)
			{
				animator.SetBool ("stopped", false);
				newPosition.y -= time * speedDn;
				transform.position = Vector3.Lerp(transform.position, newPosition, time *speedDn);
				
					newPosition_cam.y -= Time.deltaTime * (speedDn);
				

					Cam.transform.position = Vector3.Lerp(Cam.transform.position, newPosition_cam, Time.deltaTime * speedDn);
			}
		}
		else if(pressed==false)
		{
			animator.SetBool ("stopped", false);
			newPosition.y -= time * speedDn;
			transform.position = Vector3.Lerp(transform.position, newPosition, time *speedDn);

				newPosition_cam.y -= Time.deltaTime * (speedDn);

			
				Cam.transform.position = Vector3.Lerp(Cam.transform.position, newPosition_cam, Time.deltaTime * speedDn);
		}
	}
	}

}
