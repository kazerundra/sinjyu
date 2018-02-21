using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour {


    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;
    // current pawn position
    public GameObject panelPosition;
    // choosing where to move cursor
    public GameObject panelCursor;
    public GameObject gameController;
    public GameObject battleController;
	//put pawn there if dead
	public GameObject graveyard;
    //after battle pos
    public Vector3 previosPos;
    public Vector3 battlePos;
    public GameObject previosPanel;
    //check confirmation screen on or not
    public bool confirmationscreen;
    //confirm text
    public GameObject confirmscrn;
    //map menu choice
    public GameObject movementChoicemenu;
    //map menu on/off
    public bool movementScreen;
    public bool moveMenu;
	public bool mapChange;
	public bool moveMenuDone;

    public GameObject moveHighlight;
    public GameObject menuScript;
    int pos = 1;
    //flag for push button once only
    private bool isKeyPressing;
    private bool isKeyPressing2;

    //which enemy are fighting 1enemy, 2 enemy2
    public int enemyNmbr;
	public bool nomove;


    //bool
	// if character pawn on top of eachother
	public bool inBattle;
    public bool movementSelect;
	//battle flag;
	public bool battleStart;
	// move animation start;
	private bool moveStart;
	//lose pushed back
	private bool moveBack;
	//pawn moving speed

	//bool for any challenge on or not
	private bool menuNo;

	// bool if fly back knockback
	private bool flyback;

	public GameObject challengeWord;
	public bool challenge;

	private float pawnMoveSPD;
	private float pawnMoveTime;


    // determine which char battlestart
	public bool onTop;
    public int player1;
    public int player2;
	public GameObject pawn1;
	public GameObject pawn2;
	public GameObject pawn3;
	public GameObject pawn4;
	public GameObject healPanel;


	//tutorial
	public GameObject playerMage;
	public GameObject bubbletext1;
	public GameObject bubbletext2;
	public GameObject bubbletext3;
	public GameObject bubbletext4;
	public GameObject bubbletext5;
	public GameObject bubbletext6;
	public bool pressed;


    //references
    private PanelScript panelscript;
	private GameController gamectr;

	private movebackPhase movebackphase;
	// Use this for initialization

	void Start () {
        panelscript = panelPosition.GetComponent<PanelScript>();
		gamectr = gameController.GetComponent<GameController>();
        transform.position = panelPosition.transform.position;
		pawnMoveSPD = 0.3f;
		previosPanel = panelPosition;

	}
    private void confirmOk()
	{ 		
        confirmscrn.SetActive(false);
        panelscript = panelPosition.GetComponent<PanelScript>();
		moveStart = true;
    }
    private void confirmNo()
    {		
        confirmscrn.SetActive(false);
		gamectr.mvphaseChange (movePhase.movemenu);
    }
    private void upMove()
    {
        
        
        movementSelect = true;

        GameObject panelmove = panelPosition;

		if (transform.position.y < panelscript.Arm[0].transform.position.y&&panelmove != panelscript.Arm[0])
        {

            panelmove = panelscript.Arm[0];

        }
		else if (transform.position.y < panelscript.Arm[1].transform.position.y&&panelmove != panelscript.Arm[1])
        {

            panelmove = panelscript.Arm[1];
        }
		else if (transform.position.y < panelscript.Arm[2].transform.position.y&&panelmove != panelscript.Arm[2])
        {

            panelmove = panelscript.Arm[2];
        }
		else if (transform.position.y < panelscript.Arm[3].transform.position.y&&panelmove != panelscript.Arm[3])
        {

            panelmove = panelscript.Arm[3];
        }
        else { panelmove = panelPosition; }
        panelCursor.transform.position = panelmove.transform.position;
        panelPosition = panelmove;
    } 
    private void downMove()
    {
        movementSelect = true;

        GameObject panelmove = panelPosition;

		if (transform.position.y > panelscript.Arm[0].transform.position.y&&panelmove != panelscript.Arm[0])
        {

            panelmove = panelscript.Arm[0];

        }
		else if (transform.position.y > panelscript.Arm[1].transform.position.y&&panelmove != panelscript.Arm[1])
        {

            panelmove = panelscript.Arm[1];
        }
		else if (transform.position.y > panelscript.Arm[2].transform.position.y&&panelmove != panelscript.Arm[2])
        {

            panelmove = panelscript.Arm[2];
        }
		else if (transform.position.y > panelscript.Arm[3].transform.position.y&&panelmove != panelscript.Arm[3])
        {

            panelmove = panelscript.Arm[3];
        }
        else { panelmove = panelPosition; }
        panelCursor.transform.position = panelmove.transform.position;
        panelPosition = panelmove;
    }
    private void leftMove()
    {

        movementSelect = true;
        GameObject panelmove = panelPosition;

		if (transform.position.x > panelscript.Arm[0].transform.position.x&&panelmove != panelscript.Arm[0])
        {

            panelmove = panelscript.Arm[0];
        }
		else if (transform.position.x > panelscript.Arm[1].transform.position.x&&panelmove != panelscript.Arm[1])
        {

            panelmove = panelscript.Arm[1];
        }
		else if (transform.position.x > panelscript.Arm[2].transform.position.x&&panelmove != panelscript.Arm[2])
        {

            panelmove = panelscript.Arm[2];
        }
		else if (transform.position.x > panelscript.Arm[3].transform.position.x&&panelmove != panelscript.Arm[3])
        {

            panelmove = panelscript.Arm[3];
        }
        else { panelmove = panelPosition; }
        panelCursor.transform.position = panelmove.transform.position;
        panelPosition = panelmove;
    }
    private void rightMove()
    {
        movementSelect = true;
        GameObject panelmove = panelPosition;
		if (transform.position.x < panelscript.Arm[0].transform.position.x &&panelmove != panelscript.Arm[0])
        {
		    panelmove = panelscript.Arm[0];
        }
		else if (transform.position.x < panelscript.Arm[1].transform.position.x&&panelmove != panelscript.Arm[1])
        {

            panelmove = panelscript.Arm[1];
        }
		else if (transform.position.x < panelscript.Arm[2].transform.position.x&&panelmove != panelscript.Arm[2])
        {

            panelmove = panelscript.Arm[2];
        }
		else if (transform.position.x < panelscript.Arm[3].transform.position.x&&panelmove != panelscript.Arm[3])
        {

            panelmove = panelscript.Arm[3];
        }
        else { panelmove = panelPosition; }
        panelCursor.transform.position = panelmove.transform.position;
        panelPosition = panelmove;
    }

 
    void mvMenu(int nbr)
    {
        if (player.GetComponent<player>().playerNumber == nbr)
        {
			movementSelect = true;
            panelCursor.SetActive(true);
			//here
        }
        else
        {
			movementSelect = false;           
            //panelCursor.transform.position = this.transform.position;
            panelCursor.SetActive(false);
        }
    }


	public void backToPrevios(){
		panelPosition = previosPanel;
		panelscript = panelPosition.GetComponent<PanelScript> ();
		flyback = true;
	}

	public void battleStarter(int nmbr){
		if (nmbr == 1) {
            
			pawnMoveTime = 0;
			pawnMoveSPD = 0.3f;
			battleStart = true;		
			enemyNmbr = 1;
			if (player.GetComponent<player> ().playerNumber == 1 || player.GetComponent<player> ().playerNumber == 3) {
				if (player.GetComponent<player> ().playerNumber == 1)
					player1 = 1;
				if (player.GetComponent<player> ().playerNumber == 3)
					player1 = 3;
				//inBattle = true;            
				player2 = 2;
				battleController.GetComponent<BattleChanger> ().player1ch (player1);
				battleController.GetComponent<BattleChanger> ().player2ch (2);
				player.GetComponent<player> ().changeEnemy (2);

			} else if (player.GetComponent<player> ().playerNumber == 2 || player.GetComponent<player> ().playerNumber == 4) {
				// inBattle = true;  
				if (player.GetComponent<player> ().playerNumber == 2)
					player2 = 2;
				if (player.GetComponent<player> ().playerNumber == 4)
					player2 = 4;
				player1 = 1;
				battleController.GetComponent<BattleChanger> ().player2ch (player2);
				battleController.GetComponent<BattleChanger> ().player1ch (1);
				player.GetComponent<player> ().changeEnemy (1);
			}
           
            gamectr.changePhase (battlePhase.BATTLE);
            

        } else if (nmbr == 2) {
			pawnMoveTime = 0;
			pawnMoveSPD = 0.3f;
			battleStart = true;
			//backToPrevios ();
			//enemy.GetComponent<MovementScript> ().backToPrevios ();

			enemyNmbr = 2;
			if (player.GetComponent<player>().playerNumber == 1 || player.GetComponent<player>().playerNumber == 3)
			{
				if (player.GetComponent<player>().playerNumber == 1) player1 = 1;
				if (player.GetComponent<player>().playerNumber == 3) player1 = 3;
				player2 = 4;
				battleController.GetComponent<BattleChanger>().player1ch(player1);
				battleController.GetComponent<BattleChanger>().player2ch(4);
				player.GetComponent<player>().changeEnemy(4);
			}
			else if (player.GetComponent<player>().playerNumber == 2 || player.GetComponent<player>().playerNumber == 4)
			{
				if (player.GetComponent<player>().playerNumber == 2) player2 = 2;
				if (player.GetComponent<player>().playerNumber == 4) player2 = 4;
				player1 = 3;
				battleController.GetComponent<BattleChanger>().player2ch(player2);
				battleController.GetComponent<BattleChanger>().player1ch(3);
				player.GetComponent<player>().changeEnemy(3);
			}
           
            gamectr.changePhase(battlePhase.BATTLE);
            
        }
	}

	private void next(){
		pawnMoveTime = 0;
		pawnMoveSPD = 0.3f;
		if (gamectr.phase == battlePhase.MAP1)
		{
			gamectr.changePhase(battlePhase.MAP12);
		}
		else if(gamectr.phase == battlePhase.MAP12) 
		{
			if (gamectr.player2.GetComponent<player> ().isDead != true)
				gamectr.changePhase (battlePhase.MAP2);
			else {
				gamectr.changePhase (battlePhase.MAP22);
			}
		} else if(gamectr.phase == battlePhase.MAP2)
		{
			gamectr.changePhase(battlePhase.MAP22);
		} else if(gamectr.phase == battlePhase.MAP22)
		{
			if (gamectr.player1.GetComponent<player> ().isDead != true)
				gamectr.changePhase (battlePhase.MAP1);
			else {
				gamectr.changePhase (battlePhase.MAP12);
			}
		} 
		moveStart = false;
	}
	void dead() {
		if (gamectr.player1.GetComponent<player> ().isDead == true) 
		{
			if (player.GetComponent<player>().playerNumber ==1 )transform.position = graveyard.transform.position;
		}
		if (gamectr.player2.GetComponent<player> ().isDead == true) 
		{
			if (player.GetComponent<player>().playerNumber ==2 )transform.position = graveyard.transform.position;
		}

	}


	IEnumerator tutorial(){
        gamectr.tutorialStart = true;
		challengeWord.gameObject.SetActive (true);
		yield return new WaitForSeconds(1);
		challengeWord.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.25f);
		playerMage.gameObject.SetActive (true);
		bubbletext1.gameObject.SetActive (true);
		yield return new WaitForSeconds(2);
		bubbletext2.gameObject.SetActive (true);
		bubbletext1.gameObject.SetActive (false);
		yield return new WaitForSeconds(2);
		bubbletext3.gameObject.SetActive (true);
		bubbletext2.gameObject.SetActive (false);
		yield return new WaitForSeconds(2);
		bubbletext4.gameObject.SetActive (true);
		bubbletext3.gameObject.SetActive (false);
		yield return new WaitForSeconds(2);
		bubbletext5.gameObject.SetActive (true);
		bubbletext4.gameObject.SetActive (false);
		yield return new WaitForSeconds(2);
		bubbletext6.gameObject.SetActive (true);
		bubbletext5.gameObject.SetActive (false);
		yield return new WaitForSeconds(2);
		bubbletext6.gameObject.SetActive (false);
		playerMage.gameObject.SetActive (false);
		yield return new WaitForSeconds(1);
		if (transform.position == enemy.transform.position && !battleStart) {
			battleStarter (1);
		} else if (transform.position == enemy2.transform.position && !battleStart) {
			battleStarter (2);
		}
		gamectr.tutorial = true;
        gamectr.tutorialStart = false;
	}


	IEnumerator challengeMark() {
		challengeWord.gameObject.SetActive (true);
		yield return new WaitForSeconds(1);
		challengeWord.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.25f);
		if (transform.position == enemy.transform.position && !battleStart) {
			battleStarter (1);
		} else if (transform.position == enemy2.transform.position && !battleStart) {
			battleStarter (2);
		}
	}
	void phaseChange(){		
		panelscript = panelPosition.GetComponent<PanelScript> ();
		if (player.GetComponent<player> ().playerNumber == 1) 
		{
			gamectr.changePhase (battlePhase.MAP12);
		} else if (player.GetComponent<player> ().playerNumber == 2) 
		{           
			gamectr.changePhase (battlePhase.MAP22);
		} else if (player.GetComponent<player> ().playerNumber == 3)
        {
            if (gamectr.player2.GetComponent<player>().isDead == true) { gamectr.changePhase(battlePhase.MAP22); }
            else { gamectr.changePhase(battlePhase.MAP2); }
           
		} else if (player.GetComponent<player> ().playerNumber == 4)
        {
            if (gamectr.player1.GetComponent<player>().isDead == true) { gamectr.changePhase(battlePhase.MAP12); }
            else { gamectr.changePhase(battlePhase.MAP1); }
		}
			
	}


    //map previos fix
    // Update is called once per frame
    void Update () {
		
		if (flyback) {
			pawnMoveTime += Time.deltaTime;

			transform.position = Vector3.MoveTowards (transform.position, panelPosition.transform.position, pawnMoveSPD *pawnMoveTime);
			if (transform.position == panelPosition.transform.position) {
				flyback = false;
				pawnMoveTime = 0;
			}
		}
		dead ();
		if (gamectr.phase == battlePhase.MAP1) {
			if (player.GetComponent<player> ().playerNumber != 1)
				return;
			else {
				if (gamectr.mapChange) {
					gamectr.mapChange = false;
					moveMenu = true;
				}
			}
		} else if (gamectr.phase == battlePhase.MAP12) {
			if (player.GetComponent<player> ().playerNumber != 3)
				return;
			else {
				if (gamectr.mapChange) {
					gamectr.mapChange = false;
					moveMenu = true;
				}
			}
		}else if (gamectr.phase == battlePhase.MAP2) {
			if (player.GetComponent<player> ().playerNumber != 2)
				return;
			else {
				if (gamectr.mapChange) {
					gamectr.mapChange = false;
					moveMenu = true;
				}
			}
		} else if (gamectr.phase == battlePhase.MAP22) {
			if (player.GetComponent<player> ().playerNumber != 4)
				return;
			else {
				if (gamectr.mapChange) {
					gamectr.mapChange = false;
					moveMenu = true;
				}
			}
		}
		if (moveMenu){
			moveMenu = false;
			previosPanel = panelPosition;
			gamectr.mvphaseChange (movePhase.movemenu);
			movementChoicemenu.gameObject.SetActive (true);
		}
		if (moveMenuDone) {
			gamectr.mvphaseChange (movePhase.moveselect);

		}
		if (gamectr.mvPhase == movePhase.movemenu) 
		{
			battleStart = false;
			if (player.GetComponent<player> ().playerNumber == 1 || player.GetComponent<player> ().playerNumber == 3) 
			{
				if (Input.GetAxis ("Vertical") < 0.1 && Input.GetAxis ("Vertical") > -0.1) 
				{
					isKeyPressing = false;
				}
				if (Input.GetKeyUp ("up") || Input.GetAxis ("Vertical") == -1)
				{
					if (!isKeyPressing) 
					{
						pos -= 1;
						if (pos < 0) {
							pos = 2;
						}
						if (moveHighlight != null) {
							moveHighlight.GetComponent<Text> ().color = Color.black;
						}
						moveHighlight = menuScript.GetComponent<MenuSelect> ().Selectable [pos];
						moveHighlight.GetComponent<Text> ().color = Color.blue;
						isKeyPressing = true;
					}

				} else if (Input.GetKeyUp ("down") || Input.GetAxis ("Vertical") == 1) 
				{
					if (!isKeyPressing) 
					{
						pos += 1;
						if (pos > 2) 
						{
							pos = 0;
						}
						if (moveHighlight != null) 
						{
							moveHighlight.GetComponent<Text> ().color = Color.black;
						}
						moveHighlight = menuScript.GetComponent<MenuSelect> ().Selectable [pos];
						moveHighlight.GetComponent<Text> ().color = Color.blue;
						isKeyPressing = true;
					}
				}
				if (Input.GetKeyUp ("space") || Input.GetKeyUp (KeyCode.Joystick1Button1)) {
					if (moveHighlight != null) 
					{
						if (moveHighlight == menuScript.GetComponent<MenuSelect> ().Selectable [0]) 
						{
							moveHighlight.GetComponent<Text> ().color = Color.black;
							moveMenuDone = true;
						} else if (moveHighlight == menuScript.GetComponent<MenuSelect> ().Selectable [1]) 
						{
							if (gamectr.healNumber1 <= 0)
								return;
							if (panelPosition != healPanel)
								return;
							else if (panelPosition == healPanel) 
							{
								gamectr.heal1 ();
								moveHighlight.GetComponent<Text> ().color = Color.black;
								phaseChange ();		
								movementChoicemenu.gameObject.SetActive (false);
							}
						} else if (moveHighlight == menuScript.GetComponent<MenuSelect> ().Selectable [2])
						{
							phaseChange ();
							movementChoicemenu.gameObject.SetActive (false);
						}
					}
				}
			} else if (player.GetComponent<player> ().playerNumber == 2 || player.GetComponent<player> ().playerNumber == 4) 
			{
				movementChoicemenu.SetActive (true);
				if (Input.GetAxis ("Vertical2") < 0.1 && Input.GetAxis ("Vertical2") > -0.1) 
				{
					isKeyPressing2 = false;
				}
				if (Input.GetKeyUp ("up") || Input.GetAxis ("Vertical2") == -1) 
				{
					if (!isKeyPressing2) {
						pos -= 1;
						if (pos < 0) {
							pos = 2;
						}
						if (moveHighlight != null) {
							moveHighlight.GetComponent<Text> ().color = Color.black;
						}
						moveHighlight = menuScript.GetComponent<MenuSelect> ().Selectable [pos];
						moveHighlight.GetComponent<Text> ().color = Color.blue;
						isKeyPressing2 = true;
					}
				} else if (Input.GetKeyUp ("down") || Input.GetAxis ("Vertical2") == 1) {
					if (!isKeyPressing2) {
						pos += 1;
						if (pos > 2) {
							pos = 0;
						}
						if (moveHighlight != null) {
							moveHighlight.GetComponent<Text> ().color = Color.black;
						}
						moveHighlight = menuScript.GetComponent<MenuSelect> ().Selectable [pos];
						moveHighlight.GetComponent<Text> ().color = Color.blue;
						isKeyPressing2 = true;
					}
				}
				if (Input.GetKeyUp ("tab") || Input.GetKeyUp (KeyCode.Joystick2Button1)) 
				{
					if (moveHighlight != null) {
						if (moveHighlight == menuScript.GetComponent<MenuSelect> ().Selectable [0]) {
							moveHighlight.GetComponent<Text> ().color = Color.black;
							moveMenuDone = true;
						} else if (moveHighlight == menuScript.GetComponent<MenuSelect> ().Selectable [1]) {
							if (gamectr.healNumber2 <= 0)
								return;
							if (panelPosition != healPanel)
								return;
							gamectr.heal2 ();
							moveHighlight.GetComponent<Text> ().color = Color.black;
							phaseChange ();
							movementChoicemenu.gameObject.SetActive (false);
						} else if (moveHighlight == menuScript.GetComponent<MenuSelect> ().Selectable [2]) {
							phaseChange ();
							movementChoicemenu.gameObject.SetActive (false);

						}

					}

				}
			}
		}
		if(gamectr.mvPhase == movePhase.moveselect)
		{
			movementChoicemenu.gameObject.SetActive (false);
			if (player.GetComponent<player> ().playerNumber == 1 || player.GetComponent<player>().playerNumber == 3) {
				if (Input.GetKey ("up") || Input.GetAxis ("Vertical") == -1) {
					upMove ();
				}
				if (Input.GetKey ("down") || Input.GetAxis ("Vertical") == 1) {
					downMove ();
				}
				if (Input.GetKey ("left") || Input.GetAxis ("Horizontal") == -1) {
					leftMove ();
				}
				if (Input.GetKey ("right") || Input.GetAxis ("Horizontal") == 1) {
					rightMove ();
				}
				if (Input.GetKeyUp ("space") || Input.GetKeyUp (KeyCode.Joystick1Button1)) 
				{
					moveStart = true;
					moveMenuDone = false;
				}
			} else if (player.GetComponent<player> ().playerNumber == 2 || player.GetComponent<player>().playerNumber == 4) {
				if (Input.GetKey ("up") || Input.GetAxis ("Vertical2") == -1) {
					upMove ();
				}
				if (Input.GetKey ("down") || Input.GetAxis ("Vertical2") == 1) {
					downMove ();
				}
				if (Input.GetKey ("left") || Input.GetAxis ("Horizontal2") == -1) {
					leftMove ();
				}
				if (Input.GetKey ("right") || Input.GetAxis ("Horizontal2") == 1) {
					rightMove ();
				}
				if (Input.GetKeyUp ("tab") || Input.GetKeyUp (KeyCode.Joystick2Button1)) 
				{
					moveStart = true;
					moveMenuDone = false;
				}
			}
		}	
		if (gamectr.tutorialStart == true)
		{
			gamectr.mvphaseChange(movePhase.pause);
		}
	
		if (moveStart) 
		{
			gamectr.mvphaseChange(movePhase.moving);
		}
		if (gamectr.mvPhase == movePhase.moving) 
		{
			
			pawnMoveTime += Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, panelPosition.transform.position, pawnMoveSPD *pawnMoveTime);
			if (transform.position == panelPosition.transform.position) 
			{
				pawnMoveTime = 0;
				if (transform.position == enemy.transform.position) {
					gamectr.mvphaseChange (movePhase.battle);

				} else if (transform.position == enemy2.transform.position) {
					gamectr.mvphaseChange (movePhase.battle);

				} else {
					gamectr.mvphaseChange (movePhase.pause);
					phaseChange ();
				}
				moveStart = false;
	
			}
		}

		if (gamectr.mvPhase == movePhase.battle)
		{
			if (gamectr.tutorial == false) {
				StartCoroutine (tutorial ());
			} else {
				StartCoroutine (challengeMark ());
			}
		}
	}
}

