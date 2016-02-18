using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	/**加载场景*/
	public void gameStart(){

		Application.LoadLevel ("002-play");
	}
	/**游戏介绍*/
	public void gameIntruduction(){

        Debug.Log("Hello Tegner welcome to hoolai");

	}
	/**游戏设置*/
	public void gameSeting(){


	}

}
