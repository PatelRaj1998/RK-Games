using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioMenuScript : MonoBehaviour {


	private FirstSceneScript FirstSceneGameobject;

	public Slider Volume1;
	public Slider Volume2;
	public Slider Volume3;
	public Slider Volume4;

	public Dropdown Dropdown1;
	public Dropdown Dropdown2;
	public Dropdown Dropdown3;
	public Dropdown Dropdown4;


	List<string> forDropdown1 = new List<string>(){"BgMusic1", "BgMusic2", "BgMusic3"};
	List<string> forDropdown2 = new List<string>(){"Fantasy_Game_Loop", "Pim_Poy", "Pim_Poy_Pocket"};
	List<string> forDropdown3 = new List<string>(){"explosion_asteroid", "explosion_enemy", "explosion_player"};
	List<string> forDropdown4 = new List<string>(){"1WeaponSound", "2WeaponSound", "3WeaponSound"};

	public void buttonClick(int i){
		if (i == 0) {
			SceneManager.LoadScene ("ConfigurationScene");
		}  
	}

	// Use this for initialization
	void Start () {
		PopulateList ();
	}

	void PopulateList()
	{
		Dropdown1.AddOptions (forDropdown1);
		Dropdown2.AddOptions (forDropdown2);
		Dropdown3.AddOptions (forDropdown3);
		Dropdown4.AddOptions (forDropdown4);

	}


	// Update is called once per frame
	void Update () {

	}

	//latest
	public void setBackgroundMusicVolume(float value)
	{
		AudioController.instance.setBackgroundMusicVolume (value);	
	}

	public void setWinningMusicVolume(float value)
	{
		AudioController.instance.setWinningMusicVolume(value);	
	}

	public void setShootingMusicVolume(float value)
	{
		AudioController.instance.setShootingMusicVolume(value);	
	}

	public void setDestroyMusicVolume(float value)
	{
		AudioController.instance.setDestroyMusicVolume(value);	
	}

	public void changeBackgroundSound(int choice)
	{
		//AudioController.instance.backgroundMusicSource = AudioController.instance.BackgroundMusicList [choice];
	
		if (PlayerPrefs.GetInt ("backgroundMusicChoice") != choice) {
			//AudioController.instance.backgroundMusicSource.clip = backgroundMusicChoice (choice);
			PlayerPrefs.SetInt ("backgroundMusicChoice", choice);
			AudioController.instance.playBackgroundMusic ();
		}

		//AudioController.instance.backgroundMusicSource.Play ();
	}

	public void changeWinningSound(int choice)
	{
		//AudioController.instance.winningSource = AudioController.instance.WinningMusicList [choice];

		//AudioController.instance.winningSource.clip = winningMusicChoice (choice);
		PlayerPrefs.SetInt ("winningSoundChoice", choice);

		AudioController.instance.playWinningMusic ();
	}

	public void changeShootingSound(int choice)
	{
		//AudioController.instance.shootingSource = AudioController.instance.ShootingMusicList [choice];

		//AudioController.instance.shootingSource.clip = shootingMusicChoice (choice);
		PlayerPrefs.SetInt ("shootingSoundChoice", choice);

		AudioController.instance.playShootingMusic ();
	}

	public void changeDestroySound(int choice)
	{
		//AudioController.instance.destroySource = AudioController.instance.DestroyMusicList [choice];

		//AudioController.instance.winningSource.clip = destroyMusicChoice (choice);
		PlayerPrefs.SetInt ("destroySoundChoice", choice);

		AudioController.instance.playDestroyMusic ();
	}
}
