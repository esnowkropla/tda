using UnityEngine;

public static class Utility
{
	public static string PathToName(string path)
	{
		string[] splits = path.Split('/');
		string[] splits2 = splits[splits.Length - 1].Split('.');
		return splits2[0];
	}

    public static string PathToFolderName(string path)
    {
        string[] splits = path.Split('/');
        if (splits[splits.Length - 1] != "") { return splits[splits.Length - 1]; }
        return splits[splits.Length - 2];
    }
}
