using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour {

    public GameObject[] Arm;
	// Use this for initialization
	void Start () {
		
	}

    public Vector2 Moveto()
    {
        return gameObject.transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
