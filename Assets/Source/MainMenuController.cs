using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
