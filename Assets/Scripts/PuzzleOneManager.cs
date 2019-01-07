using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOneManager : MonoBehaviour {

	public static PuzzleOneManager Instance;

	public Transform[] caixasObj;
	public Vector3[] caixasStartPos;
	public int botoesCorretos;

	public Transform portao;
	public Sprite portaoFechado;
	public Sprite portaoAberto;

	void Start(){

	if(Instance == null)
	{
		Instance = this;
	}
	else if(Instance != this)
	{
		Destroy(gameObject);
	}

		for (int i = 0; i < caixasObj.Length; i++) {
			caixasStartPos [i] = caixasObj [i].position;
		}
	}

	public void ResetBotoes(){

		print ("resetado");

		for (int i = 0; i < caixasObj.Length; i++) {
			caixasObj [i].position = caixasStartPos [i];

		}
		//botoesCorretos = 0;
	}

	public void CheckBotoes(){
		if (botoesCorretos == caixasObj.Length) {
			print ("Todos corretos, Puzzle 1 passou");
			AbrirPortao ();
		}
	}

	public void AbrirPortao(){
		portao.GetComponent<SpriteRenderer> ().sprite = portaoAberto;
		portao.GetComponent<BoxCollider2D> ().enabled = false;
	}

	public void FecharPortao(){
		portao.GetComponent<SpriteRenderer> ().sprite = portaoFechado;
		portao.GetComponent<BoxCollider2D> ().enabled = true;
	}
}
