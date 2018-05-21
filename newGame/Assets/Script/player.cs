using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum attackturn { WAIT, FIRST, SECOND, THIRD, FINISH ,OVER, NEXT}

public class player : MonoBehaviour {
	
    //turn number
    public int turn = 0;

    // Basic status
    public int maxHp ;
    public int Hp ;
    public int Str;
    public int Vit;
    //summon = class
    // 0 = dragon
    // 1 = griffin
    public int Summon;
    //skill type
    // 0 = attack skill
    // 1 = guard skill
    // 2 = buff skill
    
    public int Skill1;
    public string SkillName1;
    public int SkillNmbr1;
    public int Skill1CD;
    public int Skill2;
    public string SkillName2;
    public int SkillNmbr2;
    public int SkillDuration2;
    public int Skill2CD;
    public int Finishing;
    public string FinishName1;
    public int FinishNumber;
	//game is over
	public bool gameover;
	//player is dead
	public bool isDead;
    int damage;
	//player map character
	public GameObject pawn;
    public GameObject battleControl;
    public GameObject control;
    public GameObject enemy;
	public GameObject gameController;
    public Text damageText;
    public Animator anim;
    public Slider hpslider;
    //determine who bottom player who top player
    public int playerNumber;
    player enemyStat;
    public float animationTimer;
	public GameObject particleEffect;
   // if enemy no previos tile
	public bool battleStart;
	public bool enemyBack;
    public bool commandOk;
	public bool buff;
	public bool debuff;
	public int buffN1;
	public int buffN2;
    //reference



    private Control Control;
    // buff duration
    public int buffDuration;
    //buff atkUp
    public bool atkUP;
    public bool atkplus;
	//total damage this turn
	public int totalDamage;

    //maxhp50%
    public int specialHpRequirement;
	//for deadanimation end game
	float deadtime;
    //how many time still can heal;
    public GameObject battleStartlogo;
	public GameObject audioController;
    //fixlist graveyard, battle animstop,


    //change enemy gameobject to which he battle
    public void changeEnemy(int number)
    {
      
        if(number == 1)
        {
            enemy = GameObject.Find("Player");
            
        }
        else if (number == 2)
        {
            enemy = GameObject.Find("Player2");
           
        }
        else if (number == 3)
        {
            enemy = GameObject.Find("Player3");
          
        }
        else if (number == 4)
        {
            enemy = GameObject.Find("Player4");
          
        }
       
    }

    public void changePhase(attackturn turn)
    {
        turnState = turn;
    }
	public void playSfx(int nbr){
		audioController.GetComponent<soundContr>().play(nbr);
	}
    void Start () {
		buffN1 = Str;
		

        enemyStat = enemy.GetComponent<player>();
        switch (Summon)
        {
            case 0:
                maxHp = 120;
                Hp = maxHp;
                Str = 16;
                Vit = 20;
                hpslider.maxValue = maxHp;
                hpslider.value = Hp;
                Skill1 = 0;
                SkillName1 = "Dragon Claw";
                SkillNmbr1 = 15;
                Skill1CD = 3;
                Skill2 = 2;
                SkillName2 = "Dragon Roar";
                SkillNmbr2 = 10;
                SkillDuration2 = 3;
                Skill2CD = 3;
                Finishing = 0;
                FinishName1 = "Dragon Breath";
                FinishNumber = 35;
                break;
            case 1:
                maxHp = 95;
                Hp = maxHp;
                Str = 20;
                Vit = 14;
                hpslider.maxValue = maxHp;
                hpslider.value = Hp;
                Skill1 = 0;
                SkillNmbr1 = 20;
                SkillName1 = "Griffon Claw";
                Skill1CD = 3;
                Skill2 = 1;
                SkillNmbr2 = 10;
                SkillName2 = "Aerial Dodge";
                Skill2CD = 3;
                Finishing = 0;
                FinishNumber = 30;
                FinishName1 = "Tornado";
                break;
            case 2:
                maxHp = 60;
                Hp = maxHp;
                Str = 10;
                Vit = 10;
                hpslider.maxValue = maxHp;
                hpslider.value = Hp;
                Skill1 = 0;
                SkillName1 = "daek Claw";
                SkillNmbr1 = 10;
                Skill1CD = 3;
                Skill2 = 0;
                SkillName2 = "Dark Roar";
                SkillNmbr2 = 10;
                SkillDuration2 = 3;
                Skill2CD = 3;
                Finishing = 0;
                FinishName1 = "DarkSphere";
                FinishNumber = 20;
                break;
			case 3:
				maxHp = 60;
				Hp = maxHp;
                Str = 10;
                Vit = 10;
                hpslider.maxValue = maxHp;
                hpslider.value = Hp;
                Skill1 = 0;
                SkillName1 = "dark Claw";
                SkillNmbr1 = 10;
                Skill1CD = 3;
                Skill2 = 0;
                SkillName2 = "Dark Roar";
                SkillNmbr2 = 10;
                SkillDuration2 = 3;
                Skill2CD = 3;
                Finishing = 0;
                FinishName1 = "DarkSphere";
                FinishNumber = 20;
                break;
        }

        anim = GetComponent<Animator>();
        
    }
    int random(int rng, int rng1)
    {
        int rndm;
        rndm = Random.Range(rng, rng1);        
        return rndm;
        
    }
    int griffonClaw()
    {
        damage = (SkillNmbr1+ Str) - (enemyStat.Vit / 2) + random(2, 6);
        //Hp = Hp - damage;
        //damageText.text = damage.ToString();
       // Debug.Log("griffonclaw");
        return damage;
    }
    void dragonRoar()
    {
        atkUP = true;
        buffDuration = SkillDuration2;
        //Debug.Log("dragonroar");
    }
   
