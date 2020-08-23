using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoseCollider : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player")) 
		{
			SceneManagerScript.Instance.RestartScene();
		}
	}

}
