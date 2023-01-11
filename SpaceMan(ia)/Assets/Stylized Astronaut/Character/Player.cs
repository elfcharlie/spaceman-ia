using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;
		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		public float jumpSpeed;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity /*= 40.0f*/;
		private float lastGrounded;
		private float lastJump;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){

			if(controller.isGrounded){
				anim.SetBool ("isGrounded", true);
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			}

			if (anim.GetBool("isGrounded") && Input.GetKey ("w") || Input.GetKey("s")) {
				anim.SetBool ("isRunning", true);
			}  else if (anim.GetBool("isGrounded")) {
				anim.SetBool ("isRunning", false);
			}
			
			if (anim.GetBool("isGrounded") && Input.GetKey ("space")){
				anim.SetBool ("isJumping", true);
				anim.SetBool ("isGrounded", false);
				moveDirection.y += jumpSpeed;
			}
			
			if (anim.GetBool("isJumping") && moveDirection.y <= 0 || moveDirection.y < -6) {
				anim.SetBool ("isFalling", true);
				anim.SetBool ("isJumping", false);
				
			} else if (anim.GetBool("isGrounded") && anim.GetBool("isFalling")){
				anim.SetBool ("isFalling", false);
			}
		
			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			
			moveDirection.y -= gravity * Time.deltaTime;
		}
}
