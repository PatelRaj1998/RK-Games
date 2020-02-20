using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour {

	private AudioSource backgroundMusic;
	public AudioSource[] BackgroundMusicList;
	public AudioSource toDestroy;

	public void playBackgroundMusic()
	{
		Destroy (toDestroy);
		if (backgroundMusic != null)
			backgroundMusic.Stop ();

		backgroundMusic = BackgroundMusicList [PlayerPrefs.GetInt ("bgMusicChoice")];
		backgroundMusic.Play ();

		if (backgroundMusic == null)
			Debug.Log("It's null");
		
		setBackgroundMusicVolume (1);
		backgroundMusic.loop = true;
	}

	public void setBackgroundMusicVolume(float newVolume)
	{
		backgroundMusic.volume = newVolume;
	}
}
