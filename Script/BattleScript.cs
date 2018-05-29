
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject player1sprite;
    public GameObject player2sprite;
    public GameObject GameController;
    //command input 確認 image
    public GameObject commandBoard;
    //Player 2 command input 確認 image
    public GameObject commandBoard2;
	public int playernumber1;
	public int playernumber2;

    public bool battlePhaseOver;
	public attackturn turnstate;
	public attackturn turnstate1;
	public attackturn turnstate2;
   
    public int first;
    public int second;
    public int third;
    // end battle
    public bool battle;
	public int p13;
	public int p24;

    // 1 = attack
    // 2 = guard
    // 3 = break
    // 4 = attack skill
    // 5 = guard skill
    // 6 = buff skill
    // 7 = finish skill

    int[,] table = new int[,] {
                    
       {0,2,1,3,3,5,3},        
       {1,6,2,8,6,3,3},          
       {2,1,0,3,3,5,3},
       {4,7,4,5,3,5,3},
       {4,6,4,4,6,3,8},
       {5,4,5,5,4,5,3},
       {4,4,4,4,7,4,5}
    };
    // 0 draw  1 p1win 2 p2win  
    //3 2onlyActivated 4 1onlyActivated 5 BothActivated 6 Nothing  
    //7 reduced damageP1 8 reduced damage p2
    //     p21  p22  p23    p24   p25  p26
    //p1 1 D    p1L  p1W    Sklonly    BothAct
    //p1 2 p1W  D    p1L            
    //p1 3 p1L  p1W   D
    //p1 4 sChk
    //p1 5
    //p1 6                             FxF

    // Use this for initialization
    void Start () {
        battle = false;
        
    }
    public void battleStart()
    {
        player1sprite.GetComponent<player>().changePhase(attackturn.WAIT);
        player2sprite.GetComponent<player>().changePhase(attackturn.WAIT);
    }


	// Update is called once per frame
	void Update () {
		turnstate1 = player1sprite.GetComponent<player> ().turnState;
		turnstate2 = player2sprite.GetComponent<player> ().turnState;
		if (turnstate1 == turnstate2) {
			turnstate = turnstate1;
		}

        if(this.GetComponent<BattleChanger>().player1 == 1)
        {
            // player1 = GameObject.Find("1pController");
            player1 = GameObject.FindGameObjectWithTag("p1c");
            player1sprite = GameObject.Find("Player");
			playernumber1 = 1;

        }
        if (this.GetComponent<BattleChanger>().player1 == 3)
        {
            // player1 = GameObject.Find("3pController");
            player1 = GameObject.FindGameObjectWithTag("p3c");
            player1sprite = GameObject.Find("Player3");
			playernumber1 = 3;
        }  
        if(this.GetComponent<BattleChanger>().player2 == 2)
        {
           // player2 = GameObject.Find("2pController");
            player2 = GameObject.FindGameObjectWithTag("p2c");
            player2sprite = GameObject.Find("Player2");
			playernumber2 = 2;
        }
        if (this.GetComponent<BattleChanger>().player2 == 4)
        {
            player2 = GameObject.FindGameObjectWithTag("p4c");
            //player2 = GameObject.Find("4pController");
            player2sprite = GameObject.Find("Player4");
			playernumber2 = 4;
        }
        if (GameController.GetComponent<GameController>().phase == battlePhase.BATTLE)
        {
            battlePhaseOver = false;
        }

        if (player1sprite.GetComponent<player>().turnState == attackturn.OVER && player2sprite.GetComponent<player>().turnState == attackturn.OVER)
        {
            battle = false;
            battlePhaseOver = true;
         
            if (GameController.GetComponent<GameController>().turn == 1)
            {
                GameController.GetComponent<GameController>().changePhase(battlePhase.MAP12);
            }
            else if (GameController.GetComponent<GameController>().turn == 2)
            {
				if (GameController.GetComponent<GameController> ().player2.GetComponent<player> ().isDead == true) {
					GameController.GetComponent<GameController> ().changePhase (battlePhase.MAP22);
				} else {
					GameController.GetComponent<GameController>().changePhase(battlePhase.MAP2);
				}
              
            }
            else if (GameController.GetComponent<GameController>().turn == 3)
            {
                GameController.GetComponent<GameController>().changePhase(battlePhase.MAP22);
            }
            else if (GameController.GetComponent<GameController>().turn == 4)
            {
				if (GameController.GetComponent<GameController> ().player1.GetComponent<player> ().isDead == true) {
					GameController.GetComponent<GameController> ().changePhase (battlePhase.MAP12);
				} else {
					GameController.GetComponent<GameController>().changePhase(battlePhase.MAP1);
				}               
            }
            else
            {
                Debug.Log("error");
            }
            
        }
     
            
        if(GameController.GetComponent<GameController>().phase == battlePhase.BATTLE)
        {
            battlePhaseOver = false;
        }
        Debug.Log(battle + "  battlescript");
        //battle animation start
		//Debug.Log(battle);
		if (GameController.GetComponent<GameController> ().battleStart == true && !battle) { 
			first = table [player1.GetComponent<Control> ().first, player2.GetComponent<Control> ().first];
			second = table [player1.GetComponent<Control> ().second, player2.GetComponent<Control> ().second];
			third = table [player1.GetComponent<Control> ().third, player2.GetComponent<Control> ().third];
//			Debug.Log (first);
//			Debug.Log (second);
//			Debug.Log (third);
			battle = true;
			//Debug.Log(battle);
		}

		if (player1sprite.GetComponent<player> ().isDead == true|| player2sprite.GetComponent<player>().isDead == true) {
			battle = false;
		}
        //battle animation over
     
        if (player1sprite.GetComponent<player>().turnState == attackturn.NEXT && player2sprite.GetComponent<player>().turnState == attackturn.NEXT)
        {
            player1sprite.GetComponent<player>().turnState = attackturn.WAIT;
            player2sprite.GetComponent<player>().turnState = attackturn.WAIT;
            battle = false;

        }





    }
}
