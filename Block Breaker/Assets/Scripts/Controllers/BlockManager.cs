using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockManager : MonoBehaviour
{
	[SerializeField] private int _blockValue;
	[SerializeField] private int _blockLives;

	[SerializeField] private GameObject _destroyEffect;
	[SerializeField] private List<Sprite> blockLevels = new List<Sprite>();

	public int GetBlockValue() 
	{
		return _blockValue;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_blockLives--;
			SoundManager.Instance.PlayAudio(SoundManager.Instance.clunk);

			if (_blockLives < 0)
			{
				LevelManager.Instance.AddScore(_blockValue);

				GameObject spawn = Instantiate(_destroyEffect, transform.position, Quaternion.identity);
				Destroy(spawn, 2);

				Destroy(gameObject);
			}
			else if (_blockLives == 0)
			{
				GetComponent<SpriteRenderer>().sprite = blockLevels[0];
			}
			else if (_blockLives == 1)
			{
				GetComponent<SpriteRenderer>().sprite = blockLevels[1];
			}
		}
	}

}
