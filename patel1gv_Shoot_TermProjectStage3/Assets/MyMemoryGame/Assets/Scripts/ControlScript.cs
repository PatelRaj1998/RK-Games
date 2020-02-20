using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlScript : MonoBehaviour {

	public Text ScoreText;

	public void ExitToMainMenu()
	{
		SceneManager.LoadScene ("AdminMainMenu");
	}

	void ScoreManager()
	{
		//ScoreText = "Your score is " +   + "and you took " +     +"time";
	}
}
