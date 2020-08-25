using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public const string HIGHEST_LEVEL_INDEX = "HIGHESTLEVEL";

    [SerializeField] private int _playerScore;
    [SerializeField] private int _levelScore;
    [SerializeField] private int _collectedLevelScore;
    [SerializeField] private int _counter;

    [Space]

    [SerializeField] private GameFinishScript _finishGame;
    
    [Space]

    [SerializeField] private GameObject _currentLoadedLevel;
    [SerializeField] private TextMeshProUGUI _levelScoreText;
    [SerializeField] private TextMeshProUGUI _playerScoreText;

    private GameManager gameManager;
    private SoundManager soundManager;

    [Space]

    [SerializeField] private List<GameObject> levels = new List<GameObject>();


    private static LevelManager instance;
    public static LevelManager Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameManager = GameManager.Instance;
        soundManager = SoundManager.Instance;

        //  instantiate last played level
        if (PlayerPrefs.HasKey(HIGHEST_LEVEL_INDEX) && gameManager.GetSelectedLevel() < 0)
        {
            _counter = PlayerPrefs.GetInt(HIGHEST_LEVEL_INDEX);
            LoadNextLevel(_counter);
        }
        //  instantiate first level
        else
        {
            _counter = gameManager.GetSelectedLevel();
            LoadNextLevel(_counter);
        }
    }

    public void AddScore(int amount) 
    {
        _collectedLevelScore += amount;
        _levelScoreText.text = $"Level score : {_collectedLevelScore} ";

        if (_collectedLevelScore >= _levelScore)
        {
            _playerScore += _collectedLevelScore;
            _playerScoreText.text = $"Player score : {_playerScore} ";

            _collectedLevelScore = 0;

            _counter++;
            PlayerPrefs.SetInt(HIGHEST_LEVEL_INDEX, _counter);
            gameManager.SetLevelIndex(-1);

            if (levels.Count == _counter)
            {
                _finishGame.GameFinish();
            }
            else
            {
                _finishGame.FinishLevel();
            }
        }
    }

    public void LoadNextLevel(int counter) 
    {
        if (_currentLoadedLevel != null)
        {
            Destroy(_currentLoadedLevel);
        }

        if (counter >= 0 && levels.Count >= counter )
        {
            _currentLoadedLevel = Instantiate(levels[counter]);
        }
        else
        {
            _finishGame.GameFinish();
            return;
        }

        StartCoroutine(TakeLevelScore());
    }

    IEnumerator TakeLevelScore() 
    {
        yield return new WaitForSeconds(0.25f);
        _levelScore = _currentLoadedLevel.GetComponent<LevelStats>().GetLevelScore();
    }


    public int GetCounter() 
    {
        return _counter;
    }

    public int GetLeveScore() 
    {
        return _levelScore;
    }

    public int GetPlayerScore()
    {
        return _playerScore;
    }
}
