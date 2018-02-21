using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera battleCamera;
    public Camera mapCamera;
    public GameObject battleCanvas;
    public GameObject mapCanvas;

   
       

        // Use this for initialization
    public void BattleCamera() {
        battleCamera.enabled = true;
        mapCamera.enabled = false;
        battleCanvas.SetActive(true);
        mapCanvas.SetActive(false);
//        mapCanvas.SetActive(false);

    }
    public void MapCamera()
    {
        battleCamera.enabled = false;
        mapCamera.enabled = true;
        battleCanvas.SetActive(false);
        mapCanvas.SetActive(true);
    }
	
	// Update is called once per frame

}
