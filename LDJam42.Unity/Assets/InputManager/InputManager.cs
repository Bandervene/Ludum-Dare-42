using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class InputManager : MonoBehaviour
{
	public static KeyCode upKey = KeyCode.W;
	public static KeyCode downKey = KeyCode.S;

	public static bool up { get { return Input.GetKey(upKey); } }
	public static bool down { get { return Input.GetKey(downKey); } }

	public static InputManager instance { get { return GetInstance(); } }
	private static InputManager _instance = null;


	private static InputManager GetInstance()
	{
		if(_instance == null) { _instance = new InputManager(); }
		return _instance;
	}
}