    void aerialDodge()
    {

    }
  
    int dragonClaw()
    {
        damage = (SkillNmbr1 + Str) - (enemyStat.Vit / 2) + random(2, 6);
        //Hp = Hp - damage;
        //damageText.text = damage.ToString();
       // Debug.Log("dragonclaw");
        return damage;
    }
	int darkClaw()
	{
		damage = (SkillNmbr1 + Str) - (enemyStat.Vit / 2);
		//Hp = Hp - damage;
		//damageText.text = damage.ToString();
		// Debug.Log("dragonclaw");
		return damage;
	}
	int barkClaw()
	{
		damage = (SkillNmbr2 + Str) - (enemyStat.Vit / 2);
		//Hp = Hp - damage;
		//damageText.text = damage.ToString();
		// Debug.Log("dragonclaw");
		return damage;
	}
    public int normalDamage()
    {
        int dmg;
        //dmg = Str - (enemyStat.Vit / 2) + random(1, 4);
        dmg = enemyStat.Str - (Vit / 2) + random(1, 4);
        return dmg;
        
    }
    public void takeDmg(int dmg)
    {
        Hp = Hp - dmg;
        damageText.text = dmg.ToString();
        hpslider.value = Hp;
		totalDamage += dmg;
    }

	public void heal (){
		Hp = maxHp;
		hpslider.value = Hp;
	}

	int dragonBreath(){
		damage = (FinishNumber + Str) - (enemyStat.Vit / 2) + random(2, 6);

		return damage;
	}
	int tornado(){
		damage = (FinishNumber + Str) - (enemyStat.Vit / 2) + random(1, 10);

		return damage;
	}
	int darksphere(){
		damage = (FinishNumber + Str) - (enemyStat.Vit / 2) + random(2, 6);

		return damage;
	}
    

