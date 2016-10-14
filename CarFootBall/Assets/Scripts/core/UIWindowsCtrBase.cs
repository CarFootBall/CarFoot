using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UIWindowsCtrBase : MonoBehaviour {
	public List<UIWindowType> windowTypeArray=new List<UIWindowType>();
	public UIWindowContainerType windowConType=UIWindowContainerType.Center;
	public UIWindowShowAnimationType windowShowType=UIWindowShowAnimationType.Normal;
	public float duration=1f;
	public AnimationCurve windowUIShowAnimationCurve=new AnimationCurve();
	[HideInInspector]
	public UIWindowType windowType=UIWindowType.Login;
	// Use this for initialization
	void Start () {
		UIButton[] array = transform.GetComponentsInChildren<UIButton> ();
		foreach (UIButton item in array) {
			UIEventListener.Get(item.gameObject).onClick=BtnClick;
		}
		OnStart ();
	}
	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}
	void OnDestory(){
		BeforOnDestory ();
	}
	void BtnClick(GameObject btn){
		OnBtnClick (btn);
	}
	protected virtual void OnStart(){}
	protected virtual void OnBtnClick(GameObject obj){}
	protected virtual void OnUpdate(){}
	protected virtual void BeforOnDestory(){}
}
