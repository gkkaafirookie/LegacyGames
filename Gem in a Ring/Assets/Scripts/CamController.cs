using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
	public HUD hud;
	public float time;
	public float bgchng;
	public bool rot;
	public bool act;
	public float randomX; 
		public float bg;
	
	// Use this for initialization
	void Start () {
		act=true;
		hud = FindObjectOfType(typeof(HUD)) as HUD;
		iTween.RotateTo(gameObject, iTween.Hash("z", 45, "time", 4, "loopType", iTween.LoopType.pingPong, "easeType", iTween.EaseType.linear));
		randomX = Random.Range(10, 15);
	}
	
	// Update is called once per frame
	void Update () {
	
		bgchng +=Time.deltaTime ;

		float t=0.0f;

		Color32 currentColor = Camera.main.backgroundColor;
		Color32 bgColor= new Color32 (0,0,0,1);

		if(bgchng >= 5.0f)
		{
		bg=Random.Range (0,13);
		if(bg>0 && bg<=1)
		{
	      bgColor = new Color32 (0,0,0,1);
		}
		else if(bg>1 && bg<=2)
		{
			bgColor = new Color32  (51,0,25,1);
		}
		else if(bg>2 && bg<=3)
		{
			bgColor = new Color32  (51,0,51,1);
		}
		else if(bg>3 && bg<=4)
		{
			bgColor = new Color32 (25,0,51,1);
		}
		else if(bg>4 && bg<=5)
		{
			bgColor = new Color32 (0,0,51,1);
		}
		else if(bg>5 && bg<=6)
		{
			bgColor = new Color32 (0,25,51,1);
		}
		else if(bg>6 && bg<=7)
		{
			bgColor = new Color32 (0,51,51,1);
		}
		else if(bg>7 && bg<=8)
		{
			bgColor = new Color32 (0,51,25,1);
		}
		else if(bg>8 && bg<=9)
		{
			bgColor = new Color32 (0,51,0,1);
		}
		else if(bg>9 && bg<=10)
		{
			bgColor = new Color32 (25,51,0,1);
		}
		else if(bg>10 && bg<=11)
		{
			bgColor = new Color32 (51,51,0,1);
		}
		else if(bg>11 && bg<=12)
		{
			bgColor = new Color32 (51,25,0,1);
		}
		else if(bg>12 && bg<=13)
		{
			bgColor = new Color32 (51,0,0,1);
		}
		while( t < 1.0 )
		{
			Camera.main.backgroundColor = Color.Lerp(currentColor, bgColor, t );
			t += Time.deltaTime;
		}
			bgchng =0;
		}
		time += Time.deltaTime;
		if (time < randomX)
		{
			if(Application.loadedLevelName !="Main_menu")
			{
			hud.pc=hud.pc+5;

				if(rot ==false)
				{
					iTween.Resume();

				}
			if (rot == true)
			{
		 iTween.Pause();
			}

			}

		}
	 if ( time >= randomX)

		{  
			if(Application.loadedLevelName !="Main_menu")
			{
			randomX = Random.Range(10, 15);
			hud.pc=0;
			rot = !rot;
			time = 0 ;

		}
		}
	}
	
}


