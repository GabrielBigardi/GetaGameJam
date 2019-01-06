using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager Instance;

	public int slotsAmount = 8;

	public Sprite[] items = new Sprite[4];
	public Image[] slot = new Image[8];
	public Text[] amountText = new Text[8];
	public bool[] slotOccupied = new bool[8];

	public int[] slotItem = new int[8];
	public int[] slotAmount = new int[8];

	public GameObject hud1;
	public GameObject hud2;



	//public GameObject[] selectPanel;

	void Start(){
		if(Instance == null)
		{
			Instance = this;
		}
		else if(Instance != this)
		{
			Destroy(gameObject);
		}

		for (int i = 0; i < amountText.Length; i++) {
			amountText [i].enabled = false;
		}
	}


	public void AddItem(int slotId, int itemId){
		slot [slotId].color = Color.white;
		slot[slotId].sprite = items[itemId];
		slotOccupied [slotId] = true;

		slotItem [slotId] = itemId;
		slotAmount [slotId]++;
		RefreshAmount ();

	}

	//public void RefreshAmount(){
	//	amountText [0].text = "x" + slotOneAmount.ToString ();
	//	amountText [1].text = "x" + slotTwoAmount.ToString ();
	//	amountText [2].text = "x" + slotThreeAmount.ToString ();
	//	amountText [3].text = "x" + slotFourAmount.ToString ();
	//
	//	if (slotOneAmount > 1) {
	//		amountText [0].enabled = true;
	//	}
	//	if (slotTwoAmount > 1) {
	//		amountText [1].enabled = true;
	//	}
	//	if (slotThreeAmount > 1) {
	//		amountText [2].enabled = true;
	//	}
	//	if (slotFourAmount > 1) {
	//		amountText [3].enabled = true;
	//	}
	//}

	public void RefreshAmount(){
		for (int i = 0; i < slotAmount.Length; i++) {
			amountText [i].text = slotAmount [i].ToString ();
			if (slotAmount [i] > 1) {
				amountText [i].enabled = true;
			} else {
				amountText [i].enabled = false;
			}
		}
	}

	public void HideInventory(){
		hud1.SetActive (false);
		hud2.SetActive (false);
	}

	public void ShowInventory(){
		hud1.SetActive (true);
		hud2.SetActive (true);
	}

	//public void HighlightItem(int slotId){
	//	if (slotId == 0) {
	//		selectPanel [0].SetActive (true);
	//		selectPanel [1].SetActive (false);
	//	} else if (slotId == 1) {
	//		selectPanel [1].SetActive (true);
	//		selectPanel [0].SetActive (false);
	//	}
	//}
}
