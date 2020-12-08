using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class ui : MonoBehaviour {
	public Text Points;
	public int high_score;
	public GameObject modes;
	private bool isProcessing = false;

	// Use this for initialization
	 void Start () {
		high_score = PlayerPrefs.GetInt ("high_score");
		Points.text=high_score.ToString();

		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
			// enables saving game progress.
			.Build();
		
		PlayGamesPlatform.InitializeInstance(config);
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
		
		
		PlayGamesPlatform.Instance.localUser.Authenticate((bool success) => {
			if (success) {
				Debug.Log ("We're signed in! Welcome " + PlayGamesPlatform.Instance.localUser.userName);
				// We could start our game now
			} else {
				Debug.Log ("Oh... we're not signed in.");
			}
		});
	}
	public void more_game()
	{
		Application.OpenURL("https://play.google.com/store/apps/developer?id=Brocore+Studios");
	}
	public void show_leader()
		
	{ 
		Social.ShowLeaderboardUI();
	}
	
	public void show_achivements()
	{
		Social.ShowAchievementsUI();
	}
	public void share()
	{
		if(!isProcessing)
			StartCoroutine( ShareScreenshot() );
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
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "OMG! I Got " + high_score  + " points in Gem In A Ring game. Get it now free on Play Store : https://play.google.com/store/apps/details?id=com.Gulam_khan_jr.Gem_in_a_Ring");
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
	public void Showmodes()
	{
		modes.SetActive (true);
	}

	public void StartGame()
	{
		Application.LoadLevel ("Main_Game");
		iTween.Stop ();
		
	}
	public void StartGame_r2()
	{
		Application.LoadLevel ("Relay_2");
		iTween.Stop ();
	}
	public void StartGame_r3()
	{
		Application.LoadLevel ("Relay_3");
		iTween.Stop ();
		
	}
	public void Credits()
	{
		Application.LoadLevel ("Credit");
		iTween.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
