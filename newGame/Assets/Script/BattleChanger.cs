using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleChanger : MonoBehaviour {

    public GameObject hpUi1;
    public GameObject hpUi2;
    public GameObject hpUi3;
    public GameObject hpUi4;
    public GameObject battlePlayer1;
	public GameObject battlePlayer2;
    public GameObject battlePlayer3;  
    public GameObject battlePlayer4;
    public int player1;
    public int player2;
   
    // Use this for initialization

    public void player1ch (int number)
    {
        player1 = number;
		// Debug.Log (player1);

		if(player1 == 1)
		{
			hpUi1.SetActive(true);
			battlePlayer1.SetActive(true);
			hpUi3.SetActive(false);
			battlePlayer3.SetActive(false);
		} else if(player1 == 3)
		{
			hpUi1.SetActive(false);
			battlePlayer1.SetActive(false);
			hpUi3.SetActive(true);
			battlePlayer3.SetActive(true);
		} 
    }
    public void player2ch(int number)
    {
		player2 = number;
		//Debug.Log (player2);
		//Debug.Log (player2);

		if (player2 == 2)
		{
			hpUi2.SetActive(true);
			hpUi4.SetActive(false);
			battlePlayer2.SetActive(true);
			battlePlayer4.SetActive(false);
		}  else if(player2 == 4)
		{
			hpUi2.SetActive(false);
			hpUi4.SetActive(true);
			battlePlayer2.SetActive (false);
			battlePlayer4.SetActive(true);
		}
    }

	
    
	// Update is called once per frame
	void Update () {

    }
}
