using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public int verticalLimit = 150;
	bool exploding = false;
	public int speed = 3;
	
	// Use this for initialization
	void Start () {
		
		Vector3 pos = new Vector3( GameObject.Find("Player").gameObject.transform.position.x, 1, 73 );
		transform.position= pos;
		
	}
	
	// Update is called once per frame
	void Update () {
					
		if ( exploding == true ) {
			(GetComponent("Light") as Light).range -= 0.5f;
			return;
		}
		
		if ( transform.position.z <= verticalLimit ) {
			transform.Translate( new Vector3(0,0,speed) );
		} else {
			Explode();
		}
		
	}
	
	void OnTriggerEnter( Collider collider ) {
		
		Explode();
		
		if ( collider.gameObject.tag == "Mushroom" && (collider.gameObject.GetComponent("MushroomScript") as MushroomScript).hit() == 0 ) {
			Destroy(collider.gameObject);
		}
		
	}
	
	void Explode() {
		PlayerScript.canShoot = true;
		exploding = true;
		Destroy(gameObject,1);
	}
}
