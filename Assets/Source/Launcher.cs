using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Launcher : MonoBehaviour
{
	public GameObject modTray;
	public GameObject modButtonPrefab;
	public string[] mods;
	public List<string> activeMods;
	public const string baseGameName = "Base";

	void Start ()
	{
		Screen.SetResolution(640, 480, false);
		mods = Mod.GetMods();
		activeMods = new List<string>();
		for (int i = 0; i < mods.Length; i++)
		{
			GameObject modButton = (GameObject) Instantiate(modButtonPrefab, modTray.transform);
			modButton.GetComponent<ModButton>().launcher = this;
            modButton.GetComponent<ModButton>().SetText(mods[i]);
		}
	}

	public void Launch()
	{
	}
	
	void Update ()
	{
	
	}
}
