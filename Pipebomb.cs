using UnityEngine;
using System.Collections;

public class Pipebomb : MonoBehaviour 
{

	public GameObject pipebomb;
	public int numBombs = 3;
	Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = (Animator)gameObject.GetComponent("Animator");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKeyDown("b") )
		{
			if(numBombs > 0)
			{
				numBombs--;
				
				// set the player's state to aggro
				if( !animator.GetBool("Aggro") )
				{
					animator.SetBool("Aggro" , true );
				}
				
				// spawn the pipebomb
				 Instantiate(pipebomb, transform.position, pipebomb.transform.rotation);
			}
		}
		
	}
}
