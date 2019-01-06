using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static PlayerController Instance;

	[Header("Movement")]
	Vector2 mov;
	public float speed;
	Rigidbody2D rgbd;
	Animator anim;

	[Header("Directions")]
	public Directions curDir;
	public enum Directions { Up, Down, Right, Left }

	public bool disabled;

	public Transform emojis;
	public Sprite[] emojiTotal;

	public Transform monsterIncomingPrefab;

	void Start()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else if(Instance != this)
		{
			Destroy(gameObject);
		}
			
		rgbd = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		curDir = Directions.Down;
		anim.SetFloat ("MovY", -1.0f);

		disabled = true;

		StartCoroutine (test_Cutscene ());

	}

	void Update(){

		if (disabled)
			return;

		mov = new Vector2(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical")
		);



		if(mov != Vector2.zero)
		{
			anim.SetFloat("MovX", mov.x);
			anim.SetFloat("MovY", mov.y);
			anim.SetBool("Walk", true);


			if (mov.y > 0)
			{
				curDir = Directions.Up;
			}
			else if (mov.y < 0)
			{
				curDir = Directions.Down;
			}
			else if (mov.x > 0)
			{
				curDir = Directions.Right;
			}
			else if (mov.x < 0)
			{
				curDir = Directions.Left;
			}

		}
		else
		{
			anim.SetBool("Walk", false);
		}


		if (Input.GetKeyDown (KeyCode.Z)) {

			int itemId = 0;

			if (!InventoryManager.Instance.slotOccupied [0])
				InventoryManager.Instance.AddItem (0, itemId);
			else if(InventoryManager.Instance.slotOccupied [0]) {
				if (InventoryManager.Instance.slotOneItem == itemId) {
					InventoryManager.Instance.AddItem (0, itemId);
				} else {
					if (!InventoryManager.Instance.slotOccupied [1]) {
						InventoryManager.Instance.AddItem (1, itemId);
					} else if (InventoryManager.Instance.slotOccupied [1]) {
						if (InventoryManager.Instance.slotTwoItem == itemId) {
							InventoryManager.Instance.AddItem (1, itemId);
						} else {
							if (!InventoryManager.Instance.slotOccupied [2]) {
								InventoryManager.Instance.AddItem (2, itemId);
							}else if(InventoryManager.Instance.slotOccupied [2]){
								if (InventoryManager.Instance.slotThreeItem == itemId) {
									InventoryManager.Instance.AddItem (2, itemId);
								} else {
									if (!InventoryManager.Instance.slotOccupied [3]) {
										InventoryManager.Instance.AddItem (3, itemId);
									} else if (InventoryManager.Instance.slotOccupied [3]) {
										if (InventoryManager.Instance.slotFourItem == itemId) {
											InventoryManager.Instance.AddItem (3, itemId);
										} else {
											return;
										}
									}
								}
							}
						}
					}
				}
			}
				
			
		}

		if (Input.GetKeyDown (KeyCode.X)) {

			int itemId = 1;

			if (!InventoryManager.Instance.slotOccupied [0])
				InventoryManager.Instance.AddItem (0, itemId);
			else if(InventoryManager.Instance.slotOccupied [0]) {
				if (InventoryManager.Instance.slotOneItem == itemId) {
					InventoryManager.Instance.AddItem (0, itemId);
				} else {
					if (!InventoryManager.Instance.slotOccupied [1]) {
						InventoryManager.Instance.AddItem (1, itemId);
					} else if (InventoryManager.Instance.slotOccupied [1]) {
						if (InventoryManager.Instance.slotTwoItem == itemId) {
							InventoryManager.Instance.AddItem (1, itemId);
						} else {
							if (!InventoryManager.Instance.slotOccupied [2]) {
								InventoryManager.Instance.AddItem (2, itemId);
							}else if(InventoryManager.Instance.slotOccupied [2]){
								if (InventoryManager.Instance.slotThreeItem == itemId) {
									InventoryManager.Instance.AddItem (2, itemId);
								} else {
									if (!InventoryManager.Instance.slotOccupied [3]) {
										InventoryManager.Instance.AddItem (3, itemId);
									} else if (InventoryManager.Instance.slotOccupied [3]) {
										if (InventoryManager.Instance.slotFourItem == itemId) {
											InventoryManager.Instance.AddItem (3, itemId);
										} else {
											return;
										}
									}
								}
							}
						}
					}
				}
			}


		}

		if (Input.GetKeyDown (KeyCode.C)) {

			int itemId = 2;

			if (!InventoryManager.Instance.slotOccupied [0])
				InventoryManager.Instance.AddItem (0, itemId);
			else if(InventoryManager.Instance.slotOccupied [0]) {
				if (InventoryManager.Instance.slotOneItem == itemId) {
					InventoryManager.Instance.AddItem (0, itemId);
				} else {
					if (!InventoryManager.Instance.slotOccupied [1]) {
						InventoryManager.Instance.AddItem (1, itemId);
					} else if (InventoryManager.Instance.slotOccupied [1]) {
						if (InventoryManager.Instance.slotTwoItem == itemId) {
							InventoryManager.Instance.AddItem (1, itemId);
						} else {
							if (!InventoryManager.Instance.slotOccupied [2]) {
								InventoryManager.Instance.AddItem (2, itemId);
							}else if(InventoryManager.Instance.slotOccupied [2]){
								if (InventoryManager.Instance.slotThreeItem == itemId) {
									InventoryManager.Instance.AddItem (2, itemId);
								} else {
									if (!InventoryManager.Instance.slotOccupied [3]) {
										InventoryManager.Instance.AddItem (3, itemId);
									} else if (InventoryManager.Instance.slotOccupied [3]) {
										if (InventoryManager.Instance.slotFourItem == itemId) {
											InventoryManager.Instance.AddItem (3, itemId);
										} else {
											return;
										}
									}
								}
							}
						}
					}
				}
			}


		}

		if (Input.GetKeyDown (KeyCode.V)) {

			int itemId = 3;

			if (!InventoryManager.Instance.slotOccupied [0])
				InventoryManager.Instance.AddItem (0, itemId);
			else if(InventoryManager.Instance.slotOccupied [0]) {
				if (InventoryManager.Instance.slotOneItem == itemId) {
					InventoryManager.Instance.AddItem (0, itemId);
				} else {
					if (!InventoryManager.Instance.slotOccupied [1]) {
						InventoryManager.Instance.AddItem (1, itemId);
					} else if (InventoryManager.Instance.slotOccupied [1]) {
						if (InventoryManager.Instance.slotTwoItem == itemId) {
							InventoryManager.Instance.AddItem (1, itemId);
						} else {
							if (!InventoryManager.Instance.slotOccupied [2]) {
								InventoryManager.Instance.AddItem (2, itemId);
							}else if(InventoryManager.Instance.slotOccupied [2]){
								if (InventoryManager.Instance.slotThreeItem == itemId) {
									InventoryManager.Instance.AddItem (2, itemId);
								} else {
									if (!InventoryManager.Instance.slotOccupied [3]) {
										InventoryManager.Instance.AddItem (3, itemId);
									} else if (InventoryManager.Instance.slotOccupied [3]) {
										if (InventoryManager.Instance.slotFourItem == itemId) {
											InventoryManager.Instance.AddItem (3, itemId);
										} else {
											return;
										}
									}
								}
							}
						}
					}
				}
			}


		}

		if (Input.GetKeyDown (KeyCode.F)) {
			if(InventoryManager.Instance.hud1.activeInHierarchy)
				InventoryManager.Instance.HideInventory ();
			else
				InventoryManager.Instance.ShowInventory ();
		}


	}

	void FixedUpdate()
	{
		rgbd.MovePosition(rgbd.position + mov * speed * Time.deltaTime);
	}

	IEnumerator test_Cutscene(){
		Cutscene ("IdleUp");
		yield return new WaitForSeconds (3f);
		Cutscene ("MoveDown");
		yield return new WaitForSeconds (0.675f);
		Cutscene ("MoveLeft");
		yield return new WaitForSeconds (1.15f);
		Cutscene ("IdleDown");
		yield return new WaitForSeconds (0.5f);
		Cutscene ("MoveDown");
		yield return new WaitForSeconds (0.65f);
		Cutscene ("IdleUp");
		transform.position = new Vector3 (-0.28f, -3.44f, 0f);
		yield return new WaitForSeconds (2f);
		Instantiate (monsterIncomingPrefab, new Vector3 (1.89f, -0.73f, 0f), Quaternion.identity);
		yield return new WaitForSeconds (2f);
		Cutscene ("MoveUp");
		yield return new WaitForSeconds (0.85f);
		Cutscene ("IdleRight");
		EnableEmoji (0);
		yield return new WaitForSeconds (2f);
		HideEmoji ();

		print ("Fim de cutscene");
	}

	void Cutscene(string command){
		switch (command) {

		case "MoveRight":
			anim.SetBool ("Walk", true);
			anim.SetFloat ("MovX", 1f);
			anim.SetFloat ("MovY", 0f);
			mov.x = 1f;
			mov.y = 0f;
			curDir = Directions.Right;
			break;

		case "MoveLeft":
			anim.SetBool ("Walk", true);
			anim.SetFloat ("MovX", -1f);
			anim.SetFloat ("MovY", 0f);
			mov.x = -1f;
			mov.y = 0f;
			curDir = Directions.Left;
			break;

		case "MoveDown":
			anim.SetBool ("Walk", true);
			anim.SetFloat ("MovX", 0f);
			anim.SetFloat ("MovY", -1f);
			mov.x = 0f;
			mov.y = -1f;
			curDir = Directions.Down;
			break;

		case "MoveUp":
			anim.SetBool ("Walk", true);
			anim.SetFloat ("MovX", 0f);
			anim.SetFloat ("MovY", 1f);
			mov.x = 0f;
			mov.y = 1f;
			curDir = Directions.Up;
			break;

		case "IdleLeft":
			anim.SetBool ("Walk", false);
			anim.SetFloat ("MovX", -1f);
			anim.SetFloat ("MovY", 0f);
			mov.x = 0f;
			mov.y = 0f;
			break;

		case "IdleRight":
			anim.SetBool ("Walk", false);
			anim.SetFloat ("MovX", 1f);
			anim.SetFloat ("MovY", 0f);
			mov.x = 0f;
			mov.y = 0f;
			break;

		case "IdleDown":
			anim.SetBool ("Walk", false);
			anim.SetFloat ("MovX", 0f);
			anim.SetFloat ("MovY", -1f);
			mov.x = 0f;
			mov.y = 0f;
			break;

		case "IdleUp":
			anim.SetBool ("Walk", false);
			anim.SetFloat ("MovX", 0f);
			anim.SetFloat ("MovY", 1f);
			mov.x = 0f;
			mov.y = 0f;
			break;

		default:
			break;
		}

	}

	public void EnableEmoji(int emojiIndex){
		emojis.GetComponent<SpriteRenderer> ().sprite = emojiTotal [emojiIndex];
		emojis.GetComponent<SpriteRenderer> ().enabled = true;
	
	}

	public void HideEmoji(){
		emojis.GetComponent<SpriteRenderer> ().enabled = false;

	}


}
