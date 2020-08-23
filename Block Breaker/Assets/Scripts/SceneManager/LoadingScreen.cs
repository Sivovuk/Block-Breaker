using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	private AsyncOperation operation;
	[SerializeField] private Image loadingImage;

	private void Start()
	{
		StartCoroutine(LoadSceneAsych());
	}

	private void Update()
	{
		if (operation != null)
		{
			loadingImage.fillAmount = operation.progress;
		}
	}

	IEnumerator LoadSceneAsych()
	{
		yield return null;

		operation = SceneManager.LoadSceneAsync(1);

		if (!operation.isDone)
		{
			yield return null;
		}
	}
}