   //firstSkill
    public void skillAct(int dmgRdc)
    {
		int dmg;
        switch (Summon)
        {
            case 0:              
                dmg= dragonClaw() - dmgRdc;
                enemy.GetComponent<player>().takeDmg(dmg);
                Debug.Log(SkillName1);
              
                
                break;
            case 1:
                dmg= griffonClaw() - dmgRdc;
                enemy.GetComponent<player>().takeDmg(dmg);
                Debug.Log(SkillName1);
                //Debug.Log("gc");
                break;
		case 2:
			dmg = barkClaw();
			enemy.GetComponent<player>().takeDmg(dmg);
			break;
		case 3:
			dmg = barkClaw();
			enemy.GetComponent<player>().takeDmg(dmg);
			break;
                
        }
        hpslider.value = Hp;
    }
    //2ndskill
    public void skill2Act()
	{int dmg;
        switch (Summon)
        {
            case 0:
                dragonRoar();
                break;
            case 1:
                aerialDodge();
                break;
            case 2:
                dmg = barkClaw();
			enemy.GetComponent<player>().takeDmg(dmg);
                break;
            case 3:
                dmg = barkClaw();
			enemy.GetComponent<player>().takeDmg(dmg);
                break;

        }
       
    }
	public void finishAct(int reduce)
	{int dmg;
		switch (Summon)
		{
		case 0:
			dmg =dragonBreath()-reduce;
			enemy.GetComponent<player>().takeDmg(dmg);
			break;
		case 1:
			dmg =tornado()-reduce;
			enemy.GetComponent<player>().takeDmg(dmg);
			break;
            case 2:
			dmg =darksphere()-reduce;
			enemy.GetComponent<player>().takeDmg(dmg);
                break;
            case 3:
			dmg =darksphere()-reduce;
			enemy.GetComponent<player>().takeDmg(dmg);
                break;

        }

	}

    //3 2onlyActivated 4 1onlyActivated 5 BothActivated 6 Nothing 

    //lanjutin sini bikin damage guard harus gk kena damage
    // skill damage dari siapa ke siapa perbaiki
    
