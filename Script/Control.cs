using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {


    public GameObject Pawn;
    int commandNumber;
    //int atkType;
    public int buttonNumber;
    public bool battleStart;
    public bool reset;
    public int first;
    public int second;
    public int third;
    public int Skill1CD;
    public int Skill2CD;
    public GameObject battleScript;
    public GameObject player;
    public GameObject enemy;
    //どちのスキル
  
    //Player  command input 確認 image
    public GameObject commandBoard;
    //Player 何使うかのtext
    public GameObject commandText;
    //Player Buff Condition
    public GameObject buff;
    //if used cannot use anymore
    public bool specialUsed;


    //list battle order keluarin tulisannya
    List<BattleOrder> battleorder = new List<BattleOrder>();
    public List<BattleOrder> battleSaved = new List<BattleOrder>();


    public void commandTextShow(int order)
    {
        commandText.SetActive(true);
        commandText.GetComponent<Text>().text = battleSaved[order-1].name;
    }
    public void commandTextUnShow(int order)
    {
        commandText.SetActive(false);
        battleSaved.Clear();
    }
    private void cmndPlus()
    {
        commandNumber += 1;
        if (commandNumber > 3) return;
        //commandBoard.transform.GetChild(3).GetComponent<Image>().enabled = true;
        commandBoard.transform.GetChild(commandNumber-1).GetComponent<Image>().enabled = true;
    }

    public void Attack ()
    {
        if (!player.GetComponent<player>().commandOk) return;
	  if (player.GetComponent<player>().turnState == attackturn.WAIT || player.GetComponent<player>().turnState == attackturn.NEXT)
        {
        // atkType 0 attack 1 guard 2 break
        switch (commandNumber){
            case 0:
                first = 0;
               // commandBoard.transform.GetChild(3).GetComponent<Image>().enabled = true;
                battleorder.Add(new BattleOrder("Attack", commandNumber));
               // Debug.Log("1 attack");
                break;
            case 1:
                second = 0;
                battleorder.Add(new BattleOrder("Attack", commandNumber));
             //   Debug.Log("2 attack");

                break;
            case 2:
                third = 0;
                battleorder.Add(new BattleOrder("Attack", commandNumber));
               // Debug.Log("3 attack");
                break;
        }
        cmndPlus();
        }
        else return;
    }
    public void Guard()
    {
		
        if (!player.GetComponent<player>().commandOk) return;
        if (player.GetComponent<player>().turnState == attackturn.WAIT || player.GetComponent<player>().turnState == attackturn.NEXT)
        {

            // atkType 0 attack 1 guard 2 break
            switch (commandNumber)
            {
                case 0:
                    first = 1;
                    //commandBoard.transform.GetChild(3).GetComponent<Image>().enabled = true;
                    battleorder.Add(new BattleOrder("Guard", commandNumber));
                  //  Debug.Log("1 Guard");
                    break;
                case 1:
                    second = 1;
                    battleorder.Add(new BattleOrder("Guard", commandNumber));
                  //  Debug.Log("2 Guard");
                    break;
                case 2:
                    third = 1;
                    battleorder.Add(new BattleOrder("Guard", commandNumber));
                   // Debug.Log("3 Guard");
                    break;
            }
            cmndPlus();
        }
        else return;
    }
    public void MagicAtk()
    {
        if (!player.GetComponent<player>().commandOk) return;
        if (player.GetComponent<player>().turnState == attackturn.WAIT || player.GetComponent<player>().turnState == attackturn.NEXT)
        {
            if (commandNumber > 2) return;
        // atkType 0 attack 1 guard 2 break
        switch (commandNumber)
        {
            case 0:
                first = 2;
                //commandBoard.transform.GetChild(3).GetComponent<Image>().enabled = true;
                battleorder.Add(new BattleOrder("Magic", commandNumber));
             //   Debug.Log("1 MagicAtk");
                break;
            case 1:
                second = 2;
                battleorder.Add(new BattleOrder("Magic", commandNumber));
             //   Debug.Log("2 MagicAtk");
                break;
            case 2:
                third = 2;
                battleorder.Add(new BattleOrder("Magic", commandNumber));
             //   Debug.Log("3 MagicAtk");
                break;
        }
        cmndPlus();
        }
        else return;
    }
 


   

    public void Skill1()
    {
        if (!player.GetComponent<player>().commandOk) return;
        if (player.GetComponent<player>().turnState == attackturn.WAIT || player.GetComponent<player>().turnState == attackturn.NEXT)
        {
            if (Skill1CD > 0) return;
        // atkType 0 attack 1 guard 2 buff

        if (commandNumber > 2) return;
       // commandBoard.transform.GetChild(3).GetComponent<Image>().enabled = true;
        switch (commandNumber)
        {
            case 0:
                if (player.GetComponent<player>().Skill1 == 0)
                {
                    first = 3;
                    battleorder.Add(new BattleOrder("Skill1", commandNumber));
                    //commandBoard.transform.GetChild(3).gameObject.SetActive(true);

                }
                else if (player.GetComponent<player>().Skill1 == 1)
                {
                    first = 4;
                    battleorder.Add(new BattleOrder("Skill1", commandNumber));
                }
                else if (player.GetComponent<player>().Skill1 == 2)
                {
                    first = 5;
                    battleorder.Add(new BattleOrder("Skill1", commandNumber));
                }
                Skill1CD = player.GetComponent<player>().Skill1CD;
                break;
            case 1:
                if (player.GetComponent<player>().Skill1 == 0)
                {
                    second = 3;
                    battleorder.Add(new BattleOrder("Skill1", commandNumber));

                }
                else if (player.GetComponent<player>().Skill1 == 1)
                {
                    second = 4;
                    battleorder.Add(new BattleOrder("Skill1", commandNumber));
                }
                else if (player.GetComponent<player>().Skill1 == 2)
                {
                    second = 5;
                    battleorder.Add(new BattleOrder("Skill1", commandNumber));
                }
                Skill1CD = player.GetComponent<player>().Skill1CD;
                break;
            case 2:
                if (player.GetComponent<player>().Skill1 == 0)
                {
                    third = 3;
                    battleorder.Add(new BattleOrder("Skill1", commandNumber));

                }
                else if (player.GetComponent<player>().Skill1 == 1)
                {
                    third = 4;
                    battleorder.Add(new BattleOrder("Skill1", commandNumber));
                }
                else if (player.GetComponent<player>().Skill1 == 2)
                {
                    third = 5;
                    battleorder.Add(new BattleOrder("Skill1", commandNumber));
                }
                Skill1CD = player.GetComponent<player>().Skill1CD;
                break;
        }
        cmndPlus();
//        Debug.Log(first);
//        Debug.Log(second);
//        Debug.Log(third);
        }
        else return;

    }
    public void Skill2()
    {
        if (!player.GetComponent<player>().commandOk) return;
        if (Skill2CD > 0) return;
        if (player.GetComponent<player>().turnState == attackturn.WAIT || player.GetComponent<player>().turnState == attackturn.NEXT)
        {
            if (commandNumber > 2) return;
        //commandBoard.transform.GetChild(3).GetComponent<Image>().enabled = true;
        // atkType 0 attack 1 guard 2 break
        switch (commandNumber)
        {
            case 0:
                if (player.GetComponent<player>().Skill2 == 0) {
                    first = 3;
                    battleorder.Add(new BattleOrder("Skill2", commandNumber));
                    Skill2CD = player.GetComponent<player>().Skill2CD;

                }
                else if (player.GetComponent<player>().Skill2 == 1)
                {
                    first = 4;
                    battleorder.Add(new BattleOrder("Skill2", commandNumber));
                    Skill2CD = player.GetComponent<player>().Skill2CD;
                } else if (player.GetComponent<player>().Skill2 == 2)
                {
                    first = 5;
                    battleorder.Add(new BattleOrder("Skill2", commandNumber));
                    Skill2CD = player.GetComponent<player>().Skill2CD;
                }
               
                break;
            case 1:
                if (player.GetComponent<player>().Skill2 == 0)
                {
                    second = 3;
                    battleorder.Add(new BattleOrder("Skill2", commandNumber));
                    Skill2CD = player.GetComponent<player>().Skill2CD;

                }
                else if (player.GetComponent<player>().Skill2 == 1)
                {
                    second = 4;
                    battleorder.Add(new BattleOrder("Skill2", commandNumber));
                    Skill2CD = player.GetComponent<player>().Skill2CD;
                }
                else if (player.GetComponent<player>().Skill2 == 2)
                {
                    second = 5;
                    battleorder.Add(new BattleOrder("Skill2", commandNumber));
                    Skill2CD = player.GetComponent<player>().Skill2CD;
                }
                
                break;
            case 2:
                if (player.GetComponent<player>().Skill2 == 0)
                {
                    third = 3;
                    battleorder.Add(new BattleOrder("Skill2", commandNumber));
                    Skill2CD = player.GetComponent<player>().Skill2CD;
                }
                else if (player.GetComponent<player>().Skill2 == 1)
                {
                    third = 4;
                    battleorder.Add(new BattleOrder("Skill2", commandNumber));
                    Skill2CD = player.GetComponent<player>().Skill2CD;
                }
                else if (player.GetComponent<player>().Skill2 == 2)
                {
                    third = 5;
                    battleorder.Add(new BattleOrder("Skill2", commandNumber));
                    Skill2CD = player.GetComponent<player>().Skill2CD;
                }
                Skill2CD = player.GetComponent<player>().Skill2CD;
                break;
        }
        cmndPlus();
//        Debug.Log(first);
//        Debug.Log(second);
//        Debug.Log(third);
        }
        else return;
    }
    public void Special()
    {
       
       
       if (!player.GetComponent<player>().commandOk) return;
		if (specialUsed)
			return;
       
        if (player.GetComponent<player>().Hp > player.GetComponent<player>().specialHpRequirement) return;
        // atkType 0 attack 1 guard 2 buff
        if (player.GetComponent<player>().turnState == attackturn.WAIT || player.GetComponent<player>().turnState == attackturn.NEXT)
        {
            if (commandNumber > 2) return;
        // commandBoard.transform.GetChild(3).GetComponent<Image>().enabled = true;
        switch (commandNumber)
        {
            case 0:

                specialUsed = true;
                first = 6;
                battleorder.Add(new BattleOrder("Special", commandNumber));

                break;
            case 1:
                specialUsed = true;
                second = 6;
                battleorder.Add(new BattleOrder("Special", commandNumber));
             
                break;
            case 2:
                third = 6;
                battleorder.Add(new BattleOrder("Special", commandNumber));
                specialUsed = true;
                break;
        }
        cmndPlus();
//        Debug.Log(first);
//        Debug.Log(second);
//        Debug.Log(third);
        }
        else return;

    }

    // Use this for initialization
    void Start () {
        commandNumber = 0 ;
        battleStart = false;
        Skill1CD = 0;
        Skill2CD = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<player>().playerNumber == 2 || player.GetComponent<player>().playerNumber == 4)
        {
           enemy = battleScript.GetComponent<BattleScript>().player1sprite;
            player = battleScript.GetComponent<BattleScript>().player2sprite;
        }
        else {
            player = battleScript.GetComponent<BattleScript>().player1sprite;
            enemy = battleScript.GetComponent<BattleScript>().player2sprite;
        }
		
        if(player.GetComponent<player>().buff == true)
        {
            buff.SetActive(true);
        }else
        {
            buff.SetActive(false);
        }
    
        //player done inputting
        if (commandNumber== 3)
        {
            commandNumber = 4;
            reset = false;
            // end command phase
            //commandNumber = 0;
            battleStart = true;
           
            //commandBoard.transform.GetChild(3).gameObject.GetComponent<Image>().enabled = true;
            battleSaved = new List<BattleOrder>(battleorder);
           // Debug.Log(battleorder.Count);
            battleorder.Clear();
            //Debug.Log(battleSaved.Count);
            

        }
        //battle animation over all reset
        if (battleScript.GetComponent<BattleScript>().battle == true && battleStart == true)
        {
            allreset();
        }
        
		
	}

    void allreset()
    {
        //commandBoard.transform.GetChild(0).gameObject.SetActive(false);
        //commandBoard.transform.GetChild(1).gameObject.SetActive(false);
        //commandBoard.transform.GetChild(2).gameObject.SetActive(false);
        commandBoard.transform.GetChild(0).GetComponent<Image>().enabled = false;
        commandBoard.transform.GetChild(1).GetComponent<Image>().enabled = false;
        commandBoard.transform.GetChild(2).GetComponent<Image>().enabled = false;
        commandNumber = 0;
        //reset = true;
        battleStart = false;
    }
}
