using UnityEngine;
using System.Collections;

public class ball_swing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.RotateTo(gameObject, iTween.Hash("z", 60, "time", 1.75, "loopType", iTween.LoopType.pingPong, "easeType", iTween.EaseType.linear));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
