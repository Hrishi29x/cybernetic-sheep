using UnityEngine;
using System.Collections;

public class Blaster : MonoBehaviour 
{
	private Transform shotSpawnTransform;
	public float fireRate;
	private float nextFire;
	public GameObject shot;
	Animator animator;

	// Use this for initialization
	void Start () 
	{
		shotSpawnTransform = transform; // spawn the projectile relative to the player
		nextFire = 0f; // let the player shoot right away
		animator = (Animator)gameObject.GetComponent("Animator");
	}
	
	// Update is called once per frame
	void Update () 
	{
		// GetMouseButton Returns whether the given mouse button is held down, 0 is for left mouse
		if(Input.GetMouseButton(0))
		{
			// set the player's state to aggro
			if( !animator.GetBool("Aggro") )
			{
				animator.SetBool("Aggro" , true );
			}
		
			// has enough time elapsed for next shot ?
			if (Time.time > nextFire ) // Time.time is the time in seconds since the start of the game.
			{
				nextFire = Time.time + fireRate;
				
				// I need to figure out how to displace the shots correctly relative to the sprites
				/*float x,y;*/
				/*if( shotSpawnTransform.position.x >= 0f)
					x = shotSpawnTransform.position.x + 0.1f;
				else
					x = shotSpawnTransform.position.x - 0.1f;*/
				/*if(shotSpawnTransform.position.y >= 0f)
					y = shotSpawnTransform.position.y  + 0.5f;
				else
					y = shotSpawnTransform.position.y - 0.5f; */
					
				Vector3 shotSpawnPosition = new Vector3(shotSpawnTransform.position.x, shotSpawnTransform.position.y, 0f);
				Instantiate(shot, shotSpawnPosition, shotSpawnTransform.rotation);
			}
		}
	}
}
