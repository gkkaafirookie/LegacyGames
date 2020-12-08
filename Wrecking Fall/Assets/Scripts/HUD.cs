using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using ChartboostSDK;

public class HUD : MonoBehaviour {
	public Texture2D YoloIconTexture;
	public Texture2D OfficeiconTexture;
	
	public Text Points;
	public Text points_dlg;
	public Text high_score_dlg;
	public GameObject tap;
	public GameObject get; 
	public GameObject set; 
	public GameObject go; 
	
	
	public int points=0;
	public int high_score;
	public bool dead=false;
	public bool start;
	public bool generate;
	
	
	public GameObject restartDialog;
	public GameObject WonDialog; 
	
	public float time; 
	
	public AudioClip Point_sound;
	public AudioClip Dead_sound;
	public AudioClip claps;

	public bool sound=true;

	public bool adloaded;

	
	
	
	// Use this for initialization
	void Start () {
		start = false;
		generate = false;
		sound = true;
		adloaded = false;
		restartDialog.SetActive (false);
		high_score = PlayerPrefs.GetInt ("high_score");
		get.SetActive (false);
		set.SetActive (false);
		go.SetActive (false);
		// authenticate user:
		
	}
	
	public void RestartGame()
	{
		Chartboost.showInterstitial(CBLocation.Default);
		dead = false;
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	public void ExitToMenu()
	{
		Application.LoadLevel ("main_menu");
	}
	
	public void startgame()
	{
		start = true;
		tap.SetActive (false);
		
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		if (start == true) {
			time += Time.deltaTime;
			if(time>=3&&time<4)
			{
				get.SetActive (true);
				generate = true;
			}
			else if(time>=4&&time<5)
			{
				get.SetActive (false);
				set.SetActive (true);
				
			}
			else if(time>=5&&time<6)
			{
				set.SetActive (false);
				go.SetActive (true);
				
			}
			else if(time>=6)
			{
				go.SetActive (false);
				
				
				
			}
			
			
		}
		
		
		Points.text = points.ToString();
		if (dead == true) {
			if(adloaded == false)
			{
				Chartboost.showInterstitial(CBLocation.Default);
				adloaded =true;
			}
			if(sound==true)
			{
				AudioSource.PlayClipAtPoint(Dead_sound, transform.position,1f);
				sound = !sound;
			}

			if(points> high_score)
			{
				AudioSource.PlayClipAtPoint(claps, transform.position,0.5f);
				while(high_score!=points)
				{
					high_score++;
				}
			}
			PlayerPrefs.SetInt ("high_score",high_score);
			restartDialog.SetActive (true);
			points_dlg.text=points.ToString ();
			high_score_dlg.text = high_score.ToString ();
			PlayerPrefs.Save();

		}
	}
	
}

