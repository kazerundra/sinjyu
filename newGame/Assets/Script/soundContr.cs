using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundContr : MonoBehaviour {
	public AudioClip aud1;
	public AudioClip aud2;
	public AudioClip aud3;
	public AudioClip aud4;
	public AudioClip aud5;
	public AudioClip aud6;
	public AudioClip aud7;
	public AudioClip aud8;
	public AudioSource audiosource;
	public void play(int nmbr){
	//	Debug.Log ("test");
		if (nmbr == 1) {
			audiosource.PlayOneShot (aud1);
		} else if (nmbr == 2) {
			audiosource.PlayOneShot (aud2);
		}else if (nmbr == 3) {
			audiosource.PlayOneShot (aud3);
		}else if (nmbr == 4) {
			audiosource.PlayOneShot (aud4);
		}else if (nmbr == 5) {
			audiosource.PlayOneShot (aud5);
		}else if (nmbr == 6) {
			audiosource.PlayOneShot (aud6);
		}else if (nmbr == 7) {
			audiosource.PlayOneShot (aud7);
		}else if (nmbr == 8) {
			audiosource.PlayOneShot (aud8);
		}
		
	}


	// Use this for initialization
	void Start () {
		
		this.audiosource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
