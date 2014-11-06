using UnityEngine;
using System.Collections;


// This script is used to make our text blink on the splash screen
public class Blink : MonoBehaviour 
{

	public float delay = .5f;
	
	// An IEnumerator is a special type of a function called in iterator
	IEnumerator OnBlink()
	{
		yield return new WaitForSeconds(delay); // on blink skips execution and comes back after delay seconds
		float alpha = transform.renderer.material.color.a;
		var newAlpha = 0f;
		if (alpha != 1) 
		{
			newAlpha = 1f;
		}
		transform.renderer.material.color = new Color(1, 1, 1, newAlpha);
		StartCoroutine(OnBlink()); // this recursive call makes this function an infinite loop
	
	}

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(OnBlink());// a coroutine can start to execute, leave, then come back later where it left of
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
