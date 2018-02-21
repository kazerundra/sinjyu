using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public enum movebackPhase {move,stop}
public enum movePhase {movemenu,moveselect,pause,moving,battle}
public enum battlePhase {MAP1,MAP12, MAP2,MAP22, BATTLE }
public class GameController : MonoBehaviour {
    public GameObject cameraController;
    public GameObject battleController;
    public GameObject controller1;
    public GameObject controller2;
	public GameObject battleChanger;
    public battlePhase phase;
	public movePhase mvPhase;
    bool battle= true;
    public GameObject turnText;
    public int turn;

    public bool upBtn = false;
    public bool downBtn = false;
    public bool leftBtn = false;
    public bool rightBtn = false;

	public bool upBtn2 = false;
	public bool downBtn2 = false;
	public bool leftBtn2 = false;
	public bool rightBtn2 = false;
	//bgm

	public AudioClip bgmBattle;
	public AudioClip bgmMap;
	public bool mapBgm;
	public bool battleBgm;
    AudioSource audiosource;
	//player 1234
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
    public GameObject p1p;
    public GameObject p2p;
    public GameObject p3p;
    public GameObject p4p;
    public GameObject player1C;
	public GameObject player2C;
	public GameObject player3C;
	public GameObject player4C;
	public GameObject healIcon0;
	public GameObject healIcon1;
	public GameObject healIcon2;
	public GameObject healIcon3;
	public GameObject healIcon4;
	public GameObject healIcon5;
	public GameObject p2s;

	public bool battleStart;
	public bool tutorial;
    public bool tutorialStart;
	public bool mapChange;

    //howmanytime can heal
    public int healNumber1;
	public int healNumber2;


