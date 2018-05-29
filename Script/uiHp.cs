using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiHp : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;

    // Use this for initialization
    void Start () {
   


    }

    // Update is called once per frame
    void Update () {
        slider1.maxValue = p1.GetComponent<player>().maxHp;
        slider2.maxValue = p2.GetComponent<player>().maxHp;
        slider3.maxValue = p3.GetComponent<player>().maxHp;
        slider4.maxValue = p4.GetComponent<player>().maxHp;
        slider1.value = p1.GetComponent<player>().Hp;
        slider2.value = p2.GetComponent<player>().Hp;
        slider3.value = p3.GetComponent<player>().Hp;
        slider4.value = p4.GetComponent<player>().Hp;


    }
}
