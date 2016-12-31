using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TypeEncoder
{
	public enum TYPES
	{
		UNINITIALIZED = 0,
		NONE,
		QUTMSheet
	}

	#pragma warning disable 0660
	public struct Type
	#pragma warning restore 0660
	{
		int data;

		public static List<string> intToStr;
		public static Dictionary<string, int> strToInt;

		public static void Init()
		{
			intToStr = new List<string>(100);
			strToInt = new Dictionary<string, int>(100);

			string[] names = Enum.GetNames(typeof(TYPES));
			TYPES[] values = (TYPES[]) Enum.GetValues(typeof(TYPES));

			for (int i = 0; i < names.Length; i++)
			{
				intToStr.Add(names[i]);
				strToInt.Add(names[i], (int) values[i]);
			}
		}

		public Type(int x)
		{
			data = x;
		}

		public Type(string text)
		{
			data = StrToInt(text);
		}

		public override string ToString()
		{
			if (Enum.IsDefined(typeof(TYPES), data))
			{
				return ((TYPES)data).ToString();
			}
			else if (data < intToStr.Count)
			{
				return intToStr[data];
			}
			else
			{
				Logging.Error("Couldn't convert " + data + " to string!");
				return null;
			}
		}

		public override Int32 GetHashCode() { return data; }

		public static bool operator ==(Type a, Type b) { return a.data == b.data; }
		public static bool operator !=(Type a, Type b) { return a.data != b.data; }

		public static implicit operator int(Type type)
		{
			return (int) type;
		}

		public static implicit operator Type(TYPES builtin)
		{
			Type x;
			x.data = (int) builtin;
			return x;
		}

		public static implicit operator Type(string text)
		{
			Type x;
			x.data = StrToInt(text);
			return x;
		}

		public static implicit operator Type(int x)
		{
			Type t;
			t.data = x;
			return t;
		}

		public static int StrToInt(string text)
		{
			try
			{
				TYPES type = (TYPES) Enum.Parse(typeof(TYPES), text);
				Logging.Log("Added already existing enum " + text + " with id " + (int) type);
				return (int) type;
			}
			catch (ArgumentException)
			{
				if (strToInt.ContainsKey(text))
				{
					Logging.Log("Adding already existing string " + text + " with id " + strToInt[text]);
					return strToInt[text];
				}
				else
				{
					int id = intToStr.Count;
					intToStr.Add(text);
					strToInt.Add(text, id);
					Logging.Log("Added string " + text + " with id " + id);
					return id;
				}
			}
		}
	}
}
