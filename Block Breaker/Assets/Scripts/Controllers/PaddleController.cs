using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaddleController : MonoBehaviour
{
	[Tooltip("This values is used to limit the movement of the paddle")]
	[SerializeField] private float min, max;

	private void Update()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition);
		mousePosition.x = Mathf.Clamp(mousePosition.x, min, max);
		transform.position = new Vector2( mousePosition.x, transform.position.y);
	}
}
