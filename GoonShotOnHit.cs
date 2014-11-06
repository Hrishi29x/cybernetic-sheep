using UnityEngine;
using System.Collections;

public class GoonShotOnHit : MonoBehaviour 
{
	public int damage = 50;
	public GameObject blood;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Wall")
		 {
			Destroy(gameObject);
		 }
		 else
		 if (other.tag == "Player")
		 {
			// damage the player
			Health health = (Health)other.gameObject.GetComponent("Health");
			health.damage(damage);
			
			// display blood
			Vector3 bloodPos = other.gameObject.transform.position; 
			Instantiate(blood, other.gameObject.transform.position , Quaternion.identity );
			
			Destroy(gameObject);
		 }
		 else
		 if(other.tag == "StasisShield")
		 {
			Destroy(gameObject);
		 }
	
	}
}
