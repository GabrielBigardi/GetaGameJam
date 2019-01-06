using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager Instance;

	public int slotsAmount = 4;

	public Sprite[] items = new Sprite[4];
	public Image[] slot = new Image[4];
	public Text[] amountText = new Text[4];
	public bool[] slotOccupied = new bool[4];

	public int slotOneItem;
	public int slotTwoItem;
	public int slotThreeItem;
	public int slotFourItem;

	public int slotOneAmount;
	public int slotTwoAmount;
	public int slotThreeAmount;
	public int slotFourAmount;

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

		switch (slotId) {
		case 0:
			if (itemId == 0) {
				slotOneItem = 0;
			} else if (itemId == 1) {
				slotOneItem = 1;
			} else if (itemId == 2) {
				slotOneItem = 2;
			} else if (itemId == 3) {
				slotOneItem = 3;
			}
			slotOneAmount++;
			RefreshAmount ();
			break;

		case 1:
			if (itemId == 0) {
				slotTwoItem = 0;
			} else if (itemId == 1) {
				slotTwoItem = 1;
			} else if (itemId == 2) {
				slotTwoItem = 2;
			} else if (itemId == 3) {
				slotTwoItem = 3;
			}
			slotTwoAmount++;
			RefreshAmount ();
			break;

		case 2:
			if (itemId == 0) {
				slotThreeItem = 0;
			} else if (itemId == 1) {
				slotThreeItem = 1;
			} else if (itemId == 2) {
				slotThreeItem = 2;
			} else if (itemId == 3) {
				slotThreeItem = 3;
			}
			slotThreeAmount++;
			RefreshAmount ();
			break;

		case 3:
			if (itemId == 0) {
				slotFourItem = 0;
			} else if (itemId == 1) {
				slotFourItem = 1;
			} else if (itemId == 2) {
				slotFourItem = 2;
			} else if (itemId == 3) {
				slotFourItem = 3;
			}
			slotFourAmount++;
			RefreshAmount ();
			break;
		}




	}

	public void RefreshAmount(){
		amountText [0].text = "x" + slotOneAmount.ToString ();
		amountText [1].text = "x" + slotTwoAmount.ToString ();
		amountText [2].text = "x" + slotThreeAmount.ToString ();
		amountText [3].text = "x" + slotFourAmount.ToString ();

		if (slotOneAmount > 1) {
			amountText [0].enabled = true;
		}
		if (slotTwoAmount > 1) {
			amountText [1].enabled = true;
		}
		if (slotThreeAmount > 1) {
			amountText [2].enabled = true;
		}
		if (slotFourAmount > 1) {
			amountText [3].enabled = true;
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
