using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {

	public static AudioController instance = null;

	private AudioSource backgroundMusicSource;
	private AudioSource winningSource;
	private AudioSource destroySource;
	private AudioSource shootingSource;

	public AudioSource[] BackgroundMusicList;
	public AudioSource[] WinningMusicList;
	public AudioSource[] DestroyMusicList;
	public AudioSource[] ShootingMusicList;

	void Start ()
	{
		backgroundMusicSource = BackgroundMusicList [PlayerPrefs.GetInt ("backgroundMusicChoice")];
		destroySource = BackgroundMusicList [PlayerPrefs.GetInt ("destroyMusicChoice")];
		shootingSource = BackgroundMusicList [PlayerPrefs.GetInt ("shootingMusicChoice")];
		winningSource = BackgroundMusicList [PlayerPrefs.GetInt ("winningMusicChoice")];		
	}


	void Awake(){

		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
			instance = this;

		DontDestroyOnLoad(this.gameObject);
	}



	// Update is called once per frame
	void Update()
	{
		
	}


	public void playBackgroundMusic()
	{
		if (backgroundMusicSource != null)
			backgroundMusicSource.Stop ();
		
		backgroundMusicSource = BackgroundMusicList [PlayerPrefs.GetInt ("backgroundMusicChoice")];
		backgroundMusicSource.Play ();
		backgroundMusicSource.loop = true;
		DontDestroyOnLoad (backgroundMusicSource);
	}

	public void playWinningMusic()
	{
		winningSource = WinningMusicList [PlayerPrefs.GetInt ("winningMusicChoice")];
		winningSource.Play ();
	}

	public void playShootingMusic()
	{
		shootingSource = ShootingMusicList [PlayerPrefs.GetInt ("shootingMusicChoice")];
		shootingSource.Play ();
	}

	public void playDestroyMusic()
	{
		destroySource = DestroyMusicList [PlayerPrefs.GetInt ("destroyMusicChoice")];
		destroySource.Play ();
	}

	//volumes
	public void setBackgroundMusicVolume(float value)
	{
		backgroundMusicSource.volume = value;	
	}

	public void setWinningMusicVolume(float value)
	{
		winningSource.volume = value;	
	}

	public void setShootingMusicVolume(float value)
	{
		shootingSource.volume = value;	
	}

	public void setDestroyMusicVolume(float value)
	{
		destroySource.volume = value;	
	}
}
