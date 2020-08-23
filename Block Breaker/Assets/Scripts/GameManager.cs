using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
	#region Selected Level Index
		private static int selectLevelIndex;
		public void SetLevelIndex(int index) { selectLevelIndex = index; }
		public int GetSelectedLevel() { return selectLevelIndex; }
	#endregion

	private static GameManager instance;

	public static GameManager Instance => instance;

	private void Start()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else 
		{
			Destroy(gameObject);
		}
	}
}
