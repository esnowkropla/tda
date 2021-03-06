using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class Mod
{
	public static string[] GetMods()
	{
		string[] mods = Directory.GetDirectories(Application.streamingAssetsPath);
		if (!Directory.Exists(Application.persistentDataPath + "/Mods/"))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/Mods/");
		}
		string[] mods2 = Directory.GetDirectories(Application.persistentDataPath + "/Mods/");
		string[] modsReturn = new string[mods.Length + mods2.Length];

		for (int i = 0; i < mods.Length; i++)
		{
			modsReturn[i] = mods[i].Replace('\\', '/') + '/';
		}

		for (int i = 0; i < mods2.Length; i++)
		{
			modsReturn[mods.Length + i] = mods2[i].Replace('\\', '/') + '/';
		}

		return modsReturn;
	}

	public static void SetMods()
	{
		/*GameObject tray = LauncherScript.script.launcherTray;
		List<string> mods = new List<string>();

		LauncherButton[] buttons = tray.transform.GetComponentsInChildren<LauncherButton>();
		for (int i = 0; i < buttons.Length; i++)
		{
			if (buttons[i].active == 1)
			{
				mods.Add(buttons[i].path);
			}
		}

		xa.modList = new string[mods.Count];
		for (int i = 0; i < xa.modList.Length; i++)
		{
			xa.modList[i] = mods[i];
		}*/
	}
}
