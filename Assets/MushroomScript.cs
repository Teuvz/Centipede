using UnityEngine;
using System.Collections;

public class MushroomScript : MonoBehaviour {
	
	public int lives = 2;
	
	public int minX = 60;
	public int maxX = 140;
	
	public int minZ = 80;
	public int maxZ = 145;
	
	// Use this for initialization
	void Start () {
	
		Vector3 pos = new Vector3( Random.Range(minX,maxX), 0, Random.Range(minZ,maxZ) );
		transform.position = pos;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int hit() {
		return --lives;
	}
	
}
