using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

	public float movePower = 5f;
	public float jumpPower = 5f;
	

	Rigidbody2D rigid;

	Vector3 movement;
	bool isJumping = false;

	//---------------------------------------------------[Override Function]
	//Initialization
	void Start ()
	{
		rigid = gameObject.GetComponent<Rigidbody2D> ();
	}

	//Graphic & Input Updates	
	void Update ()
	{
		if (Input.GetButtonDown ("Jump")) {
			isJumping = true;
		}
	}

	//Physics engine Updates
	void FixedUpdate ()
	{
		Move ();
		Jump ();
	}

	//---------------------------------------------------[Movement Function]

	void Move ()
	{		
		Vector3 moveVelocity= Vector3.zero;

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			moveVelocity = Vector3.left;
			transform.localScale = new Vector3(-1, 1, 1); // 왼쪽 바라보기
		}
			
		else if(Input.GetAxisRaw ("Horizontal") > 0){
			moveVelocity = Vector3.right;
			transform.localScale = new Vector3(1, 1, 1); // 오른쪽 바라보기
		}	

		transform.position += moveVelocity * movePower * Time.deltaTime;
	}

	void Jump ()
	{
		if (!isJumping)
			return;

		//Prevent Velocity amplification.
		rigid.velocity = Vector2.zero;

		Vector2 jumpVelocity = new Vector2 (0, jumpPower);
		rigid.AddForce (jumpVelocity, ForceMode2D.Impulse);

		isJumping = false;
	}
}