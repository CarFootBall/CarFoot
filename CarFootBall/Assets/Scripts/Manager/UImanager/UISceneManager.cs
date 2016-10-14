using UnityEngine;
using System.Collections;

public class UISceneManager : SingleTon<UISceneManager> {
	public UISceneCtrBase currentUISceneCtr;
	public void OpenUIScene(UISceneType sceneType){   //        cong zi yuan jia zai chang jin dao nei cun zhong
		GameObject ScenUI = null;
		switch (sceneType) {
		case UISceneType.Login:
			ScenUI=ResourcesManager.Instance.LoadFromResouce("UILogin",restype:ResourceType.UIScene);
			break;
		case UISceneType.Battle:
			ScenUI=ResourcesManager.Instance.LoadFromResouce("UIBattle",restype:ResourceType.UIScene);
			break;
		default:
			break;
		}
		currentUISceneCtr = ScenUI.GetorAddComponent<UISceneCtrBase> ();
	}
}