	public void mvphaseChange(movePhase change){
		mvPhase = change;
	}
    // Use this for initialization
    public void changePhase (battlePhase change)
    {
		mapChange = true;
        phase = change;
        turnText.GetComponent<Text>().text = "Player " + turn + " Turn";
    }
    //デバッグ用
    void DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //処理を書く
                   // Debug.Log(code);
                    break;
                }
            }
        }
    }
    void player1control()
    {

      
		if (Input.GetKeyUp(KeyCode.Joystick1Button0)|| Input.GetKeyUp("q"))
        {

            controller1.GetComponent<Control>().Attack();

        }
		if (Input.GetKeyUp(KeyCode.Joystick1Button1)|| Input.GetKeyUp("w"))
        {
            controller1.GetComponent<Control>().Guard();

        }
		if (Input.GetKeyUp(KeyCode.Joystick1Button3)|| Input.GetKeyUp("e"))
        {
            controller1.GetComponent<Control>().MagicAtk();

        }
		if (Input.GetKeyUp(KeyCode.Joystick1Button2)|| Input.GetKeyUp("r"))
        {
            controller1.GetComponent<Control>().Special();

        }

		if (!upBtn && Input.GetAxis("Vertical") ==-1|| Input.GetKeyDown("t"))
        {
            upBtn = true;
            //Debug.Log(Input.GetAxis("Vertical"));

            controller1.GetComponent<Control>().Skill1();
        }
		else if (Input.GetAxis("Vertical") != -1|| Input.GetKeyUp("t"))
        {
            upBtn = false;
        }
		if (!downBtn && Input.GetAxis("Vertical") == 1|| Input.GetKeyDown("t"))
        {
            downBtn = true;
            //Debug.Log(Input.GetAxis("Vertical"));

            controller1.GetComponent<Control>().Skill1();
		} else if (Input.GetAxis("Vertical") != 1|| Input.GetKeyUp("t"))
        {
            downBtn = false;
        }

		if (!rightBtn && Input.GetAxis("Horizontal") == 1|| Input.GetKeyUp("y"))
        {
            rightBtn = true;
            //Debug.Log(Input.GetAxis("Horizontal"));  
            controller1.GetComponent<Control>().Skill2();
        }else if (Input.GetAxis("Horizontal") != 1)
        {
           rightBtn = false;
        }
		if ( !leftBtn && Input.GetAxis("Horizontal") == -1|| Input.GetKeyUp("y"))
        {
            leftBtn = true;
           // Debug.Log(Input.GetAxis("Horizontal"));
            controller1.GetComponent<Control>().Skill2();
        } else if (Input.GetAxis("Horizontal") != -1)
        {
            leftBtn = false;
        }
    }
    void player2control()
    {

		if (Input.GetKeyUp(KeyCode.Joystick2Button0)|| Input.GetKeyUp("a"))
        {

            controller2.GetComponent<Control>().Attack();

        }
		if (Input.GetKeyUp(KeyCode.Joystick2Button1)|| Input.GetKeyUp("s"))
        {
            controller2.GetComponent<Control>().Guard();

        }
		if (Input.GetKeyUp(KeyCode.Joystick2Button3)|| Input.GetKeyUp("d"))
        {
            controller2.GetComponent<Control>().MagicAtk();

        }
		if (Input.GetKeyUp(KeyCode.Joystick2Button2)|| Input.GetKeyUp("f"))
        {
            controller2.GetComponent<Control>().Special();

        }

		if (!upBtn && Input.GetAxis("Vertical2") ==-1|| Input.GetKeyDown("g"))
		{
			upBtn2 = true;
			//Debug.Log(Input.GetAxis("Vertical2"));

			controller2.GetComponent<Control>().Skill1();
		}
		else if (Input.GetAxis("Vertical2") != -1|| Input.GetKeyUp("g"))
		{
			upBtn2 = false;
		}
		if (!upBtn && Input.GetAxis("Vertical2") ==1|| Input.GetKeyDown("g"))
		{
			downBtn2 = true;
			//Debug.Log(Input.GetAxis("Vertical2"));

			controller2.GetComponent<Control>().Skill1();
		}
		else if (Input.GetAxis("Vertical2") != 1|| Input.GetKeyUp("g"))
		{
			downBtn2 = false;
		}

        
		if (Input.GetAxis("Horizontal2")== 1|| Input.GetKeyDown("h"))
        {
			leftBtn2 = true;
            controller2.GetComponent<Control>().Skill2();
		}else if (Input.GetAxis("Horizontal2") != 1|| Input.GetKeyUp("h"))
		{
			leftBtn2 = false;
		}
		if (Input.GetAxis("Horizontal2")== -1|| Input.GetKeyDown("h"))
		{
			rightBtn2 = true;
			controller2.GetComponent<Control>().Skill2();
		}else if (Input.GetAxis("Horizontal2") != -1|| Input.GetKeyUp("h"))
		{
			rightBtn2 = false;
		}
    }
	void Start(){
		this.audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(this.bgmBattle);
        healNumber1 = 3;
		healNumber2 = 3;
		tutorial = true;
		mapChange = true;
	}
	public void heal1(){
		if (healNumber1 == 3) {
			healIcon2.gameObject.SetActive (false);
		} else if (healNumber1 == 2) {
			healIcon1.gameObject.SetActive (false);
		} else if (healNumber1 == 1) {
			healIcon0.gameObject.SetActive (false);
		} else
			return;
		healNumber1 -= 1;
		if (phase == battlePhase.MAP1)
			player1.GetComponent<player> ().heal ();
		else
			player3.GetComponent<player> ().heal ();
	}
	public void heal2(){
		if (healNumber2 == 3) {			
			healIcon5.gameObject.SetActive (false);
		} else if (healNumber2 == 2) {			
			healIcon4.gameObject.SetActive (false);
		} else if (healNumber2 == 1) {
			healIcon3.gameObject.SetActive (false);
		} else
			return;
		healNumber2 -= 1;
		if (phase == battlePhase.MAP2)
			player2.GetComponent<player> ().heal ();
		else
			player4.GetComponent<player> ().heal ();
	}
	void changeController(){
		if(battleChanger.GetComponent<BattleChanger>().player1 == 1) controller1 = GameObject.FindGameObjectWithTag("p1c");
		if(battleChanger.GetComponent<BattleChanger>().player1 == 3) controller1 = GameObject.FindGameObjectWithTag("p3c");

		if(battleChanger.GetComponent<BattleChanger>().player2 == 2) controller2 = GameObject.FindGameObjectWithTag("p2c");
		if(battleChanger.GetComponent<BattleChanger>().player2 == 4) controller2 = GameObject.FindGameObjectWithTag("p4c");
	}
    // Update is called once per frame
    void Update () {
        if (phase != battlePhase.BATTLE)
        {
            if (!mapBgm)
            {
                audiosource.Stop();
                audiosource.PlayOneShot(this.bgmMap);
                mapBgm = true;
                battleBgm = false;
            }
        }
        if (phase == battlePhase.BATTLE)
        {
            if (!battleBgm)
            {
                audiosource.Stop();
                audiosource.PlayOneShot(this.bgmBattle);
                battleBgm = true;
                mapBgm = false;
            }
        }
        if (phase == battlePhase.MAP1){
            p1p.GetComponent<MovementScript>().panelCursor.SetActive(true);
            p2p.GetComponent<MovementScript>().panelCursor.SetActive(false);
            p3p.GetComponent<MovementScript>().panelCursor.SetActive(false);
            p4p.GetComponent<MovementScript>().panelCursor.SetActive(false);
        }
        else if (phase == battlePhase.MAP12)
        {
            p1p.GetComponent<MovementScript>().panelCursor.SetActive(false);
            p2p.GetComponent<MovementScript>().panelCursor.SetActive(false);
            p3p.GetComponent<MovementScript>().panelCursor.SetActive(true);
            p4p.GetComponent<MovementScript>().panelCursor.SetActive(false);
        }
        if (phase == battlePhase.MAP2)
        {
            p1p.GetComponent<MovementScript>().panelCursor.SetActive(false);
            p2p.GetComponent<MovementScript>().panelCursor.SetActive(true);
            p3p.GetComponent<MovementScript>().panelCursor.SetActive(false);
            p4p.GetComponent<MovementScript>().panelCursor.SetActive(false);
        }
        if (phase == battlePhase.MAP22)
        {
            p1p.GetComponent<MovementScript>().panelCursor.SetActive(false);
            p2p.GetComponent<MovementScript>().panelCursor.SetActive(false);
            p3p.GetComponent<MovementScript>().panelCursor.SetActive(false);
            p4p.GetComponent<MovementScript>().panelCursor.SetActive(true);
        }
		if (controller1.GetComponent<Control> ().battleStart == true && controller2.GetComponent<Control> ().battleStart == true) {
			battleStart = true;
			//controller1.GetComponent<Control> ().battleStart = false;
			//controller2.GetComponent<Control> ().battleStart = false;
		}
		else
			battleStart = false;
       // DownKeyCheck();
        if (phase == battlePhase.BATTLE)
		{
            changeController();
            cameraController.GetComponent<CameraController>().BattleCamera();
            if (battle){
                battleController.GetComponent<BattleScript>().battleStart();
                battle = false;
            }
            player1control();
            player2control();      

        }
        else if (phase == battlePhase.MAP1 || phase == battlePhase.MAP2 || phase == battlePhase.MAP12 || phase == battlePhase.MAP22)
		{
			if (player3.GetComponent<player> ().isDead == true || player4.GetComponent<player> ().isDead == true)
				turn = 5;
            if (phase == battlePhase.MAP1)
            {
                if (player1.GetComponent<player>().isDead != true)
                {
                    turn = 1;
                }
                else
                {
                    p1p.GetComponent<MovementScript>().panelCursor.SetActive(false);
                    turn = 2;
                }
            } else if ( phase == battlePhase.MAP12)
            {
				turn = 2;
            }
            else if (phase == battlePhase.MAP2)
            {
                if (player2.GetComponent<player>().isDead != true)
                {
                    turn = 3;                   
                }
                else
                {
                    turn = 4;
                    p2p.GetComponent<MovementScript>().panelCursor.SetActive(false);
                }
                   
            }
            else if (  phase == battlePhase.MAP22)
            {
                turn = 4;
            }
            
            battle = true;
            cameraController.GetComponent<CameraController>().MapCamera();
        }  

		
	}
}
