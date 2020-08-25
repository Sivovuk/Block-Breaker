using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishScript : MonoBehaviour
{
    [SerializeField] private PaddleController paddle;
    [SerializeField] private BallController ball;
    [SerializeField] private LevelManager levelManager;

    [SerializeField] private GameObject _finishGamePanel;

    [SerializeField] private GameObject _finishLevelPanel;
    [SerializeField] private Button _finishLevelPanelButNext;
    [SerializeField] private TextMeshProUGUI _finishLevelPanelTextPlayer;
    [SerializeField] private TextMeshProUGUI _finishLevelPanelTextLevel;

    public void GameFinish() 
    {
        paddle.enabled = false;
        ball.FinishLevel();
        ball.enabled = false;
        levelManager.enabled = false;

        LoadWiningScreen();
    }

    private void LoadWiningScreen()
    {
        _finishGamePanel.GetComponent<Animator>().SetBool("isOpen", true);
    }

    public void FinishLevel() 
    {
        _finishLevelPanel.GetComponent<Animator>().SetBool("isOpen", true);
        _finishLevelPanelButNext.onClick.AddListener(delegate { LevelManager.Instance.LoadNextLevel(LevelManager.Instance.GetCounter()); } );
        _finishLevelPanelButNext.onClick.AddListener(delegate { CloseFinishLevelPanel(); });

        _finishLevelPanelTextLevel.text = "Level Score : " + LevelManager.Instance.GetLeveScore().ToString();
        _finishLevelPanelTextPlayer.text = "Player Score : " + LevelManager.Instance.GetPlayerScore().ToString();

        paddle.enabled = false;
        ball.FinishLevel();
        ball.enabled = false;
        levelManager.enabled = false;
    }

    public void CloseFinishLevelPanel()
    {
        _finishLevelPanel.GetComponent<Animator>().SetBool("isOpen", false);
        _finishLevelPanelButNext.onClick.RemoveAllListeners();

        paddle.enabled = true;
        ball.enabled = true;
        levelManager.enabled = true;
    }
}
