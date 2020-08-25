using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockManager : MonoBehaviour
{
	[SerializeField] private int _blockValue;

	[SerializeField] private GameObject _destroyEffect;

	public int GetBlockValue() 
	{
		return _blockValue;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player")) 
		{
			LevelManager.Instance.AddScore(_blockValue);
			SoundManager.Instance.PlayAudio(SoundManager.Instance.clunk);

			GameObject spawn = Instantiate(_destroyEffect, transform.position, Quaternion.identity);
			Destroy(spawn, 2);

			Destroy(gameObject);
		}
	}

}
