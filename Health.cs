using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public int health = 100;
	public GameObject screenFader;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health <= 0)
		{
			if(gameObject.tag == "Civilian" || gameObject.tag == "Patient")
				Instantiate(screenFader);
				
			if(gameObject.tag == "Player")
				Instantiate(screenFader);
				
			Destroy(gameObject);
		}
	}
	
	public void heal(int value)
	{
		health = health + value;
	}
	
	public void damage(int value)
	{
		health = health - value;
	}
}
