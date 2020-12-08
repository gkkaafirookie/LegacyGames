using UnityEngine;
using System.Collections;

using System;
using ChartboostSDK;

public class Ui : MonoBehaviour {


	// Use this for initialization
	public void startgame()
	{
		Chartboost.showInterstitial(CBLocation.Default);
		Application.LoadLevel ("Main_Scene");

	}
	public void credit()
	{
		Application.LoadLevel ("Credit");
	}
	
	public void show_leader()
		
	{ 
		Social.ShowLeaderboardUI();
	}
	
	public void show_achivements()
	{
		Social.ShowAchievementsUI();
	}
	
	
	public void Start()
	{


	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
