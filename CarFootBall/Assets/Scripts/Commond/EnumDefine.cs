using UnityEngine;
using System.Collections;
public enum UIWindowType{
	Login,Register,Hearder,Function,Skill
}
public enum UIWindowContainerType{   //gua dian wei zhi
	Center,LeftTop,LeftBottom,RightTop,RightBottom,RightCenter
}
public enum UISceneType{
	Login,Loading,Battle
}
public enum ResourceType{
	UIScene=0,UIWindow,Audio,Character,Cameras
}
public enum UIWindowShowAnimationType{
	Normal,CenterToBig,LeftToRight,RightToLeft,TopToBottom,BottomToTop
}