using UnityEngine;

public static class Cursor
{
	static Vector2 pos;
	
	public static void Update()
	{
		pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	public static Vector2 Pos()
	{
		return pos;
	}
}
