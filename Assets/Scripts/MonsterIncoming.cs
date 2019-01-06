using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIncoming : MonoBehaviour {

	public Transform spawnPos;
	public Transform passarinhoPrefab;

	public void InstantiateMonster(){
		Instantiate (passarinhoPrefab, spawnPos.position, Quaternion.identity);
		Destroy (this.gameObject);
	}
}
