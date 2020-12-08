using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Prime31;

using System;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class HUD : MonoBehaviour {
	public int points;
	public string round;
	public int pc;
	public int high_score;
	public int high_score_c;
	public int high_scorex2;
	public int high_scorex3;
	public string which_hi;

	public bool start;
	public bool dead;
	public float dlay;

	public int player_sound;
	public int player_music;


	public Text Points;
	public Text highscore_dlg;
	public Text points_dlg;
	public Text Round;
	public Text timmer;

	public int mode;

	public string share_txt;

	public Toggle soundon;
	public Toggle musicon;
	public AudioSource cam_;
	public GameObject restartDialog;
	public GameObject pause_dlg;
	public GameObject Points_dlg;
	public GameObject start_dlg;
	private bool isProcessing = false;

	public AudioClip Point_sound;
	public AudioClip Dead_sound;
	public AudioClip claps;
	public AudioClip Audio1;
	public AudioClip Audio2;

	
	public bool sound=true;
	public bool music_=true;
	public bool sound_=true;
	public GameObject cam;

	public string highscore_id;
	public string Achivement_1;
	public string Achivement_2;
	public string Achivement_3;
	public string Achivement_4;
	public string Achivement_5;



	public bool loadad = false;

	
	public int temp =0;

	public int cun=0;

	// Use this for initialization
	void Start () {



		high_score_c = PlayerPrefs.GetInt ("high_score");
		high_scorex2 = PlayerPrefs.GetInt ("high_score_relayx2");
		high_scorex3 = PlayerPrefs.GetInt ("high_score_relayx3");
		player_music =PlayerPrefs.GetInt("music0");
		player_sound=PlayerPrefs.GetInt ("sound1");


		if (mode ==1)
		{
		
			highscore_id = "CgkItbKmo4wfEAIQBQ";
			Achivement_1 = "CgkItbKmo4wfEAIQAA";
			Achivement_2 = "CgkItbKmo4wfEAIQAQ";
			Achivement_3 =  "CgkItbKmo4wfEAIQAg";
			Achivement_4 = "CgkItbKmo4wfEAIQAw";
			Achivement_5 = "CgkItbKmo4wfEAIQBA";

			high_score = high_score_c;
			which_hi = "high_score";
		}
		
		
		else if (mode == 2)
		{

			highscore_id = "CgkItbKmo4wfEAIQBw";
			Achivement_1 = "CgkItbKmo4wfEAIQCQ";
			Achivement_2 = "CgkItbKmo4wfEAIQCg";
			Achivement_3 =  "CgkItbKmo4wfEAIQCw";
			Achivement_4 = "CgkItbKmo4wfEAIQDA";
			Achivement_5 = "CgkItbKmo4wfEAIQDQ";

			high_score=high_scorex2;
			which_hi = "high_score_relayx2";
		}
		else if (mode == 3)
		{

			highscore_id = "CgkItbKmo4wfEAIQCA";
			Achivement_1 = "CgkItbKmo4wfEAIQEg";
			Achivement_2 = "CgkItbKmo4wfEAIQEQ";
			Achivement_3 =  "CgkItbKmo4wfEAIQEA";
			Achivement_4 = "CgkItbKmo4wfEAIQDw";
			Achivement_5 = "CgkItbKmo4wfEAIQDg";
			high_score=high_scorex3;
			which_hi = "high_score_relayx3";
		}

		//RequestBanner();
		//RequestInterstitial();
		//bannerView.Hide();
			start=false;
		Points_dlg.SetActive (false);
		restartDialog.SetActive (false);
		pause_dlg.SetActive(false );

		if(player_sound == 1)
		{
			soundon.isOn = true;
		}
		else if(player_sound == 0)
		{
			soundon.isOn = false;
		}
		
		if(player_music == 1)
		{
			musicon.isOn = false;
		}
		
		else if(player_music== 0)
		{
			musicon.isOn = true;
			
		}


	}
	public void share()
	{
		if(!isProcessing)
			StartCoroutine( ShareScreenshot() );
	}

	public void pause()
	{

	
		Time.timeScale=0;
		pause_dlg.SetActive(true);
	}
	public void resume()
	{
	
		Time.timeScale=1;
		pause_dlg.SetActive(false);
	}


	
	public IEnumerator ShareScreenshot()
	{
		isProcessing = true;
		
		// wait for graphics to render
		yield return new WaitForEndOfFrame();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		// create the texture
		Texture2D screenTexture = new Texture2D(Screen.width, Screen.height,TextureFormat.RGB24,true);
		
		// put buffer into texture
		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
		
		// apply
		screenTexture.Apply();
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
		
		byte[] dataToSave = screenTexture.EncodeToPNG();
		
		string destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
		
		File.WriteAllBytes(destination, dataToSave);
		
		if(!Application.isEditor)
		{
			// block to open the file and share it ------------START
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "OMG!");
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "OMG! I Got " + points  + " points in Gem In A Ring game. Get it now free on Play Store : https://play.google.com/store/apps/details?id=com.Gulam_khan_jr.Gem_in_a_Ring");
			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			
			// option one WITHOUT chooser:
			currentActivity.Call("startActivity", intentObject);
			
			// option two WITH chooser:
			//AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "YO BRO! WANNA SHARE?");
			//currentActivity.Call("startActivity", jChooser);
			
			// block to open the file and share it ------------END
			
		}
		isProcessing = false;
		
		
	}
	public void RestartGame()
	{
		iTween.Stop();
	  
		


		dead = false;
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	public void ExitToMenu()
	{
		iTween.Stop();
		
		Application.LoadLevel ("Main_menu");
	}

	public void StartGame()
	{
		start=true;
		Points_dlg.SetActive (true);
		start_dlg.SetActive(false);
	}
	
	public void show_leader()
		
	{ 
		Social.ShowLeaderboardUI();
	}
	
	public void show_achivements()
	{
		Social.ShowAchievementsUI();
	}
	// Update is called once per frame
	void FixedUpdate () {


	
			
		if (mode ==1)
		{
		Points .text = points.ToString ();

		}


		else if (mode == 2)
		{
			Points.text = points.ToString();
			Round.text = round.ToString();

		}
		else if (mode == 3)
		{
			Points.text = points.ToString();
			Round.text = round.ToString();

		}
		if(cun==0)
		{
		if(points ==0&&dead==true)
		{
			Social.ReportProgress(Achivement_1, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		}
		else if(points ==15)
		{
			Social.ReportProgress(Achivement_2, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		else if(points ==30)
		{
			Social.ReportProgress(Achivement_3, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		else if(points ==45)
		{
			Social.ReportProgress(Achivement_4, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		else if(points ==60)
		{
			Social.ReportProgress(Achivement_5, 100.0f, (bool success) => {
				// handle success or failure
			});
		}


           if(soundon.isOn ==true)
		{
			player_sound=1;
			PlayerPrefs.SetInt ("sound1",player_sound);
			sound_ = true;
			PlayerPrefs.Save();
		}
		else  if(soundon.isOn ==false)
		{   player_sound=0;
			PlayerPrefs.SetInt ("sound1",player_sound);
			sound_ = false;
			PlayerPrefs.Save();
		}

		if(musicon.isOn ==true)
		{
			player_music=0;
			PlayerPrefs.SetInt ("music0",player_music);
			cam_.mute = false; 
			PlayerPrefs.Save();
		}
		else  if(musicon.isOn ==false)
		{   player_music=1;
			PlayerPrefs.SetInt ("music0",player_music);
			cam_.mute = true; 
			PlayerPrefs.Save();
		} 



		if (dead == true) {
			if(cun==0)
			{
				dlay += Time.deltaTime;


			if(points> high_score)
			{
				if(sound_ == false)
				{
				AudioSource.PlayClipAtPoint(claps, transform.position,0.5f);
				}

				while(high_score!=points)
				{
					high_score++;
				}
				PlayerPrefs.SetInt (which_hi,high_score);
				Social.ReportScore(high_score,highscore_id, (bool success) => {
					// handle success or failure
				});
			}

			restartDialog.SetActive (true);
			points_dlg.text = points.ToString();
			highscore_dlg.text = high_score.ToString ();
			PlayerPrefs.Save();
				cun=99;
		}
		}
	
	}

}
