using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	public float introTime = 5;
	public bool playIntro = true;
	bool introPlayed = false;
	
	public float mushroomCamTimer = 5;
	public bool playMushroomCam = true;
	bool mushroomPlayed = false;
	
	public int cameraSetupMax = 53;
	bool cameraSetup = false;
	public bool doCameraSetup = true;
	
	// Use this for initialization
	void Start () {
	
		if ( playIntro == true ) {
			GameObject.Find("Intro Camera").camera.enabled = true;
		}
		
		if ( playMushroomCam ) {
			GameObject.Find("Mushroom Camera").camera.enabled = true;
		}
		
		if ( doCameraSetup == true && playMushroomCam == false )
			( GameObject.Find("Player").GetComponent("PlayerScript") as PlayerScript ).generateMushrooms();
		
		if ( doCameraSetup == true && playMushroomCam == true )
			( GameObject.Find("Player").GetComponent("PlayerScript") as PlayerScript ).generateMushrooms();
		
		if ( doCameraSetup == false ) {
			( GameObject.Find("Player").GetComponent("PlayerScript") as PlayerScript ).generateMushrooms();
			transform.Translate( new Vector3(0,13,0) );
			PlayerScript.playing = true;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if ( playIntro == true && introPlayed == false ) {
			
			if ( introTime > 0 ) {
				GameObject.Find("Intro Camera").transform.LookAt( GameObject.Find("Player").transform.position );
				GameObject.Find("Intro Camera").transform.Translate( new Vector3(-0.2f,0,0) );
				introTime -= Time.deltaTime; 
				return;
			} else {
				introPlayed = true;
				
				if ( playMushroomCam == true ) {
					GameObject.Find("Mushroom Camera").camera.enabled = true;
				}
				
				( GameObject.Find("Player").GetComponent("PlayerScript") as PlayerScript ).generateMushrooms();
				GameObject.Find("Intro Camera").camera.enabled = false;
				Destroy(GameObject.Find("Intro Camera"));

			}
		}
		
		if ( playMushroomCam == true && mushroomPlayed == false ) {
			
			if ( mushroomCamTimer > 0 ) {
				GameObject.Find("Mushroom Camera").transform.Rotate(0,-0.1f,0);
				mushroomCamTimer -= Time.deltaTime;
				return;
			} else {
				mushroomPlayed = true;
				GameObject.Find("Mushroom Camera").camera.enabled = false;
				Destroy(GameObject.Find("Mushroom Camera"));
			}
			
		}
		
		if ( doCameraSetup == true && cameraSetup == false ) {
			
			if ( transform.position.y < cameraSetupMax ) {
				transform.Translate( new Vector3(0,0.2f,0) );
				return;
			} else {
				cameraSetup = true;
				PlayerScript.playing = true;
			}
			
		}
		
	}
}