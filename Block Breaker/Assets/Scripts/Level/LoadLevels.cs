using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LoadLevels : MonoBehaviour
{
	[SerializeField] private int levelsNum;

	[SerializeField] private RectTransform parent;

	[SerializeField] private GameObject levelsPrefab;

	private void Start()
	{
		InstantiateLevels();
	}

	private void InstantiateLevels()
	{
		for (int i = 0; i < levelsNum; i++) 
		{
			GameObject spawn = Instantiate(levelsPrefab);
			spawn.GetComponent<RectTransform>().parent = parent;
			spawn.GetComponentInChildren<TextMeshProUGUI>().text = (1+i).ToString();
			spawn.transform.localScale = new Vector3(1,1,1);

			int num = i;
			spawn.GetComponent<Button>().onClick.AddListener(delegate { OnButtonClickSelectLevel(num); });
			spawn.GetComponent<Button>().onClick.AddListener(delegate { AudioManager.Instance.PlayClick2Sound(); });
		}
	}

	public void OnButtonClickSelectLevel(int index) 
	{
		Debug.LogError(index);
		GameManager.Instance.SetLevelIndex(index);
		SceneManagerScript.Instance.LoadScene(3);
	}
}
