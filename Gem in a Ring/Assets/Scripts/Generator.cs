using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generator : MonoBehaviour {
	
	private float screenWidthInPoints;
	
	public GameObject[] availableObjects;    
	public GameObject[] inner_type;    
	public GameObject[] outter_type; 
	public Sprite[] outter_colour;
	public Sprite[] inner_colour;
	public GameObject points;


	public List<GameObject> objects;


	
	public float objectsMinDistance = 5.0f;    
	public float objectsMaxDistance = 10.0f;
	
	public float objectsMinX = -2f;
	public float objectsMaxX = 2f;

	public Sprite sprite1; 
	public GameObject inner;

	public float playerY ;    
	public float playercurrent;
	public float removeObjectsY;
	public float addObjectY;
	public float farthestObjectY ;
	public float objectPositionY ;
	public float objY;
	public float objY1;
	
	
	public float objectsMinRotation = -45.0f;
	public float objectsMaxRotation = 45.0f;
	public HUD hud;

	public int randomInner_type_indx=0;  //random index for inner ring type
	public int randomOut_type_indx=0; 
	public int randomIndex ;
	// Use this for initialization
	void Start () {
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
		hud = FindObjectOfType(typeof(HUD)) as HUD; 
	}
	
	
	
	
	void AddObject(float lastObjectY)
	{

		  // random index for outter type index

		//outter_type[1].GetComponent<SpriteRenderer>().sprite =outter_colour [5];

		//Generates a random index for the object to generate. This can be a laser or one of the coin packs.
		 randomIndex = Random.Range(0, availableObjects.Length);

		if (randomIndex >= 0 && randomIndex <=3)
		{
			randomInner_type_indx= Random.Range(0, 5);
				if(randomIndex ==0)
			{
			randomOut_type_indx= Random.Range(0, 5);
			}
			else if (randomIndex==1)
			{
				randomOut_type_indx= Random.Range(6, 11);
			}
			else if (randomIndex==2)
			{
				randomOut_type_indx= Random.Range(12, 17);
			}
			else if (randomIndex==3)
			{
				randomOut_type_indx= Random.Range(18, 23);
			}
		}
		else if (randomIndex >= 4 && randomIndex <=7)
		{
			randomInner_type_indx= Random.Range(6, 11);
			if(randomIndex ==4)
			{
				randomOut_type_indx= Random.Range(0, 5);
			}
			else if (randomIndex==5)
			{
				randomOut_type_indx= Random.Range(6, 11);
			}
			else if (randomIndex==6)
			{
				randomOut_type_indx= Random.Range(12, 17);
			}
			else if (randomIndex==7)
			{
				randomOut_type_indx= Random.Range(18, 23);
			}
		}
		else if (randomIndex >= 8 && randomIndex <=11)
		{
			randomInner_type_indx= Random.Range(12, 17);
			if(randomIndex ==8)
			{
				randomOut_type_indx= Random.Range(0, 5);
			}
			else if (randomIndex==9)
			{
				randomOut_type_indx= Random.Range(6, 11);
			}
			else if (randomIndex==10)
			{
				randomOut_type_indx= Random.Range(12, 17);
			}
			else if (randomIndex==11)
			{
				randomOut_type_indx= Random.Range(18, 23);
			}
		}
		else if (randomIndex >= 12 && randomIndex <=15)
		{
			randomInner_type_indx= Random.Range(18, 23);
			if(randomIndex ==12)
			{
				randomOut_type_indx= Random.Range(0, 5);
			}
			else if (randomIndex==13)
			{
				randomOut_type_indx= Random.Range(6, 11);
			}
			else if (randomIndex==14)
			{
				randomOut_type_indx= Random.Range(12, 17);
			}
			else if (randomIndex==15)
			{
				randomOut_type_indx= Random.Range(18, 23);
			}
		}
			//here is single ring
			else if (randomIndex >= 16 && randomIndex <=18 )
			{
				
				randomInner_type_indx= Random.Range(6, 11);
			}
			else if (randomIndex >= 19 && randomIndex <=21)
			{				
				randomInner_type_indx= Random.Range(12, 17);
			}
			else if (randomIndex >= 22 && randomIndex <25 )

			{
				randomInner_type_indx= Random.Range(18, 23);
			}
			else if (randomIndex >= 25 && randomIndex <=27 )
			{
				randomOut_type_indx= Random.Range(0, 5);
			}
			else if (randomIndex >= 28 && randomIndex <=30 )
			{
				randomOut_type_indx= Random.Range(6, 11);
			}
			else if (randomIndex >= 31 && randomIndex <=33 )
			{
				randomOut_type_indx= Random.Range(12, 17);
			}
			else if (randomIndex >= 34 && randomIndex <= 36)
			{
				randomOut_type_indx= Random.Range(18, 23);
			}
			

		
		if(randomIndex >=0 && randomIndex <15)
		{
		outter_type[randomIndex].GetComponent<SpriteRenderer>().sprite =outter_colour [randomOut_type_indx];
		availableObjects[randomIndex].GetComponent<SpriteRenderer>().sprite =inner_colour [randomInner_type_indx];
		}
		else if(randomIndex >=16 && randomIndex <=24)
		{
			availableObjects[randomIndex].GetComponent<SpriteRenderer>().sprite =inner_colour [randomInner_type_indx];
		}
		else if(randomIndex >=25 && randomIndex <=36)
		{
			outter_type[randomIndex].GetComponent<SpriteRenderer>().sprite =outter_colour [randomOut_type_indx];
		}

		//Creates an instance of the object that was just randomly selected.
		GameObject obj = (GameObject)Instantiate(availableObjects[randomIndex ]);
		GameObject pt = (GameObject)Instantiate(points

		                                       );

		//Sets the object’s position, using a random interval and a random height. This is controlled by script parameters. 
		objectPositionY = (lastObjectY + Random.Range(objectsMinDistance, objectsMaxDistance));
		if (objectPositionY > 0) {
			objectPositionY = -objectPositionY;
		}
		float randomX = Random.Range(objectsMinX, objectsMaxX);
		
	
			obj.transform.position = new Vector3 (randomX, objectPositionY, 0); 
		   pt.transform.position = new Vector3 (randomX, objectPositionY, 0); 
		
		//Adds a random rotation to the newly placed objects.
		float rotation = Random.Range(objectsMinRotation, objectsMaxRotation);
		obj.transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
	    

		//Adds the newly created object to the objects list for tracking and ultimately, removal (when it leaves the screen).
		objects.Add(obj); 
		objects.Add(pt);
	}
	
	void GenerateObjectsIfRequired()
	{
		//1
		playerY = -transform.position.y;        
		removeObjectsY = playerY - (screenWidthInPoints+3);
		addObjectY = playerY + screenWidthInPoints;
		farthestObjectY = 0;
		
		//2
		List<GameObject> objectsToRemove = new List<GameObject> ();
		List<GameObject> objectsToRemove1 = new List<GameObject> ();
		
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

		
		foreach (var pt in objects) {
			//3
			objY1 = -pt.transform.position.y;
			
			//5
			if (objY1 < removeObjectsY)            
				objectsToRemove1.Add (pt);
		}
		
		//6
		foreach (var pt in objectsToRemove1) {
			objects.Remove (pt);
			Destroy (pt);
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
	if(hud.start==true)
		{
			GenerateObjectsIfRequired ();
		}

	}
}
