using UnityEngine;
using System.Collections;

public class GoonMovement : MonoBehaviour {

	public float speed = 0.6f;
	private Vector2 speedVector;
	public float direc = 0;
	public float count = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate ()
	{
		if (direc == 0)
		{
			rigidbody2D.velocity = new Vector2(0,0);
			rigidbody2D.angularVelocity = 0f;
			float yComponent = 0f;
			speedVector = new Vector3(speed,yComponent);
			rigidbody2D.velocity = speedVector;
			count = count + 1;
			if (count == 40) 
			{
				direc = direc + 1;
				count = 0;
			}
		}
		else if (direc == 1)
		{
			rigidbody2D.velocity = new Vector2(0,0);
			rigidbody2D.angularVelocity = 0f;
			float yComponent = 0f;
			speedVector = new Vector3(-1*speed,yComponent);
			rigidbody2D.velocity = speedVector;
			count = count + 1;
			if (count == 40)
			{
				direc = 0;
				count = 0;
			}
		}
	}
}
