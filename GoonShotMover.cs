using UnityEngine;
using System.Collections;

public class GoonShotMover : MonoBehaviour {
	
	public float speed = 4;
	private float xComponent;
	private float yComponent;
	private Vector3 angles;
	public float angle;
	public float direc;
	
	// Use this for initialization
	void Start () 
	{
		angles = transform.rotation.eulerAngles;
		direc = Random.value * 30;
		if (direc <= 10)
		{
			angle = angles.z + 105f;
		}
		else if (direc <= 20)
		{
			angle = angles.z + 90f;
		}
		else if (direc <= 30)
		{
			angle = angles.z + 75f;
		}
		angle = angle * Mathf.Deg2Rad;
		xComponent = speed * Mathf.Cos(angle); 
		yComponent = speed * Mathf.Sin(angle);
		rigidbody2D.velocity = new Vector2(xComponent,yComponent);

	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}