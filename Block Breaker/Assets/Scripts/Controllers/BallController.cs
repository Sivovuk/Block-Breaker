using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
	[SerializeField] private bool isLaunch = false;

	[SerializeField] private PaddleController paddle;

	[SerializeField] private Vector2 paddleToBallVector;

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
		if (Input.GetMouseButtonDown(0) && !isLaunch && !EventSystem.current.currentSelectedGameObject) 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(2, 15);
			isLaunch = true;
		}
	}

	public void FinishLevel() 
	{
		isLaunch = false;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	}


	private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Paddle"))
		{
			SoundManager.Instance.PlayAudio(SoundManager.Instance.bounce);
		}
    }
}
