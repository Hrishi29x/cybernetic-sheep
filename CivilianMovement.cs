using UnityEngine;
using System.Collections;

public class CivilianMovement : MonoBehaviour {

	public float speed = 0.6f;
	private Vector2 speedVector;
	public float direc = 1;
	public float count = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void FixedUpdate () 
	{

		if (direc == 1)
		{
			rigidbody2D.velocity = new Vector2(0,0);
			rigidbody2D.angularVelocity = 0f;
			float yComponent = 0f;
			speedVector = new Vector3(speed,yComponent);
			rigidbody2D.velocity = speedVector;
			count = count + 1;
			if (count == 60) 
			{
				direc = direc + 1;
				count = 0;
			}
		}
		else if (direc == 2)
		{
			rigidbody2D.velocity = new Vector2(0,0);
			rigidbody2D.angularVelocity = 0f;
			float xComponent = 0f;
			speedVector = new Vector3(xComponent,-1*speed);
			rigidbody2D.velocity = speedVector;
			count = count + 1;
			if (count == 20)
			{
				direc = direc + 1;
				count = 0;
			}
		}
		else if (direc == 3)
		{
			rigidbody2D.velocity = new Vector2(0,0);
			rigidbody2D.angularVelocity = 0f;
			float yComponent = 0f;
			speedVector = new Vector3(-1*speed,yComponent);
			rigidbody2D.velocity = speedVector;
			count = count + 1;
			if (count == 60)
			{
				direc = direc + 1;
				count = 0;
			}
		}
		else if (direc == 4)
		{
			rigidbody2D.velocity = new Vector2(0,0);
			rigidbody2D.angularVelocity = 0f;
			float xComponent = 0f;
			speedVector = new Vector3(xComponent,speed);
			rigidbody2D.velocity = speedVector;
			count = count + 1;
			if (count == 20)
			{
				direc = 1;
				count = 0;
			}
		}
	}
			
}
