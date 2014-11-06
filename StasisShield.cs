using UnityEngine;
using System.Collections;

public class StasisShield : MonoBehaviour 
{
	SpriteRenderer shieldRender;
	bool shieldToggle;
	Animator animator;
	public float shieldRate = 10f;
	public float shieldEndTime;
	public float shieldUpTime = 2f;
	private float nextShield;
	public bool shieldAvailable;

	// Use this for initialization
	void Start () 
	{
		Transform stasisShieldGO = transform.Find("StasisShieldPlaceholder");
		shieldRender = (SpriteRenderer)stasisShieldGO.GetComponent("SpriteRenderer");
		shieldRender.gameObject.SetActive(false);
		shieldToggle = false;
		animator = (Animator)gameObject.GetComponent("Animator");
		nextShield = 0f; // let the player use the shield right away
		shieldEndTime = 0f;
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Time.time > shieldEndTime)
		{
			shieldToggle = false;
			shieldRender.gameObject.SetActive(false);
		
		}
		
		if(Time.time > nextShield)
		{
			shieldAvailable = true;
		}
		else
			shieldAvailable = false;
			
		if( Input.GetKeyDown("e") )
		{
			
			if(shieldToggle)
			{
				shieldToggle = false;
				shieldRender.gameObject.SetActive(false);
			}
			else
			{
				// has enough time elapsed for next shield ?
				if (Time.time > nextShield ) // Time.time is the time in seconds since the start of the game.
				{
					nextShield = Time.time + shieldRate;
					
					// set the player's state to aggro
					if( !animator.GetBool("Aggro") )
					{
						animator.SetBool("Aggro" , true );
					}
					
					shieldToggle = true;
					shieldRender.gameObject.SetActive(true);
					shieldEndTime = Time.time + shieldUpTime;
						
					
				}
				
			}
		}
	}
}
