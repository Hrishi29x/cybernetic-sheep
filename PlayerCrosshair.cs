using UnityEngine;
using System.Collections;

public class PlayerCrosshair : MonoBehaviour 
{
	public Texture2D cursorTexture;
	private CursorMode cursorMode;
	private Vector2 hotSpot;

	// Use this for initialization
	void Start () 
	{
		cursorMode = CursorMode.Auto; // Use hardware cursors on supported platforms.
		hotSpot = Vector2.zero; // The offset from the top left of the texture to use as the target point
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 mousePos = Input.mousePosition; // current mouse position in pixel cords
		Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position); // get the players position in pixel cords
		float deltaX = mousePos.x - playerPos.x;
		float deltaY = mousePos.y - playerPos.y;
		//Atn2 returns the angle between the x-axis and a 2D vector starting at zero and terminating at (x,y).
		// since Atn2 returns radians we convert to degrees by multiplying by the conversion constant
		// the -90f is to compensate for the particular sprite
		// 0 degrees in unity is due east and my sprite was oriented due north
		float playerRotationAngle = (Mathf.Atan2 (deltaY, deltaX) * Mathf.Rad2Deg) - 90f;
		// Quaternion.Euler returns a quaternion that represents rotating playRotationAngle degrees around the z-axis
		transform.rotation = Quaternion.Euler (new Vector3(0,0,playerRotationAngle));
	
	}
}