    void battle (int number)
    {
        Control = control.GetComponent<Control>();
        int first = battleControl.GetComponent<BattleScript>().first;
        int second = battleControl.GetComponent<BattleScript>().second;
        int third = battleControl.GetComponent<BattleScript>().third;
        if (number == 1)
        {
            if (first == 0)
            {
                takeDmg(normalDamage());

            }
            else if (first == 1)
            {
				if (playerNumber == 2||playerNumber == 4) takeDmg(normalDamage());
                else damageText.text = "0";
            }
            else if (first == 2)
            {
				if (playerNumber == 1||playerNumber == 3) takeDmg(normalDamage());
                else damageText.text = "0";
            }
            else if (first == 3)
            {
				Debug.Log (Control.battleSaved [0].name);

               if (playerNumber == 2 || playerNumber == 4)
               {
                    if (Control.battleSaved[0].name == "Skill1")
                    {
                        skillAct(0);

                    }
                    else if (Control.battleSaved[0].name == "Skill2")
                    {
                        skill2Act();
					}  else if (Control.battleSaved[0].name == "Special")
					{
						finishAct(0);
					}

                }
            }
            else if (first == 4)
            {

                if (playerNumber == 1 || playerNumber == 3)
                {
                    if (Control.battleSaved[0].name == "Skill1")
                    {
                        skillAct(0);
                    }
                    else if (Control.battleSaved[0].name == "Skill2")
                    {
                        skill2Act();
					}else if (Control.battleSaved[0].name == "Special")
					{
						finishAct(0);
					}

                }

            }
            else if (first == 5)
            {
                if (Control.battleSaved[0].name == "Skill1")
                {
                    skillAct(0);
                }
                else if (Control.battleSaved[0].name == "Skill2")
                {
                    skill2Act();
                }
                else if (Control.battleSaved[0].name == "Attack" || Control.battleSaved[0].name == "Magic")
                {
                    enemy.GetComponent<player>().takeDmg(enemy.GetComponent<player>().normalDamage());
				}else if (Control.battleSaved[0].name == "Special")
				{
					finishAct(0);
				}
                else { damageText.text = "0"; enemy.GetComponent<player>().damageText.text = "0"; }

            }
            else if (first == 7)
			{ int rdc;
				if (playerNumber == 1 || playerNumber == 3) {rdc= enemy.GetComponent<player>().Vit;
					if (Control.battleSaved[0].name == "Skill1")
					{
						skillAct(rdc);
					}
					else if (Control.battleSaved[0].name == "Skill2")
					{
						skill2Act();
					}
					else if (Control.battleSaved[0].name == "Special")
					{
						finishAct(rdc);
					}
				}
            }

            else if (first == 8)
			{int rdc;
				if (playerNumber == 2 || playerNumber == 4) {rdc = enemy.GetComponent<player>().Vit;
					if (Control.battleSaved[0].name == "Skill1")
					{
						skillAct(rdc);
					}
					else if (Control.battleSaved[0].name == "Skill2")
					{
						skill2Act();
					}
					else if (Control.battleSaved[0].name == "Special")
					{
						finishAct(rdc);
					}
				}
            }
            else
            {
                damageText.text = "0";
            }

        }
        else if (number == 2)
        {
            if (second == 0)
            {
                takeDmg(normalDamage());

            }
            else if (second == 1)
            {
				if (playerNumber == 2||playerNumber == 4) takeDmg(normalDamage());
                else damageText.text = "0";
            }
            else if (second == 2)
            {
				if (playerNumber == 1||playerNumber == 3) takeDmg(normalDamage());
                else damageText.text = "0";
            }
            else if (second == 3)
            {

                if (playerNumber == 2|| playerNumber == 4)
                {
					if (Control.battleSaved[1].name == "Skill1")
					{
						skillAct(0);
					}
					else if (Control.battleSaved[1].name == "Skill2")
					{
						skill2Act();
					}  else if (Control.battleSaved[1].name == "Special")
					{
						finishAct(0);
					}
                }

            }
            else if (second == 4)
            {

                if (playerNumber == 1|| playerNumber == 3)
                {
					if (Control.battleSaved[1].name == "Skill1")
					{
						skillAct(0);
					}
					else if (Control.battleSaved[1].name == "Skill2")
					{
						skill2Act();
					}  else if (Control.battleSaved[1].name == "Special")
					{
						finishAct(0);
					}

                }

            }
            else if (second == 5)
            {
                if (Control.battleSaved[1].name == "Skill1")
                {
                    skillAct(0);
                }
                else if (Control.battleSaved[1].name == "Skill2")
                {
                    skill2Act();
                }
                else if (Control.battleSaved[1].name == "Attack" || Control.battleSaved[1].name == "Magic")
                {
                    enemy.GetComponent<player>().takeDmg(enemy.GetComponent<player>().normalDamage());
				}else if (Control.battleSaved[1].name == "Special")
				{
					finishAct(0);
				}
                else { damageText.text = "0"; enemy.GetComponent<player>().damageText.text = "0"; }

            }
            else if (second == 7)
            {
				int rdc;
				if (playerNumber == 3 || playerNumber == 3) {rdc = enemy.GetComponent<player>().Vit;
					if (Control.battleSaved[1].name == "Skill1")
					{
						skillAct(rdc);
					}
					else if (Control.battleSaved[1].name == "Skill2")
					{
						skill2Act();
					}
					else if (Control.battleSaved[1].name == "Special")
					{
						finishAct(rdc);
					}
				}
            }

            else if (second == 8)
            {
				int rdc;
				if (playerNumber == 2 || playerNumber == 4) {rdc = enemy.GetComponent<player>().Vit;
					if (Control.battleSaved[1].name == "Skill1")
					{
						skillAct(rdc);
					}
					else if (Control.battleSaved[1].name == "Skill2")
					{
						skill2Act();
					}
					else if (Control.battleSaved[1].name == "Special")
					{
						finishAct(0);
					}
				}
            }
            else
            {
                damageText.text = "0";
            }

        }
        else if (number == 3)
        {
            if (third == 0)
            {
                takeDmg(normalDamage());

            }
            else if (third == 1)
            {
				if (playerNumber == 2|| playerNumber == 4) takeDmg(normalDamage());
                else damageText.text = "0";
            }
            else if (third == 2)
            {
				if (playerNumber == 1|| playerNumber == 3) takeDmg(normalDamage());
                else damageText.text = "0";
            }
            else if (third == 3)
            {

				if (playerNumber == 2||playerNumber == 4)
                {
					if (Control.battleSaved[2].name == "Skill1")
					{
						skillAct(0);
					}
					else if (Control.battleSaved[2].name == "Skill2")
					{
						skill2Act();
					}  else if (Control.battleSaved[2].name == "Special")
					{
						finishAct(0);
					}

                }

            }
            else if (third == 4)
            {

				if (playerNumber == 1||playerNumber == 3)
                {
					if (Control.battleSaved[2].name == "Skill1")
					{
						skillAct(0);
					}
					else if (Control.battleSaved[2].name == "Skill2")
					{
						skill2Act();
					}  else if (Control.battleSaved[2].name == "Special")
					{
						finishAct(0);
					}


                }

            }
            else if (third == 5)
            {
                if (Control.battleSaved[2].name == "Skill1")
                {
                    skillAct(0);
                }
                else if (Control.battleSaved[2].name == "Skill2")
                {
                    skill2Act();
                }
                else if (Control.battleSaved[2].name == "Attack" || Control.battleSaved[2].name == "Magic")
                {
                    enemy.GetComponent<player>().takeDmg(enemy.GetComponent<player>().normalDamage());
				}else if (Control.battleSaved[2].name == "Special")
				{
					finishAct(0);
				}
                else { damageText.text = "0"; enemy.GetComponent<player>().damageText.text = "0"; }

            }
            else if (third == 7)
            {
				int rdc;
				if (playerNumber == 1 || playerNumber == 3) {rdc = enemy.GetComponent<player>().Vit;
					if (Control.battleSaved[2].name == "Skill1")
					{
						skillAct(rdc);
					}
					else if (Control.battleSaved[2].name == "Skill2")
					{
						skill2Act();
					}
					else if (Control.battleSaved[2].name == "Special")
					{
						finishAct(rdc);
					}
				}
            }

            else if (third == 8)
            {
				int rdc;
				if (playerNumber == 2 || playerNumber == 4) {rdc = enemy.GetComponent<player>().Vit;
					if (Control.battleSaved[2].name == "Skill1")
					{
						skillAct(rdc);
					}
					else if (Control.battleSaved[2].name == "Skill2")
					{
						skill2Act();
					}
					else if (Control.battleSaved[2].name == "Special")
					{
						finishAct(rdc);
					}
				}
            }
            else
            {
                damageText.text = "0";
            }

        }

        }



