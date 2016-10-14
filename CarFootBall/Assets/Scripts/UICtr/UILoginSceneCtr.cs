using UnityEngine;
using System.Collections;

public class UILoginSceneCtr : UISceneCtrBase {
	public override void OnStart ()
	{
		StartCoroutine (Openwindow ());
	}
	IEnumerator Openwindow(){
		yield return new WaitForSeconds (0.2f);
		UIWindowsManager.Instance.OPenUIWindow (UIWindowType.Login);
	}
}
