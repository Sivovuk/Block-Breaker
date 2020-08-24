using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int _playerScore;
    [SerializeField] private int _levelScore;
    [SerializeField] private int _collectedLevelScore;
    private int _counter;

    [SerializeField] private GameObject _currentLoadedLevel;

    [Space]

    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private GameManager gameManager;
    private SoundManager soundManager;

    void Start()
    {
        gameManager = GameManager.Instance;
        soundManager = SoundManager.Instance;

        LoadNextLevel();                            //  instantiate first level
    }

    public void AddScore(int amount) 
    {
        _collectedLevelScore += amount;

        if (_collectedLevelScore >= _levelScore)
        {
            _counter++;
            LoadNextLevel();
        }
    }

    private void LoadNextLevel() 
    {
        if (_currentLoadedLevel != null)
        {
            Destroy(_currentLoadedLevel);
        }

        _currentLoadedLevel = Instantiate(levels[gameManager.GetSelectedLevel()]);

        StartCoroutine(TakeLevelScore());
    }

    IEnumerator TakeLevelScore() 
    {
        yield return new WaitForSeconds(0.25f);
        _levelScore = _currentLoadedLevel.GetComponent<LevelStats>().GetLevelScore();
    }
}
