using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public GameObject player;
	private Transform playerPosition;
	
	// Use this for initialization
	void Start () 
	{
		playerPosition = player.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// if the playerPosition transform exists, set the camera's x and y position cords the same as the player
		// but leave the z coordinate alone
		if (playerPosition)
			transform.position = new Vector3(playerPosition.position.x,playerPosition.position.y, transform.position.z);
	}
}
