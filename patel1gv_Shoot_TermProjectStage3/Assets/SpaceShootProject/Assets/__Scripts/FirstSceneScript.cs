using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstSceneScript : MonoBehaviour {

	public void buttonClick(int i){
		if (i == 0) {
			SceneManager.LoadScene ("MainMenuScene");

		} else if (i == 1) {
			Application.Quit();
		}
	}

	void Awake()
	{
		//AudioController.instance.playBackgroundMusic ();
		//DontDestroyOnLoad (AudioController.instance.playBackgroundMusic());
	}

	// Use this for initialization
	void Start () {
		
	}
		
	// Update is called once per frame
	void Update () {
		
	}


}
