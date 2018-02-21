using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleScript : MonoBehaviour {
	public ParticleSystem Magic;
	public ParticleSystem Attack;
	public ParticleSystem Smoke;
	public ParticleSystem Skill1;
	public ParticleSystem Skill2;
	public ParticleSystem Finish;

	public void attackEffect(){
		Attack.Play ();
	}
	// Use this for initialization
	public void smoke(){
		Smoke.Play ();
	}
	public void magicEffect(){
		Magic.Play ();
		Smoke.Play ();

	}
	public void magic1Stop(){
		Magic.Stop ();
		Smoke.Stop ();
	}
	public void skill1(){
		Skill1.Play ();
	}
	public void skill2(){
		Skill2.Play ();
	}
	public void finish(){
		Finish.Play ();
	}


	public void stopMagic(int nmbr){
		if (nmbr == 0) {
			Attack.Stop ();
		} else if (nmbr == 1) {
			Skill1.Stop ();
		}
		else if (nmbr == 2) {
			Skill2.Stop();
		}
		else if (nmbr == 3) {
			Finish.Stop ();
		}else if (nmbr == 10) {
			Smoke.Stop ();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
