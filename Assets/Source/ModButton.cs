using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using TypeEncoder;

public class ModButton : MonoBehaviour
{
	public Type path;
	public string modName;
    public Text text;
	public Launcher launcher;

    public void SetText(string inText)
    {
        path = inText;
        modName = Utility.PathToFolderName(inText);
        text.text = modName;
		if (modName == Launcher.baseGameName)
		{
			this.GetComponent<Toggle>().isOn = true;
		}
    }

	public void Pressed(bool yes)
	{
		if (yes && !launcher.activeMods.Contains(path))
		{
			launcher.activeMods.Add(path);
		}
		else if (!yes && launcher.activeMods.Contains(path))
		{
			launcher.activeMods.Remove(path);
		}
	}
}
