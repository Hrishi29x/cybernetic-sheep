using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour 
{
	public float speed = 4;
	private float xComponent;
	private float yComponent;
	private Vector3 angles;
	private float angle;

	// Use this for initialization
	void Start () 
	{
		
		angles = transform.rotation.eulerAngles; // Returns the euler angle representation of the rotation.
		angle = angles.z + 90f; // + 90 degrees to compensate for spirte orientation
		angle = angle * Mathf.Deg2Rad; // convert since our Cos and Sin functions take radian arguments
		xComponent = speed * Mathf.Cos(angle); 
		yComponent = speed * Mathf.Sin(angle); 
		rigidbody2D.velocity = new Vector2(xComponent,yComponent);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		

	}
	
	
}
