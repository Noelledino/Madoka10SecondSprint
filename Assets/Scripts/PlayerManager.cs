﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager: MonoBehaviour{

	public AudioClip jump;
	public AudioClip coin;
	public AudioClip time;
	public AudioClip step;

	public float maxSpeed = 3f;
	bool facingRight = true;
	Animator anim;
	private GameManager gm;
	private TimeManager tm;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = .02f;
	public LayerMask whatIsGround;
	public float jumpForce = 800f;
	bool doubleJump = false;

	bool ismove = false;

	void Start ()	{
		anim = GetComponent<Animator> ();
		GetComponent<Rigidbody2D> ().freezeRotation = true;
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		tm = GameObject.FindGameObjectWithTag ("TimeManager").GetComponent<TimeManager>();
	}

	void FixedUpdate ()	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetBool ("Move", ismove);
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		float move = Input.GetAxis ("Horizontal"); 
		anim.SetFloat ("Speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		if (move > 0.1 || move < 0.1) {
			ismove = true;
		}
		if (move == 0) {
			ismove = false;
		}
			
	if (move == 0 && grounded) {
		ismove = false;


	}

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

	}


		void Update (){
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (grounded) {
					anim.SetBool ("Ground", false);
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 0f);   
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpForce)); 
					AudioSource ourAudio = GetComponent<AudioSource> ();
					ourAudio.PlayOneShot (jump);
					doubleJump = true;
				} else if (doubleJump) {
					doubleJump = false;
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 0f);  
					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, jumpForce)); 
					AudioSource ourAudio = GetComponent<AudioSource> ();
					ourAudio.PlayOneShot (jump);
				}
			}
		}

	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Candy")) {
			Destroy (col.gameObject);
			AudioSource ourAudio = GetComponent<AudioSource> ();
			ourAudio.PlayOneShot (coin);
			gm.points += 1;
		}
		if (col.CompareTag ("Time")) {
			Destroy (col.gameObject);
			AudioSource ourAudio = GetComponent<AudioSource> ();
			ourAudio.PlayOneShot (time);
			tm.startingTime += 10;
		}
	}


		}