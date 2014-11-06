using UnityEngine;
using System.Collections;

public class FadeScene : MonoBehaviour 
{

	public float fadeSpeed = 1.5f;
	
	// Use this for initialization
	void Start () 
	{
		// Set the texture so that it is the the size of the screen and covers it.
        guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guiTexture.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () 
	{
		FadeToBlack();
		
		// If the screen is almost black...
        if(guiTexture.color.a >= 0.95f)
            // ... reload the level.
            Application.LoadLevel("KillerGameOver");
	}
	
	void FadeToBlack ()
    {
        // Lerp the colour of the texture between itself and black.
        guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }
}
