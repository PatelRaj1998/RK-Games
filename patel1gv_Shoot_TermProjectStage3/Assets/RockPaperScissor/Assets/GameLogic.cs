using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {
	
	//Defining the  constants 
	enum elements {Scissor = 1, Paper = 2, Rock = 3 }

	//setting values of playerchoose and computerchoose sa -1 by default
	private int playerchoose = -1;
	private int Computerchoose  = -1;

	//seting playersturn value to be true by default
	private bool playersTurn = true;

	//setting other variables values
	int Computercount=0 , playercount=0  ,counter=1;

	//declaring gameobject winnertext to display output
	public GameObject WinnerText;

	public Sprite paperImage, rockImage, scissorImage; // introducing images
	public GameObject ComputerchooseImage;

	// Update is called once per frame
	void Update () {
		for (int i =1;i<=10;i++) {
			if (playersTurn && playerchoose == -1)
				continue;
			else {
				ComputerChoose ();//calling function computerchoose to choose the value for computer
				checkWinner ();// checking the winner

				playerchoose = -1;//setting the value back to default
				playersTurn = true;

			}

			counter++;
		}

	}

	void checkWinner (){

		Text myText1 = WinnerText.GetComponent<Text> ();
		myText1.color = Color.white;

		if (playerchoose == Computerchoose) {

			//draw
			myText1.text = " Draw";//writing the result after each move

			playercount++;//increamenting both counters
			Computercount++;

		}
		else if (playerchoose == 2 && Computerchoose == 3) {
			//player wins
			myText1.text = " Player wins";
			playercount++;

		}
		else if (playerchoose == 3 && Computerchoose == 2) {

			//Computer wins
			myText1.text = " Computer wins";
			Computercount++;


		}
		else if (playerchoose == 1 && Computerchoose == 3) {
			//Computer wins
			myText1.text = " Computer wins";
			Computercount++;

		}
		else if (playerchoose == 3 && Computerchoose == 1) {
			//Computer wins
			myText1.text = " Player wins";
			playercount++;

		}
		else if (playerchoose == 2 && Computerchoose == 1) {
			//Computer wins

			myText1.text = " Computer wins";
			Computercount++;
		}
		else if (playerchoose == 1 && Computerchoose == 2) {
			//player wins

			myText1.text = " Player wins";
			playercount++;
		}  

		if (counter % 10 == 0)
			WinnerDeclaration ();

	}
	public void ComputerChoose(){


		Computerchoose = Random.Range (1, 4); //computer chooses the random value [1, 2, 3]

		if (Computerchoose == 1) {

			ComputerchooseImage.GetComponent<Image>().sprite = scissorImage; // if computer chhoses 1 then assign it the image of scissor
		}
		else if (Computerchoose == 2) {

			ComputerchooseImage.GetComponent<Image>().sprite = paperImage; // if computer chhoses 2 then assign it the image of paper
		}
		else {

			ComputerchooseImage.GetComponent<Image>().sprite = rockImage; // if computer chhoses 3 then assign it the image of rock
		}
	}

	public void playerchoice (int choose ){

		playerchoose = choose; // taking the choice from the button clicked
		playersTurn = false;

	}

	// To declare the winner and displaying it on the screen
	public void WinnerDeclaration(){
		Text myText2 = WinnerText.GetComponent<Text> ();

		if (Computercount > playercount)
		{
			myText2.color = Color.red; // setting the color to red
			myText2.text = " SORRY, YOU LOST THE GAME";
			PlayerPrefs.SetInt ("Score3",1);
		} 
		else if (Computercount < playercount) 
		{
			myText2.color = Color.cyan; // setting the color to cyan
			myText2.text = " CONGRATULATIONS, YOU WON THE GAME";
			PlayerPrefs.SetInt ("Score3",0);
		} 
		else 
		{
			myText2.color = Color.magenta; // setting the color to magenta
			myText2.text = "  TIE ";
			PlayerPrefs.SetInt ("Score3",2);
		}
		SceneManager.LoadScene ("AdminMainMenu"); // to quit after 10 moves
	}
	public void GoToAdminMainMenu()
	{
		SceneManager.LoadScene ("AdminMainMenu"); 
	}
}