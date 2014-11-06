using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour 
{
	public GameObject player;
	Health playerHealth;
	Pipebomb playerPipebomb;
	PlayerMovement pm;
	StasisShield ss;
	
	// Use this for initialization
	void Start () 
	{
		playerHealth = (Health)player.GetComponent("Health");
		playerPipebomb = (Pipebomb)player.GetComponent("Pipebomb");
		pm = (PlayerMovement)player.GetComponent("PlayerMovement");
		ss = (StasisShield)player.GetComponent("StasisShield");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () 
	{
		int healthVal = playerHealth.health;
		int bombVal = playerPipebomb.numBombs;
		
		string shield;
		if(ss.shieldAvailable)
		{
			shield = "Yes";
		}
		else
			shield = "No";
		
		// Make a background box
		if(pm.burden)
		{
			GUI.Box(new Rect(10,10,90,80), "Health: " + healthVal + "\nBombs: " + bombVal + "\nShield: " + shield + "\nBurdened");
			if (healthVal == 100)
			{
				if (ss.shieldAvailable)
				{
					GUI.Box(new Rect (10, 500, 700, 50), "Player : My shield will protect you!");
				}
				else
				{
					GUI.Box(new Rect (10, 500, 700, 50), "Player : I will lead you to safety! These machines are no match for me.");
				}
			}
			else if (healthVal == 50)
			{
				if (ss.shieldAvailable)
				{
					GUI.Box(new Rect (10, 500, 700, 50), "Player : A last ditch effort to protect the patient...");
				}
				else
				{
					GUI.Box(new Rect (10, 500, 700, 50), "Player : Just need to last a little bit longer!");
				}
			}
		}
		else
		{
			GUI.Box(new Rect(10,10,90,60), "Health: " + healthVal + "\nBombs: " + bombVal + "\nShield: " + shield);
			if (healthVal == 100)
			{
				if (ss.shieldAvailable)
				{
					GUI.Box(new Rect (10, 500, 700, 50), "Player : Let's find the patient with shield backup!");
				}
				else
				{
					GUI.Box(new Rect (10, 500, 700, 50), "Player : My shield is down! I appear to be fine though.");
				}
			}
			else if (healthVal == 50)
			{
				if (ss.shieldAvailable)
				{
					GUI.Box(new Rect (10, 500, 700, 50), "Player : I've been hit. I have my shield for protection!");
				}
				else
				{
					GUI.Box(new Rect (10, 500, 700, 50), "Player : I'm damaged. I still need to look for the patient.");
				}
			}
		}
	}
}
