using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallController : MonoBehaviour
{
	private bool isLaunch = false;

	[SerializeField] private PaddleController paddle;

	private Vector2 paddleToBallVector;

	private void Start()
	{
		paddleToBallVector = transform.position - paddle.transform.position;
	}

	private void Update()
	{
		FollowPaddle();
		LaunchOnMouseClick();

	}

	private void FollowPaddle()
	{
		if (!isLaunch)
		{
			Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);

			transform.position = paddlePosition + paddleToBallVector;
		}
	}

	private void LaunchOnMouseClick() 
	{
		if (Input.GetMouseButtonDown(0) && !isLaunch) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(2, 15);
			isLaunch = true;
		}
	}
}
