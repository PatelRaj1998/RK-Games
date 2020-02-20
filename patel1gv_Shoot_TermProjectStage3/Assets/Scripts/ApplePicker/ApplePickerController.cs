using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplePickerController : MonoBehaviour {

	public GameObject historyApplePanel;


	/*public void openApplePickerPanel (){
		ApplePickerPanel.SetActive (true);
	}
	public void closeApplePickerPanel(){
		ApplePickerPanel.SetActive (false);
	}*/
	public void StartGameButtonClick(){
		string datetime = System.DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
		PlayerPrefs.SetString ("dicDateTime",datetime);
		SceneManager.LoadScene ("ApplePickerScene");
	}
	public void closeHistoryPanel(){
		historyApplePanel.SetActive (false);

	}
	public void ExitMenuButtonClick(){
		SceneManager.LoadScene ("AdminMainMenu");
		ApplePickerHistory.instance.mySpecialFunction ();
	}
	public void openHistroyPanel(){
		historyApplePanel.SetActive (true);
	}

}
