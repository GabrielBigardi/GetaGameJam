using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passarinho : MonoBehaviour {

	public Transform emojis;
	public Sprite[] emojiTotal;

	public float emojiTime;

	void Start(){
		StartCoroutine (Emoji ());
	}

	IEnumerator Emoji(){
		yield return new WaitForSeconds (emojiTime);
		EnableEmoji (0);
		yield return new WaitForSeconds (2f);
		HideEmoji ();
	}

	public void EnableEmoji(int emojiIndex){
		print ("asdasdsda");
		emojis.GetComponent<SpriteRenderer> ().sprite = emojiTotal [emojiIndex];
		emojis.GetComponent<SpriteRenderer> ().enabled = true;

	}

	public void HideEmoji(){
		emojis.GetComponent<SpriteRenderer> ().enabled = false;

	}
}
