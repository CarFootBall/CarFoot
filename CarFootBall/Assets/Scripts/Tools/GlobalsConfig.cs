using UnityEngine;
using System.Collections;

public class GlobalsConfig : MonoBehaviour {
	public static GlobalsConfig _instance;
	public const string NIKENAME_KEY="NIKENAME";
	public const string PASSWORD_KEY="PASSWORD";
	public string NextSceneName=string.Empty;
	// Use this for initialization
	void Start () {
		_instance = this;
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
