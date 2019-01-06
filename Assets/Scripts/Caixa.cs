using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour {

	public enum CaixaCor { Vermelha1, Verde1, Amarela1, Azul1, Vermelha2, Verde2, Amarela2, Azul2, Vermelha3, Verde3, Amarelea3, Azul3 };
	public CaixaCor corCaixa;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Botao_Vermelho") {
			if (corCaixa == CaixaCor.Vermelha1) {
				PuzzleOneManager.Instance.botoesCorretos++;
			} else if (corCaixa == CaixaCor.Vermelha2) {
				PuzzleTwoManager.Instance.botoesCorretos++;
			}
			PuzzleOneManager.Instance.CheckBotoes ();
			PuzzleTwoManager.Instance.CheckBotoes ();
		}

		if (col.tag == "Botao_Verde") {
			if (corCaixa == CaixaCor.Verde1) {
				PuzzleOneManager.Instance.botoesCorretos++;
			}else if (corCaixa == CaixaCor.Verde2) {
				PuzzleTwoManager.Instance.botoesCorretos++;
			}
			PuzzleOneManager.Instance.CheckBotoes ();
			PuzzleTwoManager.Instance.CheckBotoes ();
		}

		if (col.tag == "Botao_Amarelo") {
			if (corCaixa == CaixaCor.Amarela1) {
				PuzzleOneManager.Instance.botoesCorretos++;
			}else if (corCaixa == CaixaCor.Amarela2) {
				PuzzleTwoManager.Instance.botoesCorretos++;
			}
			PuzzleOneManager.Instance.CheckBotoes ();
			PuzzleTwoManager.Instance.CheckBotoes ();
		}

		if (col.tag == "Botao_Azul") {
			if (corCaixa == CaixaCor.Azul1) {
				PuzzleOneManager.Instance.botoesCorretos++;
			}else if (corCaixa == CaixaCor.Azul2) {
				PuzzleTwoManager.Instance.botoesCorretos++;
			}
			PuzzleOneManager.Instance.CheckBotoes ();
			PuzzleTwoManager.Instance.CheckBotoes ();
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Botao_Vermelho") {
			if (corCaixa == CaixaCor.Vermelha1) {
				PuzzleOneManager.Instance.botoesCorretos--;
			}else if (corCaixa == CaixaCor.Vermelha2) {
				PuzzleTwoManager.Instance.botoesCorretos--;
			}
			PuzzleOneManager.Instance.CheckBotoes ();
			PuzzleTwoManager.Instance.CheckBotoes ();
		}

		if (col.tag == "Botao_Verde") {
			if (corCaixa == CaixaCor.Verde1) {
				PuzzleOneManager.Instance.botoesCorretos--;
			}else if (corCaixa == CaixaCor.Verde2) {
				PuzzleTwoManager.Instance.botoesCorretos--;
			}
			PuzzleOneManager.Instance.CheckBotoes ();
			PuzzleTwoManager.Instance.CheckBotoes ();
		}

		if (col.tag == "Botao_Amarelo") {
			if (corCaixa == CaixaCor.Amarela1) {
				PuzzleOneManager.Instance.botoesCorretos--;
			}else if (corCaixa == CaixaCor.Amarela2) {
				PuzzleTwoManager.Instance.botoesCorretos--;
			}
			PuzzleOneManager.Instance.CheckBotoes ();
			PuzzleTwoManager.Instance.CheckBotoes ();
		}

		if (col.tag == "Botao_Azul") {
			if (corCaixa == CaixaCor.Azul1) {
				PuzzleOneManager.Instance.botoesCorretos--;
			}else if (corCaixa == CaixaCor.Azul2) {
				PuzzleTwoManager.Instance.botoesCorretos--;
			}
			PuzzleOneManager.Instance.CheckBotoes ();
			PuzzleTwoManager.Instance.CheckBotoes ();
		}
	}
}
