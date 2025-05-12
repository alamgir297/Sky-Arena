using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour {
    private float _spawnRate = 3f;
    private int _spawnRange = 9;
    private int _waveNumber;

    public event Action<int> OnWaveCountChange;

    public int WaveCount
    {
        get { return _waveNumber; }
        set { _waveNumber = value; }
    }

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _powerupPrefab;
    [SerializeField] private GameUiManager _gameUi;

    void Start() {
        GameManager.Singleton.IsGameOVer = false;
        WaveCount = 0;
        StartCoroutine(EnemySpawnRoutine());
    }
    Vector3 GenerateSpawnPosition() {
        int pointX = Random.Range(-_spawnRange, _spawnRange);
        int pointZ = Random.Range(-_spawnRange, _spawnRange);
        Vector3 position = new Vector3(pointX, 0, pointZ);
        return position;
    }

    private void SpawnEnemy(int waveNumber) {
        Instantiate(_powerupPrefab, GenerateSpawnPosition(), Quaternion.identity);
        for(int i=0; i<waveNumber; i++) {
            GameObject newEnemy;
            newEnemy = Instantiate(_enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
        }
    }
    private bool AllEnemiesAreDefeated() {
        return _enemyContainer.transform.childCount == 0;
    }
    private bool IsGameOver() {
        return GameManager.Singleton.IsGameOVer;
    }
    IEnumerator EnemySpawnRoutine() {
        while (!IsGameOver()) {
            yield return new WaitUntil(AllEnemiesAreDefeated);
            if (IsGameOver()) yield break;
            WaveCount++;
            SpawnEnemy(WaveCount);
            OnWaveCountChange?.Invoke(WaveCount);
        }
    }
}
