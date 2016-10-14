using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UIWindowsManager : SingleTon<UIWindowsManager> {
	private Dictionary<UIWindowType,GameObject> m_dic=new Dictionary<UIWindowType, GameObject>();
	public void OPenUIWindow(UIWindowType windowType){
		if (m_dic.ContainsKey (windowType)) {
			return;
		}
		GameObject windowUI = null;
		switch (windowType) {        //gen ju lei xing jia zai chuang kou 
		case UIWindowType.Login:
			windowUI=ResourcesManager.Instance.LoadFromResouce("Login",restype:ResourceType.UIWindow);
			break;
		case UIWindowType.Register:
			windowUI=ResourcesManager.Instance.LoadFromResouce("Register",restype:ResourceType.UIWindow);
			break;
		case UIWindowType.Hearder:
			windowUI=ResourcesManager.Instance.LoadFromResouce("Hearder",restype:ResourceType.UIWindow);
			break;
		case UIWindowType.Function:
			windowUI=ResourcesManager.Instance.LoadFromResouce("Function",restype:ResourceType.UIWindow);
			break;
		case UIWindowType.Skill:
			windowUI=ResourcesManager.Instance.LoadFromResouce("Skill",restype:ResourceType.UIWindow);
			break;
		default:
			break;
		}
		UIWindowsCtrBase WindowUICtr = windowUI.GetorAddComponent<UIWindowsCtrBase> ();
		WindowUICtr.windowType = windowType;
		UIWindowContainerType windowConType = WindowUICtr.windowConType;
		Transform parentContainer = null;
		switch (windowConType) {         //gen ju chuang kou gua dian lei xing she zhi gua dian fu dui xiang
		case UIWindowContainerType.Center:
			parentContainer=UISceneManager.Instance.currentUISceneCtr.CenterContainer;
			break;
		case UIWindowContainerType.LeftBottom:
			parentContainer=UISceneManager.Instance.currentUISceneCtr.LeftBottomContainer;
			break;
		case UIWindowContainerType.LeftTop:
			parentContainer=UISceneManager.Instance.currentUISceneCtr.LeftTopContainer;
			break;
		case UIWindowContainerType.RightTop:
			parentContainer=UISceneManager.Instance.currentUISceneCtr.RightTopContainer;
			break;
		case UIWindowContainerType.RightCenter:
			parentContainer=UISceneManager.Instance.currentUISceneCtr.RightCenterContainerContainer;
			break;
		case UIWindowContainerType.RightBottom:
			parentContainer=UISceneManager.Instance.currentUISceneCtr.RightBottomContainer;
			break;
		default:
			break;
		}
		windowUI.transform.parent = parentContainer;
		windowUI.transform.localPosition = Vector3.zero;
		windowUI.transform.localScale = Vector3.one;
		m_dic.Add (windowType, windowUI);
		NGUITools.SetActive (windowUI, false);
		UIWindowShowAnimationType windowShowType = WindowUICtr.windowShowType;
		StarAtiveUIWindow (windowUI, windowShowType:windowShowType, state: true);
	}
	public void CloseUIWindow(UIWindowType windowType){
		if (m_dic.ContainsKey (windowType)) {
			GameObject windowUI=m_dic[windowType];
			UIWindowsCtrBase windowUICtr=windowUI.GetorAddComponent<UIWindowsCtrBase>();
			UIWindowShowAnimationType windowShowType=windowUICtr.windowShowType;
			StarAtiveUIWindow(windowUI,windowShowType:windowShowType,state:false);
		}
	}
	public void StarAtiveUIWindow(GameObject go,UIWindowShowAnimationType windowShowType=UIWindowShowAnimationType.CenterToBig,bool state=true){        //chuang kou xian shi he guan bi dong hua  
		switch (windowShowType) {
		case UIWindowShowAnimationType.Normal:
			ShowNormal(go,state);
			break;
		case UIWindowShowAnimationType.CenterToBig:
			ShowCenterToBig(go,state);
			break;
		case UIWindowShowAnimationType.LeftToRight:
			ShowDirection(go,state,1);
			break;
		case UIWindowShowAnimationType.RightToLeft:
			ShowDirection(go,state,2);
			break;
		case UIWindowShowAnimationType.TopToBottom:
			ShowDirection(go,state,3);
			break;
		case UIWindowShowAnimationType.BottomToTop:
			ShowDirection(go,state,4);
			break;
		default:
			break;
		}		
	}
	public void ShowNormal(GameObject go,bool state){
		if (state) {
			NGUITools.SetActive (go, true);
		} else {
			DestoryUIWindow(go);
		}
	}
	public void ShowCenterToBig(GameObject go,bool state){
		TweenScale ts = go.GetorAddComponent<TweenScale> ();
		ts.from = Vector3.zero;
		ts.to = Vector3.one;
		ts.duration = go.GetorAddComponent<UIWindowsCtrBase> ().duration;
		ts.animationCurve = go.GetorAddComponent<UIWindowsCtrBase> ().windowUIShowAnimationCurve;
		if (state) {
			NGUITools.SetActive(go,true);
		}
		if (!state) {
			ts.SetOnFinished(()=>{
				DestoryUIWindow(go);
			});
			ts.Play(false);
		}
	}
	public void ShowDirection(GameObject go,bool state,int direction){
		Vector3 from = Vector3.zero;
		Vector3 to = Vector3.zero;
		switch (direction) {
		case 1:
			from = Vector3.left*Screen.width;
			break;
		case 2:
			from = Vector3.right*Screen.width;
			break;
		case 3:
			from = Vector3.up*Screen.height;
			break;
		case 4:
			from = Vector3.down*Screen.height;
			break;
		default:
			break;
		}
		TweenPosition tp = go.GetorAddComponent<TweenPosition> ();
		tp.from = from;
		tp.to = to;
		tp.duration = go.GetorAddComponent<UIWindowsCtrBase> ().duration;
		tp.animationCurve = go.GetorAddComponent<UIWindowsCtrBase> ().windowUIShowAnimationCurve;
		if (state) {
			NGUITools.SetActive(go,true);
		}
		if (!state) {
			tp.SetOnFinished(()=>{
				DestoryUIWindow(go);
			});
			tp.Play(false);
		}
	}
	private void DestoryUIWindow(GameObject go){    
		UIWindowsCtrBase windowUICtr = go.GetorAddComponent<UIWindowsCtrBase> ();
		if (m_dic.ContainsKey (windowUICtr.windowType)) {
			m_dic.Remove(windowUICtr.windowType);
		}
		GameObject.Destroy (go);
	}
}
