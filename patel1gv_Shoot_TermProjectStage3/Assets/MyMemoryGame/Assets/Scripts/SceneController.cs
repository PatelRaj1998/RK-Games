using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(AudioSource))]
public class SceneController : MonoBehaviour {

	[SerializeField] private MemoryCard originalCard;
	[SerializeField] private Sprite[] images;

	public const int gridRows = 4;
	public const int gridCols = 5;
	public const float offsetX = -1.7f;
	public const float offsetY = 1.7f;
	public LetsAudio lsa;
	public GameObject des;
	public Text timerText;
	private float startTime;

	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;
	private int _score = 1000;
	private int counter = 0;

	void Start() {
		startTime = Time.time;
		Vector3 startPos = originalCard.transform.position;
		int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
		numbers = ShuffleArray(numbers);

		for (int i = 0; i < gridCols; i++)
		{
			for (int j = 0; j < gridRows; j++) 
			{
				MemoryCard card;
				if (i == 0 && j == 0) 
				{
					card = originalCard;
				} else 
				{
					card = Instantiate (originalCard) as MemoryCard;
				}
				int index = j * gridCols + i;
				int id = numbers[index];
				card.SetCard (id, images [id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3 (posX, posY, startPos.z);
			}
		}
	}

	private int[] ShuffleArray(int[] numbers) {
		int[] newArray = numbers.Clone () as int[];
		for (int i = 0; i < newArray.Length; i++) {
			int tmp = newArray [i];
			int r = Random.Range (i, newArray.Length);
			newArray [i] = newArray [r];
			newArray [r] = tmp;
		}
		return newArray;
	}

	public bool canReveal {
		get {return _secondRevealed == null;}
	}

	public void CardRevealed(MemoryCard card) {
		if (_firstRevealed == null) 
		{
			_firstRevealed = card;
		} 
		else 
		{
			_secondRevealed = card;
			StartCoroutine(CheckMatch());
		}
	}

	[SerializeField] private TextMesh scoreLabel;

	private IEnumerator CheckMatch() {
		if (_firstRevealed.id == _secondRevealed.id) {
			counter++;
		}
		else {
			_score = _score - 40;
			scoreLabel.text = "Score: " + _score;

			yield return new WaitForSeconds(.5f);

			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();
		}

		_firstRevealed = null;
		_secondRevealed = null;
	}



	void Update()
	{
		float t = Time.time - startTime;
		string minutes = ((int)t / 60).ToString ();
		string seconds = (t % 60).ToString ("f2");
		timerText.text = "Time: " + minutes + ":" + seconds;

		checkFunction ();
	}
	int i = 0;

	void checkFunction(){
		if (counter == 10) {
			timerText.text = "Congratulations, You won";
			PlayerPrefs.SetInt ("Score4",_score);
			DestroyObject (des);
			lsa.PlayWinAudio ();
			SceneManager.LoadScene ("AdminMainMenu");

		}
		else if(_score <= 0){
			timerText.text = "Sorry, You lost";
			PlayerPrefs.SetInt ("Score4",_score);
			DestroyObject (des);
			lsa.PlayLoosingAudio ();
			//yield return new WaitForSeconds(lsa.LooseSound.clip.length);
			SceneManager.LoadScene ("AdminMainMenu");

		}
	}
}
