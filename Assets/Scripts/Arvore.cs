using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour {

	public int curHits = 0;
	public Sprite[] allSprites;

	public void TakeDamage(){
		curHits++;
		GetComponent<SpriteRenderer> ().sprite = allSprites [curHits];
		if (curHits == 7) {
			PlayerController.Instance.GiveItem (2);
			Destroy (gameObject);
		}
	}
}
