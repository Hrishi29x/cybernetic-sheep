using UnityEngine;
using System.Collections;

// This script is used to go to a different scene from a current one
public class LoadScene : MonoBehaviour 
{

	private bool loadLock = false;
	
	void Load()
	{
		loadLock = true;
		Application.LoadLevel("Story");
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0) && !loadLock)
		{
			Load();
		}
	}
}
