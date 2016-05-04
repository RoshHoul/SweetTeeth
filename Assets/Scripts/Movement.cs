using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	Animator animator;
	public float speed;
	public float jumpHeight;

	SpriteRenderer spr;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask WhatIsGround;
	private bool grounded;
	bool right;
	bool left;
	bool jump;
	public bool Candy;
	public bool candyPicking;
	public bool candyPickingLeft;
	public bool candyPickingRight;
	public bool candyPickingUp;
	bool candybool;
	bool candybool2;

	void Start () 
	{

	}
		
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		animator = GetComponent<Animator> ();
		spr = GetComponent<SpriteRenderer> ();
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, WhatIsGround);
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if (candyPicking) 
		{
			{
				candyPicking = false;
				animator.SetTrigger ("Candy");
			}
		}
		if ((jump || Input.GetKeyDown(KeyCode.Space))  == true && grounded) 
		{
			rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
			if (candyPickingUp) 
			{
				candyPicking = false;
				candyPickingUp = false;
				animator.SetTrigger ("Candy");
			}
		}
		if ((right || Input.GetKey(KeyCode.RightArrow)) == true) 
		{
			rb.velocity = new Vector2 (speed , rb.velocity.y);
			animator.SetFloat ("Speed", GetComponent<Rigidbody2D>().velocity.x);
			Debug.Log (Candy);
			if (Candy) 
			{
				animator.SetFloat ("Candy", GetComponent<Rigidbody2D>().velocity.x);
			}
			if (candyPickingRight) 
			{
				candyPicking = false;
				candyPickingRight = false;
				animator.SetTrigger ("Candy");
			}
			if (spr.flipX == true) 
			{
				spr.flipX = false;
			}
		}
		if ((jump || Input.GetKey(KeyCode.Space)) == false && grounded) 
		{
			rb.velocity = new Vector2 (rb.velocity.x, 0);
			if (candyPickingUp) 
			{
				candyPicking = false;
				candyPickingUp = false;
				animator.SetTrigger ("Candy");
			}
		}
			if ((left || Input.GetKey(KeyCode.LeftArrow)) == true) 
		{
			rb.velocity = new Vector2 (-speed , rb.velocity.y);
			spr.flipX = true;
			animator.SetFloat ("Speed", -GetComponent<Rigidbody2D>().velocity.x);
			if (Candy) 
			{
				animator.SetFloat ("Candy", -GetComponent<Rigidbody2D>().velocity.x);
			}
			if (candyPickingLeft) 
			{
				candyPickingLeft = false;
				candyPicking = false;
				animator.SetTrigger ("Candy");
			}
		}
		if ((Input.anyKey) == false) {
			animator.SetFloat ("Speed", GetComponent<Rigidbody2D>().velocity.x);
		} 
		else 
		{
			
		}
	}
		
	void OnCollisionEnter2D (Collision2D col)
	{
		animator = GetComponent<Animator> ();
		if(col.gameObject.tag == "Candy")
		{
			Debug.Log("Colliding with: " + col.gameObject.name);
			//col.gameObject.SetActive(false);
			GameObject testObj = col.gameObject;
			testObj.transform.parent = null;
			candyPicking = true;
			if ((right || Input.GetKey (KeyCode.RightArrow)) == true) 
			{
				candyPickingRight = true;
			}
			if ((left || Input.GetKey (KeyCode.LeftArrow)) == true) 
			{
				candyPickingLeft = true;
			}
			if ((jump || Input.GetKeyDown (KeyCode.Space)) == true) 
			{
				candyPickingUp = true;
			}
			Destroy(testObj);
		}
	}

	public void moveRight()
	{
		right = true;
	}
	public void stopRight()
	{
		right = false;
	}
	public void moveLeft()
	{
		left = true;
	}
	public void stopLeft()
	{
		left = false;
	}
	public void JumpUp()
	{
		jump = true;
	}
	public void JumpStill()
	{
		jump = false;
	}
}
