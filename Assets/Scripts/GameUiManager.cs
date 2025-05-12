using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUiManager : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI _waveCountText;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _pausePanel;

    private void Awake() {
        Time.timeScale = 1;
        _gameOverPanel.SetActive(false);
    }
    private void OnEnable() {
        _spawnManager.OnWaveCountChange += UpdateWaveCountText;
        GameManager.Singleton.OnGameOver += ShowGameOverPanel;
    }
    private void OnDisable() {
        _spawnManager.OnWaveCountChange -= UpdateWaveCountText;
        GameManager.Singleton.OnGameOver -= ShowGameOverPanel;

    }

    public void RestartGame() {
        if (GameManager.Singleton != null) {
            GameManager.Singleton.RestartGame();
        }
    }
    public void UpdateWaveCountText(int wave) {
        _waveCountText.text = "Wave: " + wave;
    }
    private void ShowGameOverPanel(bool val) {
        _gameOverPanel.SetActive(true);
    }
    public void ShowPausePanel(bool isActive) {
        if (!GameManager.Singleton.IsGameOVer) {
            _pausePanel.SetActive(isActive);
            PauseGame(isActive);
        }
    }

    private void PauseGame(bool isTrue) {
        GameManager.Singleton.PauseGame(isTrue);
    }
}
