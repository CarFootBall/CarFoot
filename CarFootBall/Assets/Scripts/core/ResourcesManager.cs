using UnityEngine;
using System.Collections;
using System.Text;
public class ResourcesManager :SingleTon<ResourcesManager> {
	public ResourcesManager(){}
	GameObject uiRes;
	public GameObject LoadFromResouce(string path,ResourceType restype=ResourceType.UIScene){
		StringBuilder src = new StringBuilder ();
		switch (restype) {
		case ResourceType.UIScene:
			src.Append("UI/UIScene/");
			break;
		case ResourceType.UIWindow:
			src.Append("UI/UIWindow/");
			break;
		default:
			break;
		}
		src.Append (path);
		uiRes = Resources.Load (src.ToString ()) as GameObject;
		return GameObject.Instantiate (uiRes);
	}
	public GameObject LoadFormAssetBundle(string path,string name){
		StartLoad (path,name);
		while (uiRes==null) {}
		return uiRes ;
	}
	public void UnLoad(){
	}
	void StartLoad(string path,string name){
		//StartCoroutine (Download_Prefab (path, name));
	}
//	IEnumerator Download_Prefab(string path,string name){
////		WWW m_www = new WWW (path);
////		yield return m_www;
////		AssetBundle bundle = m_www.assetBundle;
////		AssetBundleRequest req = bundle.LoadAssetAsync (name,typeof(GameObject));
////		yield return req;
////		uiRes = (GameObject)Instantiate (req.asset);
////		m_www.assetBundle.Unload (false);
////		m_www.Dispose ();
//	}
}
