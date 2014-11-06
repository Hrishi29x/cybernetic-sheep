using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public float bombTimer;
	private float explodeTime;
	Collider2D[] killArray;
	public GameObject blood;
	
	// Use this for initialization
	void Start () 
	{
		// time when the pipebomb explodes is current time + offset
		explodeTime = Time.time + bombTimer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// explode the bomb
		if(Time.time > explodeTime )
		{
			Vector2 circlePoint = new Vector2(transform.position.x , transform.position.y  );
			float circleRadius = ((CircleCollider2D)collider2D).radius;
			killArray = Physics2D.OverlapCircleAll(circlePoint, circleRadius, Physics2D.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
			foreach(Collider2D c in killArray)
			{
				if( c.tag == "AugmentedHuman"   || c.tag == "Civilian" || c.tag == "Patient" || c.tag == "Player" )
				{
					// display blood
					Vector3 bloodPos = c.gameObject.transform.position; 
					Instantiate(blood, c.gameObject.transform.position , Quaternion.identity );
					
					// deal damage
					Health health = (Health)c.gameObject.GetComponent("Health");
					health.damage(100);
				}
				else
				if( c.tag == "Android" )
				{
					// deal damage
					Health health = (Health)c.gameObject.GetComponent("Health");
					health.damage(100);
				}
			}
			Destroy(gameObject);
		}
	}
	
	
}
