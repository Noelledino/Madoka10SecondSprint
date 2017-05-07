using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager: MonoBehaviour{

	public AudioClip jump;
	public AudioClip step;

	public float maxSpeed = 3f;
	bool facingRight = true;
	Animator anim;

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

		}