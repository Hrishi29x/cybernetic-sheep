using UnityEngine;
using System.Collections;

public class LoadFirstLevel : MonoBehaviour {

	private bool loadLock = false;
	
	void Load()
	{
		loadLock = true;
		Application.LoadLevel("Map1");
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
