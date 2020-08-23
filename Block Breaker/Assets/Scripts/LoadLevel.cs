using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadLevel : MonoBehaviour
{
	[SerializeField] private List<GameObject> levels = new List<GameObject>();

	private void Start()
	{
		Instantiate(levels[GameManager.Instance.GetSelectedLevel()]);
	}

}