    public attackturn turnState = attackturn.WAIT;
    public float waitTime = 4.0f;
	public int animOver =0;
	public void animStart(){
		animOver = 0;
	}
	public void animOvr(){
		animOver = 1;
	}

   
    //update 直す
    public IEnumerator battleAnimation()

    {
       // Debug.Log(turnState);
		//Debug.Log(isDead);
        damageText.gameObject.SetActive(true);
        Control = control.GetComponent<Control>();
        int turnNmbr;
		if (turnState == attackturn.FIRST)
        {
			
            turnNmbr = 1;
            if (Control.first == 0)
            {
                anim.SetTrigger("Attack");
                Control.commandTextShow(turnNmbr);
                ////yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
                yield return new WaitForSeconds(waitTime);
                battle(1);
                anim.SetTrigger("Transition");

            }
            else if (Control.first == 1)
            {
                anim.SetTrigger("Guard");
                Control.commandTextShow(turnNmbr);
                ////yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
                yield return new WaitForSeconds(waitTime);
                battle(1);
				anim.SetTrigger("Transition");

            } else if (Control.first == 2)
            {
                anim.SetTrigger("Break");
                Control.commandTextShow(turnNmbr);
                ////yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
                yield return new WaitForSecondsRealtime(waitTime);
                battle(1);
                anim.SetTrigger("Transition");
            }
            else if (Control.first == 3)
            {
                anim.SetTrigger("skill");
                Control.commandTextShow(turnNmbr);
                //yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
                yield return new WaitForSecondsRealtime(waitTime);
                battle(1);
               
                anim.SetTrigger("Transition");
            }
            else if (Control.first == 4 || Control.first == 5)
            {
                anim.SetTrigger("skill2");
                Control.commandTextShow(turnNmbr);
                //yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
                yield return new WaitForSecondsRealtime(waitTime);
                battle(1);
               
                anim.SetTrigger("Transition");
            }
            else if (Control.first == 6)
            {
                anim.SetTrigger("finish");
                Control.commandTextShow(turnNmbr);
                //yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
                yield return new WaitForSecondsRealtime(waitTime);
                battle(1);
                
                anim.SetTrigger("Transition");
            }
			turnState = attackturn.SECOND;
            ////yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
			while (battleControl.GetComponent<BattleScript>().turnstate != attackturn.SECOND)
				yield return new WaitForSecondsRealtime(waitTime);
			turnNmbr = 2;
			if (Control.second == 0)
			{
				anim.SetTrigger("Attack");
				Control.commandTextShow(turnNmbr);
				////yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				battle(2);
				anim.SetTrigger("Transition");

			}
			else if (Control.second == 1)
			{
				anim.SetTrigger("Guard");
				Control.commandTextShow(turnNmbr);
				////yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(2);
				anim.SetTrigger("Transition");

			}
			else if (Control.second == 2)
			{
				anim.SetTrigger("Break");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(2);
				anim.SetTrigger("Transition");
			}
			else if (Control.second == 3)
			{
				anim.SetTrigger("skill");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(2);                
				anim.SetTrigger("Transition");
			}
			else if (Control.second == 4 || Control.second == 5)
			{
				anim.SetTrigger("skill2");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(2);                
				anim.SetTrigger("Transition");
			}
			else if (Control.second == 6)
			{
				anim.SetTrigger("finish");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(2);                
				anim.SetTrigger("Transition");
			}
			turnState = attackturn.THIRD;
			while (battleControl.GetComponent<BattleScript>().turnstate != attackturn.THIRD)
				yield return new WaitForSecondsRealtime(waitTime);
			turnNmbr = 3;
			if (Control.third == 0)
			{
				anim.SetTrigger("Attack");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(3);
				turn += 1;
				anim.SetTrigger("Transition");

			}
			else if (Control.third == 1)
			{
				anim.SetTrigger("Guard");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(3);
				turn += 1;
				anim.SetTrigger("Transition");
			}
			else if (Control.third == 2)
			{
				anim.SetTrigger("Break");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(3);
				turn += 1;
				anim.SetTrigger("Transition");
			}
			else if(Control.third == 3)
			{
				anim.SetTrigger("skill");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(3);
				turn += 1;
				anim.SetTrigger("Transition");
			}
			else if (Control.third == 4 || Control.third == 5)
			{
				anim.SetTrigger("skill2");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(3);
				turn += 1;
				anim.SetTrigger("Transition");
			}
			else if (Control.third == 6)
			{
				anim.SetTrigger("finish");
				Control.commandTextShow(turnNmbr);
				//yield return new WaitUntil (() => animOver == 1); animOver = 0 ;
				yield return new WaitForSecondsRealtime(waitTime);
				battle(3);
				turn += 1;
				anim.SetTrigger("Transition");
			}
			anim.SetTrigger("Over");
			battleStartlogo.gameObject.SetActive(false);

			turnState = attackturn.FINISH;
			while (battleControl.GetComponent<BattleScript>().turnstate != attackturn.FINISH)
				yield return new WaitForSecondsRealtime(waitTime);
			if (turn > 1) {
				if (buffDuration > 0) {
					buffDuration -= 1;
				} else {
					buffDuration = 0;
					atkUP = false;
				}

				yield return new WaitForSecondsRealtime (3.0F);
				turnState = attackturn.OVER;
				turn = 0;
			} else if (turn == 1) {
				if (buffDuration > 0) {
					buffDuration -= 1;
				} else {
					buffDuration = 0;
					atkUP = false;
				}             
				turnState = attackturn.NEXT;
			}          
		} 
		if (isDead || enemy.GetComponent<player> ().isDead == true) {
			if (buffDuration > 0) {
				buffDuration -= 1;
			} else {
				buffDuration = 0;
			}           
		} 
	

    }
	public void smokeA(){
		particleEffect.GetComponent<ParticleScript> ().smoke ();
	}
	public void magicA(){
		particleEffect.GetComponent<ParticleScript> ().magicEffect ();
	}
	public void skill1A(){
		particleEffect.GetComponent<ParticleScript> ().skill1 ();
	}
	public void skill2A(){
		particleEffect.GetComponent<ParticleScript> ().skill2 ();
	}
	public void stopA(){
		particleEffect.GetComponent<ParticleScript> ().magic1Stop ();
	}
	public void finishA(){
		particleEffect.GetComponent<ParticleScript> ().finish ();
	}
	public void stopB(int nmb){
		particleEffect.GetComponent<ParticleScript> ().stopMagic (nmb);
	}
	public void attack1(){
		particleEffect.GetComponent<ParticleScript> ().attackEffect ();
	}



	
	// Update is called once per frame
	void Update () {
		if (atkUP) {
			atkUP = false;
			buffN1 = Str;
			buffN2 = buffN1 + SkillNmbr2;
			Str = buffN2;
			}

		if (buffDuration > 0) {
			buff = true;
		} else {
			buff = false;
			Str = buffN1;
		}
	
		if (gameover == true) {
			if(playerNumber == 3)
			SceneManager.LoadScene("GameOver");
			else if(playerNumber == 4)
				SceneManager.LoadScene("GameOver1");
			
		}

		if (playerNumber == 1 || playerNumber == 2) {
			if (battleControl.GetComponent<BattleChanger> ().player1 == 2) {
				changeEnemy (2);
			} else if (battleControl.GetComponent<BattleChanger> ().player1 == 4) {
				changeEnemy (4);
			}
		}
		
		if (playerNumber == 3 || playerNumber == 4) {
			if (battleControl.GetComponent<BattleChanger> ().player1 == 1) {
				changeEnemy (1);
			} else if (battleControl.GetComponent<BattleChanger> ().player1 == 3) {
				changeEnemy (3);
			}
			if (Hp <= 0) {
				
				anim.SetTrigger ("Dead");
				deadtime += Time.deltaTime;
				if (deadtime >= 10) {
					gameover = true;
				}

			}
		}
		if (Hp <=0) {
			isDead =true;
			
		}
		//Debug.Log (totalDamage);

        specialHpRequirement = maxHp /2;
		if (turnState == attackturn.OVER && enemy.GetComponent<player>().turnState == attackturn.OVER) {
			if (this.totalDamage > enemy.GetComponent<player> ().totalDamage) {
				Debug.Log (playerNumber + "player");
				pawn.GetComponent<MovementScript> ().backToPrevios ();
//				if (pawn.GetComponent<MovementScript> ().previosPanel == pawn.GetComponent<MovementScript> ().panelPosition) {
//					enemy.GetComponent<player> ().pawn.GetComponent<MovementScript> ().backToPrevios ();
//				} else {
//					pawn.GetComponent<MovementScript> ().backToPrevios ();
//
//				}
			

			} else if (this.totalDamage < enemy.GetComponent<player> ().totalDamage) {
				Debug.Log (playerNumber + "enemy");
				enemy.GetComponent<player> ().pawn.GetComponent<MovementScript> ().backToPrevios ();
			} else if (this.totalDamage ==enemy.GetComponent<player> ().totalDamage){
				enemy.GetComponent<player> ().pawn.GetComponent<MovementScript> ().backToPrevios ();
				pawn.GetComponent<MovementScript> ().backToPrevios ();

			} 
			totalDamage = 0;
			enemy.GetComponent<player> ().totalDamage = 0;
		} 
        if(buffDuration > 0)
        {
            if (atkUP == true)
            {
                if (!atkplus)
                {
                    Str += SkillNmbr2;
                    atkplus = true;
                }
               
              
            }
        } else if (buffDuration ==  0 )
        {
            if(atkUP == true)
            Str -= SkillNmbr2;
            atkplus = false;
            atkUP = false;
        }
      
        
        if (battleControl.GetComponent<BattleScript>().battlePhaseOver == true)
        {
            turnState = attackturn.WAIT;
        }
      
        if(turnState == attackturn.WAIT || turnState == attackturn.NEXT)
        {
            commandOk = true;
		}
        else { commandOk = false; }
		if (playerNumber == battleControl.GetComponent<BattleScript> ().playernumber1 || playerNumber == battleControl.GetComponent<BattleScript> ().playernumber2) {
			if (battleControl.GetComponent<BattleScript> ().battle == true) {
				if (turnState == attackturn.WAIT) {
					battleControl.GetComponent<BattleScript> ().battle = false;
					turnState = attackturn.FIRST;
					battleStart = true;
					StartCoroutine (battleAnimation ());
                    
				}

			}
		}
        
        }
}
