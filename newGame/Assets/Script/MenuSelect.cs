using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour {

    public GameObject[] Selectable;
	public GameObject gamecontroller;

	public void mvSelect1(){
		Selectable [0] = GameObject.Find ("Move");
		Selectable [1] = GameObject.Find ("Heal");
		Selectable [2] = GameObject.Find ("End");
	}
	public void mvSelect2(){
		Selectable [0] = GameObject.Find ("Move2");
		Selectable [1] = GameObject.Find ("Heal2");
		Selectable [2] = GameObject.Find ("End2");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gamecontroller.GetComponent<GameController> ().phase == battlePhase.MAP1 || gamecontroller.GetComponent<GameController>().phase == battlePhase.MAP12) {
			mvSelect1 ();
		} else if (gamecontroller.GetComponent<GameController> ().phase == battlePhase.MAP2|| gamecontroller.GetComponent<GameController>().phase == battlePhase.MAP22) {
			mvSelect2 ();
		}
	}
}
