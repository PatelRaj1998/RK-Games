using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetsAudio : MonoBehaviour {

	public AudioSource clickButton;
	public AudioSource WinSound;
	public AudioSource LooseSound;

	public void PlayAudioOnClick()
	{
		clickButton.Play ();
	}

	public void PlayWinAudio()
	{
		WinSound.Play ();
	}

	public void PlayLoosingAudio()
	{
		LooseSound.Play ();
	}


	public void ExitToMainMenu()
	{
		SceneManager.LoadScene ("AdminMainMenu");
	}
}
