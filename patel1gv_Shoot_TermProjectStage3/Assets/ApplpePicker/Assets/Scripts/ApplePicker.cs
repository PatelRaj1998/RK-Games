using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
	public ApplePickerHistory aph;
    	// Use this for initialization
	void Start () {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {

            // GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;

            Vector3 pos = Vector3.zero;

            pos.y = basketBottomY + (basketSpacingY * i);

            tBasketGO.transform.position = pos;

            basketList.Add(tBasketGO);
        }
	}

    //Update is called once per frame
    void Update()
    {

    }
    
    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        int basketIndex = basketList.Count - 1;

        GameObject tBracketGo = basketList[basketIndex];

        basketList.RemoveAt(basketIndex);

        Destroy(tBracketGo);

        if (basketList.Count == 0)
        {
			//int score = PlayerPrefs.GetInt ("AppleScore");
			//int strScore = score;

			//Debug.Log ("  "+strScore);

//			PlayerPrefs.SetInt ("dicScore", strScore);
			//aph.applePickerhis.Add (datetime, strScore);
			//aph.applePickerhis.Add ("123", "456");
            SceneManager.LoadScene("AdminMainMenu");
        }
       
    }

    // Update is called once per frame
    
}
