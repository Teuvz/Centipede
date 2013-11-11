using UnityEngine;
using System.Collections;

public class CentepedeScript : MonoBehaviour {
	
	public string direction = "right";
	public float speed = 0.5f;
	public float maxX = 140;
	public float minX = 60;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if ( (direction == "right" && transform.position.x >= maxX) || (direction == "left" && transform.position.x <= minX) ) {
			
			if ( direction == "right" )
				direction = "left";
			else
				direction = "right";
			
			transform.Translate( new Vector3(0,0,-5) );
			
		}
		
		if ( direction == "right" ) {
			transform.Translate( new Vector3(speed,0,0) );
		} else {
			transform.Translate( new Vector3(-speed,0,0) );
		}
		
	}
	
}
