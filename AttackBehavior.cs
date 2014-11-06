using UnityEngine;
using System.Collections;

public class AttackBehavior : MonoBehaviour 
{
	public bool aggro;
	private Transform shotSpawnTransform;
	public float fireRate = 1;
	private float nextFire;
	public GameObject shot;
	Animator animator;

	// Use this for initialization
	void Start () 
	{
		shotSpawnTransform = transform; // spawn the projectile relative to the actor
		nextFire = 0f; // let the actor shoot right away
		animator = (Animator)gameObject.GetComponent("Animator");
		if(aggro)
		{
			animator.SetBool("Aggro", true);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(animator.GetBool("Aggro"))
		{
			AttackState1();
		}
	}
	
	void AttackState1()
	{
		// has enough time elapsed for next shot ?
		if (Time.time > nextFire ) // Time.time is the time in seconds since the start of the game.
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawnTransform.position, shotSpawnTransform.rotation);
		}
	
	}
}
