using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generator_script : MonoBehaviour {
	
	private float screenWidthInPoints;
	
	public GameObject[] availableObjects;    
	public List<GameObject> objects;
	
	public float objectsMinDistance = 5.0f;    
	public float objectsMaxDistance = 10.0f;
	
	public float objectsMinX = -2f;
	public float objectsMaxX = 2f;
	
	public float playerY ;    
	public float playercurrent;
	public float removeObjectsY;
	public float addObjectY;
	public float farthestObjectY ;
	public float objectPositionY ;
	public float objY;
	
	
	public float objectsMinRotation = -45.0f;
	public float objectsMaxRotation = 45.0f;
	public HUD hud;
	// Use this for initialization
	void Start () {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
		hud = FindObjectOfType(typeof(HUD)) as HUD; 
	}
	
	
	
	
	void AddObject(float lastObjectY)
	{
		//Generates a random index for the object to generate. This can be a laser or one of the coin packs.
		int randomIndex = Random.Range(0, availableObjects.Length);
		
		//Creates an instance of the object that was just randomly selected.
		GameObject obj = (GameObject)Instantiate(availableObjects[randomIndex]);
		
		//Sets the object’s position, using a random interval and a random height. This is controlled by script parameters. 
		objectPositionY = (lastObjectY + Random.Range(objectsMinDistance, objectsMaxDistance));
		if (objectPositionY > 0) {
			objectPositionY = -objectPositionY;
		}
		float randomX = Random.Range(objectsMinX, objectsMaxX);
		
		if (randomX < -3.8 || randomX > 3.8) {
			obj.transform.position = new Vector3 (randomX, objectPositionY, 0); 
		}
		
		//Adds a random rotation to the newly placed objects.
		float rotation = Random.Range(objectsMinRotation, objectsMaxRotation);
		obj.transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
		
		//Adds the newly created object to the objects list for tracking and ultimately, removal (when it leaves the screen).
		objects.Add(obj);            
	}
	
	void GenerateObjectsIfRequired()
	{
		//1
		playerY = -transform.position.y;        
		removeObjectsY = playerY - (screenWidthInPoints+3);
		addObjectY = playerY + screenWidthInPoints;
		farthestObjectY = 5;
		
		//2
		List<GameObject> objectsToRemove = new List<GameObject> ();
		
		foreach (var obj in objects) {
			//3
			objY = -obj.transform.position.y;
			
			//4
			farthestObjectY = Mathf.Max (farthestObjectY, objY);
			
			//5
			if (objY < removeObjectsY)            
				objectsToRemove.Add (obj);
		}
		
		//6
		foreach (var obj in objectsToRemove) {
			
			objects.Remove (obj);
			Destroy (obj);
			
			
			
		}
		
		//7
		
		if (farthestObjectY < addObjectY) {
			AddObject (farthestObjectY);
		}
	}
	// Update is called once per frame
	void Update () {
		
		playercurrent = transform.position.y;
		
	}
	void FixedUpdate()
	{
		if (hud.generate == true) {
			GenerateObjectsIfRequired ();
		}
	}
}
