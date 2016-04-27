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

	void Start () 
	{

	}

	void FixedUpdate()
	{
		animator = GetComponent<Animator> ();
		spr = GetComponent<SpriteRenderer> ();
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, WhatIsGround);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if (Input.GetKeyDown(KeyCode.Space) && grounded) 
		{
			rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
		}
		if (Input.GetKey(KeyCode.RightArrow)) 
		{
			rb.velocity = new Vector2 (speed,rb.velocity.y);
			animator.SetBool ("WalkingRight", true);
			if (spr.flipX == true) 
			{
				spr.flipX = false;
			}
		}
		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			rb.velocity = new Vector2 (-speed,rb.velocity.y);
			spr.flipX = true;
			animator.SetBool ("WalkingRight", true);
		}
		if (Input.anyKey == false) {
			animator.SetBool ("WalkingRight", false);
		} 
		else 
		{
			
		}
	}
}
