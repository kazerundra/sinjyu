using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TittleMenu : MonoBehaviour {
	public GameObject title;
	public GameObject gamestart;
	public GameObject playerSelect;
	public GameObject player;
	public GameObject bubbletext1;
	public GameObject bubbletext2;
	public GameObject bubbletext3;
	public GameObject bubbletext4;
	public GameObject bubbletext5;
	public GameObject bubbletext6;
	public bool pressed;
	public float time;
	public GameObject audios;

	int sequence =0;
    
    void gameStart()
    {
        SceneManager.LoadScene("Battle");
		pressed = false;
       
    }
	// Use this for initialization
	void Start () {
      
		
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed)
			time += Time.deltaTime;
		else
			time = 0;
		if (Input.GetKeyUp(KeyCode.Joystick1Button1) ||Input.GetKeyUp("space")&&sequence ==2 && time ==0)
        {
			audios.GetComponent<soundContr> ().play (1);
            gameStart();
          //  Debug.Log("jalan");
        }
		if (Input.GetKeyUp (KeyCode.Joystick1Button1) || Input.GetKeyUp ("space") && sequence == 0 && !pressed&& time ==0) {
			pressed = true;
			gamestart.SetActive (false);
			title.SetActive (false);
			playerSelect.SetActive (true);
			sequence = 1;
			audios.GetComponent<soundContr> ().play (1);
		} else
			pressed = false;
		if (Input.GetKeyUp (KeyCode.Joystick1Button1) ||Input.GetKeyUp("space") && sequence ==1 &&!pressed&& time ==0) {
			pressed = true;
			audios.GetComponent<soundContr> ().play (1);
			sequence = 2;
			playerSelect.SetActive (false);
            gameStart();
		}else
			pressed = false;
	
    }
}
