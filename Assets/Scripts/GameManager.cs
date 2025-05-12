using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool _isGameOver;

    public event Action<bool> OnGameOver;

    public static GameManager Singleton { get; private set; }
    public bool IsGameOVer
    {
        get { return _isGameOver; }
        set { 
            _isGameOver = value;
        }
    }

    private void Awake() {
        if (Singleton != null) {
            Destroy(gameObject);
            return;
        }
        Singleton = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }

    public void PauseGame(bool isPause) {
        Time.timeScale = isPause ? 0 : 1;
    }
    public void GameOver() {
        IsGameOVer = true;
        OnGameOver?.Invoke(_isGameOver);
    }

}
