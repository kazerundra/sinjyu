using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleBack : MonoBehaviour {
    float timelimit;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timelimit += Time.deltaTime;
        if (timelimit >= 3){
            if (Input.GetKeyUp("space")|| Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.Joystick2Button1)) {
                SceneManager.LoadScene("TittleScreen");
            }
        }
		
	}
}
