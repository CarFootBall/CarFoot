using UnityEngine;
using System.Collections;

public class UISceneCtrBase : MonoBehaviour {
	public Transform CenterContainer;
	public Transform LeftTopContainer;
	public Transform LeftBottomContainer;
	public Transform RightTopContainer;
	public Transform RightBottomContainer;
	public Transform RightCenterContainerContainer;
	// Use this for initialization
	void Start () {
		OnStart ();
	}
	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}
	public virtual void OnStart(){}
	public virtual void OnUpdate(){}
}
