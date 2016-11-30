using UnityEngine;

public static class Logging
{
	public enum Level
	{
		NONE = 0x00,
		LOG = 0x01,
		INFO = 0x02,
		ERROR = 0x04,
		WARN = 0x08
	}
	
	public static void Log(string text)
	{
		if ((xa.Debug & Level.LOG) == Level.LOG) { xa.debugText.text += text + "\n"; }
	}

	public static void Warn(string text)
	{
		if ((xa.Debug & Level.WARN) == Level.WARN) { Debug.Log(text); }
	}

	public static void Error(string text)
	{
		if ((xa.Debug & Level.ERROR) == Level.ERROR) { Debug.LogError(text); }
	}

	public static void Info(string text)
	{
		if ((xa.Debug & Level.INFO) == Level.INFO) { Debug.Log(text); }
	}
}
