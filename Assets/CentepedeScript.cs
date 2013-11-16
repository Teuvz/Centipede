using UnityEngine;
using System.Collections;

public class CentepedeScript : MonoBehaviour {
	
	static public bool moving = false;
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
			changeDirection();	
		}
		
		if ( CentepedeScript.moving == true ) {
			if ( direction == "right" ) {
				transform.Translate( new Vector3(speed,0,0) );
			} else {
				transform.Translate( new Vector3(-speed,0,0) );
			}
		}
		
	}
	
	void OnTriggerEnter( Collider collider ) {
		
		if ( collider.gameObject.tag == "Mushroom" ) {
			changeDirection();
		}
	}
	
	void changeDirection() {
		
		if ( direction == "right" )
			direction = "left";
		else
			direction = "right";
		
		transform.Translate( new Vector3(0,0,-5) );
		
	}
	
	public void kill() {
		Destroy(this.rigidbody);
		Destroy(this.gameObject);
	}
	
}
