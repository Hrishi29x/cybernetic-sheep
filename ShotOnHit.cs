using UnityEngine;
using System.Collections;

public class ShotOnHit : MonoBehaviour 
{

	public GameObject SceneFader;
	public int damage = 50;
	public float delay = 0.1f;
	private float endTime;
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
		 if (other.tag == "Civilian")
		 {
			// deal damage
			Health health = (Health)other.gameObject.GetComponent("Health");
			health.damage(damage);
			
			// display blood
			Vector3 bloodPos = other.gameObject.transform.position; 
			Instantiate(blood, other.gameObject.transform.position , Quaternion.identity );
			
			//destory the shot
			Destroy(gameObject);
		 }
		 else
		 if(other.tag == "Patient")
		 {
			// deal damage
			Health health = (Health)other.gameObject.GetComponent("Health");
			health.damage(damage);
			
			// display blood
			Vector3 bloodPos = other.gameObject.transform.position; 
			Instantiate(blood, other.gameObject.transform.position , Quaternion.identity );
			
			//destory the shot
			Destroy(gameObject);
		 }
		 else
		 if(other.tag == "Goon")
		 {
			// aggro the goon
			AttackBehavior attack = (AttackBehavior)other.gameObject.GetComponent("AttackBehavior");
			attack.aggro = true;
			
			// damage the goon
			Health health = (Health)other.gameObject.GetComponent("Health");
			health.damage(damage);
			
			//make the goon blink
			endTime = Time.time + 0.5f;
			StartCoroutine(OnBlink(other.gameObject));// a coroutine can start to execute, leave, then come back later where it left of
			
			//destroy the shot
			//Destroy(gameObject);
		 }
		 else
		 if( other.tag == "Android")
		 {
			Animator animator = (Animator)other.gameObject.GetComponent("Animator");
			animator.SetBool("Aggro" , true );
			
			// damage the android
			Health health = (Health)other.gameObject.GetComponent("Health");
			health.damage(damage - 10);
			
			Destroy(gameObject);
		 }
		 else
		 if(other.tag == "StasisShield")
		 {
			Destroy(gameObject);
		 }
		 else
		 if(other.tag == "StasisShield")
		 {
			Destroy(gameObject);
		 }
		 else
		 if(other.tag == "AugmentedHuman")
		 {
			// set to aggro animation
			Animator animator = (Animator)other.gameObject.GetComponent("Animator");
			animator.SetBool("Aggro" , true );
			
			// deal damage
			Health health = (Health)other.gameObject.GetComponent("Health");
			health.damage(damage);
			
			// display blood
			Vector3 bloodPos = other.gameObject.transform.position; 
			Instantiate(blood, other.gameObject.transform.position , Quaternion.identity );
			
			Destroy(gameObject);
		 }
		 
		
	
	}
	
	// An IEnumerator is a special type of a function called in iterator
	IEnumerator OnBlink(GameObject other)
	{
		if(Time.time >= endTime)
		{
			other.transform.renderer.material.color = new Color(1, 1, 1, 1);
			yield break;
		}
			
		yield return new WaitForSeconds(delay); // on blink skips execution and comes back after delay seconds
		
		if(other)
		{
			float alpha = other.transform.renderer.material.color.a;
			var newAlpha = 0f;
			if (alpha != 1) 
			{
				newAlpha = 1f;
			}
			other.transform.renderer.material.color = new Color(1, 1, 1, newAlpha);
			
			if(Time.time >= endTime)
			{
				other.transform.renderer.material.color = new Color(1, 1, 1, 1);
				yield break;
			}
				
			StartCoroutine(OnBlink(other)); // this recursive call makes this function an infinite loop
			
		}
	
	}
}
