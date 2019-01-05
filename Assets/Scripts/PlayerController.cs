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
		//anim = GetComponent<Animator>();
		curDir = Directions.Down;
		//anim.SetFloat ("MovY", -1.0f);

	}

	void Update(){
		mov = new Vector2(
			Input.GetAxisRaw("Horizontal"),
			Input.GetAxisRaw("Vertical")
		);



		if(mov != Vector2.zero)
		{
			//anim.SetFloat("MovX", mov.x);
			//anim.SetFloat("MovY", mov.y);
			//anim.SetBool("Walk", true);


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
			//anim.SetBool("Walk", false);
		}
	}

	void FixedUpdate()
	{	
		rgbd.MovePosition(rgbd.position + mov * speed * Time.deltaTime);
	}


}
