using UnityEngine;
using System.Collections;

public class ULoginWindowCtr : UIWindowsCtrBase {
	protected override void OnBtnClick (GameObject obj)
	{
		Debug.Log ("close");
		UIWindowsManager.Instance.CloseUIWindow (UIWindowType.Login);
	}
}
