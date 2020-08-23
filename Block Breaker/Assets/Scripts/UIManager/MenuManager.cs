using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	public bool isMenuStartedOperation = false;

	private Coroutine menuFinish;

	public void OpenCloseMenu(GameObject panel)
	{
		if (!isMenuStartedOperation) 
		{ 
			if (!panel.transform.GetChild(0).gameObject.activeSelf)
			{
				panel.GetComponent<Animator>().SetBool("isOpen", true);
				isMenuStartedOperation = true;
				menuFinish = StartCoroutine(MenuFinishedOperation());
			}
			else
			{
				panel.GetComponent<Animator>().SetBool("isOpen", false);
				isMenuStartedOperation = true;
				menuFinish = StartCoroutine(MenuFinishedOperation());
			}
		}
	}

	IEnumerator MenuFinishedOperation() 
	{
		yield return new WaitForSeconds(1);
		isMenuStartedOperation = false;
		if (menuFinish != null) 
		{
			StopCoroutine(menuFinish);
		}
	}
}
