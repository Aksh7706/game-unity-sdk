using System;
using UnityEngine;

namespace AnkrSDK.Tools
{
	public class CustomDropdown : PropertyAttribute
	{
		public string[] Options { get; private set; }
		
		public CustomDropdown(params string[] options)
		{
			Options = options;
		}

		public CustomDropdown(Type type, string methodName)
		{
			var method = type.GetMethod(methodName);
			if (method != null)
			{
				Options = method.Invoke(null, null) as string[];
			}
			else
			{
				Debug.LogError("There is no " + methodName + " for " + type);
			}
		}
	}
}