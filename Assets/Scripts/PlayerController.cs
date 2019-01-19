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

	bool hatchetAttack = false;
	bool canMove = true;

	public bool hasHatchet = false;

	public Transform hitUpPos;
	public Transform hitDownPos;
	public Transform hitLeftPos;
	public Transform hitRightPos;

	public Transform ponteAtrapalhador;
	public Transform ponteTrigger;
	public Transform ponteObj;
	public Sprite[] ponteSpr;

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

        transform.position = new Vector3(1.15f, -49.455f, 0f);

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



		if(canMove && mov != Vector2.zero)
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

        if (Input.GetKeyDown(KeyCode.K))
        {
            FadeManager.Instance.StartCoroutine(FadeManager.Instance.FadeImage(true));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            FadeManager.Instance.StartCoroutine(FadeManager.Instance.FadeImage(false));
        }

        if (Input.GetKeyDown (KeyCode.Z)) {
			GiveItem (0);
			hasHatchet = true;
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			GiveItem (1);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			GiveItem (2);
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			GiveItem (3);
		}

        if (Input.GetKeyDown(KeyCode.B))
        {
            RemoveItem(2);
            RemoveItem(2);
            RemoveItem(2);
            RemoveItem(2);
            RemoveItem(2);
        }

		if (Input.GetKeyDown (KeyCode.F)) {
			if(InventoryManager.Instance.hud1.activeInHierarchy)
				InventoryManager.Instance.HideInventory ();
			else
				InventoryManager.Instance.ShowInventory ();
		}

		if (hasHatchet && !hatchetAttack && Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine (Hatchet_CR());
		}


	}

	void FixedUpdate()
	{
		if(canMove)
		rgbd.MovePosition(rgbd.position + mov * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Botao_Reset1")
			PuzzleOneManager.Instance.ResetBotoes ();
		if (col.tag == "Botao_Reset2")
			PuzzleTwoManager.Instance.ResetBotoes ();
		if (col.tag == "PonteTrigger")
			CheckMadeira ();
		if (col.tag == "Warp") {
			transform.position = col.GetComponentInChildren<Warpzone> ().warpPos.position;
		}
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
		transform.position = new Vector3 (-0.28f, -53.44f, 0f);
		yield return new WaitForSeconds (2f);
		Instantiate (monsterIncomingPrefab, new Vector3 (1.89f, -50.73f, 0f), Quaternion.identity);
		yield return new WaitForSeconds (2f);
		Cutscene ("MoveUp");
		yield return new WaitForSeconds (0.85f);
		Cutscene ("IdleRight");
		EnableEmoji (0);
		yield return new WaitForSeconds (2f);
		HideEmoji ();
        yield return new WaitForSeconds (5.5f);

        Camera.main.transform.parent = this.transform;
		Camera.main.transform.localPosition = new Vector3 (0f, 0f, -10f);
        //transform.position = new Vector3 (1.3f,71.6f,0f);
        StartCoroutine(Teleport_CR(1.3f,71.6f,0f));
		//Cutscene ("IdleUp");
		disabled = false;
		InventoryManager.Instance.ShowInventory ();

		print ("Fim de cutscene");
	}

	IEnumerator Hatchet_CR(){
		hatchetAttack = true;
		EnableEmoji (13);
		canMove = false;
		CheckTree ();
		yield return new WaitForSeconds (1f);
		canMove = true;
		HideEmoji ();
		hatchetAttack = false;
	}

	IEnumerator Ponte_CR(){
		EnableEmoji (0);
		canMove = false;
		yield return new WaitForSeconds (1f);
		canMove = true;
		HideEmoji ();
	}

    public IEnumerator Teleport_CR(float x, float y, float z)
    {
        PlayerController.Instance.mov = new Vector2(0f, 0f);
        PlayerController.Instance.anim.SetBool("Walk", false);
        PlayerController.Instance.disabled = true;
        FadeManager.Instance.StartCoroutine(FadeManager.Instance.FadeImage(false));
        yield return new WaitForSeconds(1.5f);
        transform.position = new Vector3(x, y, z);
        yield return new WaitForSeconds(0.5f);
        FadeManager.Instance.StartCoroutine(FadeManager.Instance.FadeImage(true));
        yield return new WaitForSeconds(1f);
        PlayerController.Instance.disabled = false;
    }

	void PonteConstruida(){
		ponteTrigger.gameObject.SetActive (false);
		ponteObj.GetComponent<SpriteRenderer> ().sprite = ponteSpr [1];
		//ponteObj.GetComponent<BoxCollider2D> ().enabled = false;
		ponteAtrapalhador.gameObject.SetActive (false);
	}

	void PonteDestruida(){
		ponteTrigger.gameObject.SetActive (true);
		ponteObj.GetComponent<SpriteRenderer> ().sprite = ponteSpr [0];
		//ponteObj.GetComponent<BoxCollider2D> ().enabled = true;
		ponteAtrapalhador.gameObject.SetActive (true);

	}

	void CheckMadeira(){
		for (int i = 0; i < InventoryManager.Instance.slotAmount.Length; i++) {
			if (InventoryManager.Instance.slotItem [i] == 2) {
				if (InventoryManager.Instance.slotAmount [i] >= 5) {
					PonteConstruida ();
                    RemoveItem(2);
                    RemoveItem(2);
                    RemoveItem(2);
                    RemoveItem(2);
                    RemoveItem(2);
                } else {
					print ("Pegue mais madeiras");
				}
			} else {
				print ("Não tem madeira");
			}
		}
		StartCoroutine (Ponte_CR ());
	}

	void CheckTree(){

		if (curDir == Directions.Up) {
			RaycastHit2D hit;
			hit = Physics2D.Raycast (hitUpPos.position, hitUpPos.forward, 0.05f);
			if (hit.collider != null) {
				if (hit.collider.gameObject.name.Contains ("arvore")) {
					hit.collider.gameObject.GetComponent<Arvore> ().TakeDamage ();
				}
			}
		} else if (curDir == Directions.Down) {
			RaycastHit2D hit;
			hit = Physics2D.Raycast (hitDownPos.position, hitDownPos.forward, 0.05f);
			if (hit.collider != null) {
				if (hit.collider.gameObject.name.Contains ("arvore")) {
					hit.collider.gameObject.GetComponent<Arvore> ().TakeDamage ();
				}
			}
		} else if (curDir == Directions.Left) {
			RaycastHit2D hit;
			hit = Physics2D.Raycast (hitLeftPos.position, hitLeftPos.forward, 0.05f);
			if (hit.collider != null) {
				if (hit.collider.gameObject.name.Contains ("arvore")) {
					hit.collider.gameObject.GetComponent<Arvore> ().TakeDamage ();
				}
			}
		} else if (curDir == Directions.Right) {
			RaycastHit2D hit;
			hit = Physics2D.Raycast (hitRightPos.position, hitRightPos.forward, 0.05f);
			if (hit.collider != null) {
				if (hit.collider.gameObject.name.Contains ("arvore")) {
					hit.collider.gameObject.GetComponent<Arvore> ().TakeDamage ();
				}
			}
		}


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

	public void GiveItem(int itemId){
        for (int i = 0; i < InventoryManager.Instance.slotAmount.Length; i++) // loop pelo inventario
        {
            if (!InventoryManager.Instance.slotOccupied[i]) // se não tiver ocupado
            {
                InventoryManager.Instance.AddItem(i, itemId); // adiciona o item
                break; // retorna
            }
            else if (InventoryManager.Instance.slotOccupied[i]) // senão se tiver ocupado
            {
                if (InventoryManager.Instance.slotItem[i] == itemId) // se o item for o mesmo tentando dar
                {
                    InventoryManager.Instance.AddItem(i, itemId); // adiciona o item
                    break;
                }
            }
        }
	}

    public void RemoveItem(int itemId)
    {
        for (int i = 0; i < InventoryManager.Instance.slotAmount.Length; i++) // loop pelo inventario
        {
            if (!InventoryManager.Instance.slotOccupied[i]) // se não tiver ocupado
            {
                break; // retorna
            }
            else if (InventoryManager.Instance.slotOccupied[i]) // senão se tiver ocupado
            {
                if (InventoryManager.Instance.slotItem[i] == itemId) // se o item for o mesmo tentando dar
                {
                    InventoryManager.Instance.RemoveItem(i, itemId); // adiciona o item
                    break;
                }
            }
        }
    }


}
