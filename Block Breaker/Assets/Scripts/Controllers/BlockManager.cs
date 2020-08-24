using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockManager : MonoBehaviour
{
	[SerializeField] private int _blockValue;

	public int GetBlockValue() 
	{
		return _blockValue;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) 
		{
			Destroy(gameObject);
		}
	}

}
