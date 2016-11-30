using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResButton : MonoBehaviour
{
	public Launcher launcher;
	public Text text;

	Resolution res;
	
	public void SetRes(Resolution r)
	{
		res = r;
		text.text = res.ToString();
	}

	public static GameObject Create(Launcher launcher, ToggleGroup toggleGroup, Resolution res, Resolution initialRes)
	{
		GameObject resButton = (GameObject) Instantiate(launcher.resButtonPrefab, launcher.resTray.transform);
		resButton.GetComponent<ResButton>().launcher = launcher;
		resButton.GetComponent<ResButton>().SetRes(res);
		resButton.GetComponent<Toggle>().group = toggleGroup;
		if (initialRes.width == res.width && initialRes.height == res.height) { resButton.GetComponent<Toggle>().isOn = true; }
		return resButton;
	}

	public void OnPressed(bool pressed)
	{
		launcher.settingRes = res;
	}
}
