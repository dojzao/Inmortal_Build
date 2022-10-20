using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	[SerializeField]bool jump = false;
	[SerializeField]bool dash = false;

	//bool dashAxis = false;
	
	// Update is called once per frame
	void Update () { 

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if(horizontalMove > 0){
            BackgroundScroller.playermov = 1;
        }else if(horizontalMove < 0){
            BackgroundScroller.playermov = 2;
        }else {

            BackgroundScroller.playermov = 0;
        }
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));



		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/

	}
	public void DoJump(InputAction.CallbackContext context)
	{
		jump = true; 

	}
	public void DoDash(InputAction.CallbackContext context){
		dash = true;
	}
	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}

}
