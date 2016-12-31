using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using TypeEncoder;

public class Launcher : MonoBehaviour
{
	public GameObject modTray;
	public GameObject modButtonPrefab;
	public string[] mods;
	public List<Type> activeMods;
	public Type baseGame;
	public const string baseGameName = "Base";

	public GameObject resTray;
	public GameObject resButtonPrefab;
	public ToggleGroup resToggleGroup;

	public Text debugText; 
	Resolution[] resolutions;
	Resolution initialRes;
	public Resolution settingRes;

	void Start ()
	{
		xa.debugText = debugText;
		Type.Init();
		baseGame = new Type(baseGameName);

		SetMods();
		SetResolutions();
		Screen.SetResolution(640, 480, false, 60);
	}

	void SetMods()
	{
		mods = Mod.GetMods();
		activeMods = new List<Type>();
		for (int i = 0; i < mods.Length; i++)
		{
			GameObject modButton = (GameObject) Instantiate(modButtonPrefab, modTray.transform);
			modButton.GetComponent<ModButton>().launcher = this;
            modButton.GetComponent<ModButton>().SetText(mods[i]);
		}
	}

	void SetResolutions()
	{
		RestoreResolution();
		if (!Application.isEditor)
		{
			resolutions = Screen.resolutions;
			for (int i = resolutions.Length - 1; i >= 0; i--)
			{
				ResButton.Create(this, resToggleGroup, resolutions[i], settingRes);
			}
		}
		else
		{
			MockResolutions();
		}
	}

	void MockResolutions()
	{
		Resolution r = new Resolution();
		r.refreshRate = 60;

		r.width = 1600;
		r.height = 900;
		ResButton.Create(this, resToggleGroup, r, settingRes);

		r.width = 1366;
		r.height = 768;
		ResButton.Create(this, resToggleGroup, r, settingRes);

		r.width = 800;
		r.height = 600;
		ResButton.Create(this, resToggleGroup, r, settingRes);
	}

	void RestoreResolution()
	{
		initialRes = Screen.currentResolution;
		if (PlayerPrefs.HasKey("ResWidth") && PlayerPrefs.HasKey("ResHeight"))
		{
			settingRes.width = PlayerPrefs.GetInt("ResWidth");
			settingRes.height = PlayerPrefs.GetInt("ResHeight");
			settingRes.refreshRate = 60;
		}
		else
		{
			settingRes = initialRes;
		}
	}
	
	public void Launch()
	{
		PlayerPrefs.SetInt("ResWidth", settingRes.width);
		PlayerPrefs.SetInt("ResHeight", settingRes.height);
		PlayerPrefs.Save();

		Screen.SetResolution(settingRes.width, settingRes.height, true, 60);
		UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single); 	
	}

	public void Quit()
	{
		Application.Quit();
	}
}
