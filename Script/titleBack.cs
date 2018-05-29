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
            if (Input.GetButton("Confirm")|| Input.GetButton("Confirm2")) {
                SceneManager.LoadScene("TittleScreen");
            }
        }
		
	}
}
