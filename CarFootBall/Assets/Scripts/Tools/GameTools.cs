using UnityEngine;
using System.Collections;

public static class GameTools {
	public static T GetorAddComponent<T>(this GameObject go) where T:Behaviour{
		T ts = go.GetComponent<T>();
		if (ts == null) {
			ts=go.AddComponent<T>();
		}
		return ts;
	}
}
