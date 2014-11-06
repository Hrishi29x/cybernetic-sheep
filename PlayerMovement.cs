using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 1.25f;
	private Vector2 speedVector;
	Animator animator;
	public bool burden = false;

	// Use this for initialization
	void Start () 
	{
		animator = (Animator)gameObject.GetComponent("Animator");

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	// you should used FixedUpdate instead of Update when you manipulate a rigidbody
	void FixedUpdate()
	{
	
		if(animator.GetBool("Aggro") )
		{
			speed = 2.5f;
		}
		
		if(burden)
		{
			speed = 1.75f;
		}
	
		// GetKey Returns true while the user holds down the specified key
		// so lets check if any of our movement keys are down
		if( Input.GetKey("right")||Input.GetKey("d")||Input.GetKey("left")||Input.GetKey("a")||Input.GetKey("up")|| Input.GetKey("w") || Input.GetKey("down")||Input.GetKey("s") )
		{
			
			if (Input.GetKey("right") || Input.GetKey("d") )
			{
				float yComponent;
				
				if( Input.GetKey("down") || Input.GetKey("s") || Input.GetKey("up") || Input.GetKey("w") )
					yComponent = rigidbody2D.velocity.y; // lets reuse our current y
				else
					yComponent = 0f;
					
				speedVector = new Vector3(speed,yComponent);
				rigidbody2D.velocity = speedVector;
			
			}
			
			if (Input.GetKey("left")||Input.GetKey("a") )
			{
				float yComponent;
				
				if( Input.GetKey("down") || Input.GetKey("s") || Input.GetKey("up") || Input.GetKey("w") )
					yComponent = rigidbody2D.velocity.y; // lets reuse our current y
				else
					yComponent = 0f;
					
				speedVector = new Vector3(-1*speed,yComponent);
				rigidbody2D.velocity = speedVector;
			
			}
			
			if (Input.GetKey("down") || Input.GetKey("s") )
			{
				float xComponent;
				
				if( Input.GetKey("right") || Input.GetKey("d") || Input.GetKey("left")||Input.GetKey("a") )
					xComponent = rigidbody2D.velocity.x; // lets reuse our current x
				else
					xComponent = 0f;
					
				speedVector = new Vector3(xComponent,-1*speed);
				rigidbody2D.velocity = speedVector;
			
			}
			
			if (Input.GetKey("up") || Input.GetKey("w") )
			{
				float xComponent;
				
				if( Input.GetKey("right") || Input.GetKey("d") || Input.GetKey("left")||Input.GetKey("a") )
					xComponent = rigidbody2D.velocity.x; // lets reuse our current x
				else
					xComponent = 0f;
					
				speedVector = new Vector3(xComponent,speed);
				rigidbody2D.velocity = speedVector;
			
			}
			
		}
		else // lets stop moving
		{
			rigidbody2D.velocity = new Vector2(0,0);
			rigidbody2D.angularVelocity = 0f;
		}
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Android")
		{
			
		}
	}
}
