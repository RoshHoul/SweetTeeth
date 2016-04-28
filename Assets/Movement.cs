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
		if (jump == true && grounded) 
		{
			rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
		}
		if (right == true) 
		{
			rb.velocity = new Vector2 (speed , rb.velocity.y);
			animator.SetFloat ("Speed", GetComponent<Rigidbody2D>().velocity.x);
			if (spr.flipX == true) 
			{
				spr.flipX = false;
			}
		}
		if (right == false && left == false) 
		{
			rb.velocity = new Vector2 (0 , rb.velocity.y);
		}
		if (jump == false && grounded) 
		{
			rb.velocity = new Vector2 (rb.velocity.x, 0);
		}
		if (left == true) 
		{
			rb.velocity = new Vector2 (-speed , rb.velocity.y);
			spr.flipX = true;
			animator.SetFloat ("Speed", -GetComponent<Rigidbody2D>().velocity.x);
		}
		if (Input.anyKey == false) {
			animator.SetFloat ("Speed", GetComponent<Rigidbody2D>().velocity.x);
		} 
		else 
		{
			
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
