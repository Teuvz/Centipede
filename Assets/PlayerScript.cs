using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	
	public static bool playing = false;
	public static bool canShoot = true;
	
	public int leftLimit = 60;
	public int rightLimit = 140;
	
	public Transform ammo;
	public Transform obstacle;
	public Transform ennemy;
	
	public int nbObstacles = 10;
	
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
		if ( PlayerScript.playing == true ) {
			bool canMove = true;
			
			if ( Input.GetAxisRaw("Horizontal") == -1 && transform.position.x <= this.leftLimit )
				canMove = false;
			
			if ( Input.GetAxisRaw("Horizontal") == 1 && transform.position.x >= this.rightLimit )
				canMove = false;
			
			if ( canMove )
				transform.Translate( new Vector3(Input.GetAxisRaw("Horizontal"),0,0));
			
			if ( Input.GetButton("Shoot") == true && PlayerScript.canShoot == true ) {
				PlayerScript.canShoot = false;
				Instantiate( ammo );
			}
		}
		
	}
	
	public void generateMushrooms() {
		
		int i = nbObstacles;
		while ( i > 0 ) {
			
			Instantiate( obstacle );
			
			i--;
		}
	}
	
}
