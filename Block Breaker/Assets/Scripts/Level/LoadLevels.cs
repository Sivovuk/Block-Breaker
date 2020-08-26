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
	[SerializeField] private Color _finishLevelColor;

	private void Start()
	{
		if (!PlayerPrefs.HasKey(0 + "_level_unlock"))
		{
			PlayerPrefs.SetInt(0 + "_level_unlock", 1);
		}

		InstantiateLevels();
	}

	private void InstantiateLevels()
	{
		for (int i = 0; i < levelsNum; i++) 
		{
			//Debug.LogError(i);
			GameObject spawn = Instantiate(levelsPrefab);
			spawn.GetComponent<RectTransform>().parent = parent;
			spawn.GetComponentInChildren<TextMeshProUGUI>().text = (1+i).ToString();
			spawn.transform.localScale = new Vector3(1,1,1);

			int num = i;
			spawn.GetComponent<Button>().onClick.AddListener(delegate { OnButtonClickSelectLevel(num); });
			spawn.GetComponent<Button>().onClick.AddListener(delegate { AudioManager.Instance.PlayClick2Sound(); });

			if (PlayerPrefs.GetInt(i+"_level_unlock") == 1) 
			{
				spawn.GetComponent<Button>().interactable = true;
				spawn.transform.GetChild(0).GetComponent<Image>().enabled = false;
			}

			if (PlayerPrefs.GetInt(i + "_level_finished") == 1) 
			{
				spawn.GetComponent<Image>().color = _finishLevelColor;
			}
		}
	}

	public void OnButtonClickSelectLevel(int index) 
	{
		Debug.LogError(index);
		GameManager.Instance.SetLevelIndex(index);
		SceneManagerScript.Instance.LoadScene(3);
	}
}
