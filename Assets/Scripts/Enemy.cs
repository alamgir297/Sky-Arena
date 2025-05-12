using UnityEngine;

public class Enemy : MonoBehaviour {
    private float _moveDistance = 0.01f;
    private float _lowerBound = -3f;
    
    private GameObject _player;
    private Rigidbody _enemyRb;
    private Vector3 _playerPosition;

    [SerializeField] private float _enemyForce;

    void Start() {
        _player = GameObject.FindWithTag("Player");
        _enemyRb = GetComponent<Rigidbody>();
        _playerPosition = _player.transform.position;
    }

    private void Update() {

        CheckBound();
    }
    void FixedUpdate() {
        ChasePlayer();
    }

    void ChasePlayer() {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        _enemyRb.AddForce(direction * _enemyForce);
    }

    void CheckBound() {
        if (transform.position.y <= _lowerBound) {
            Destroy(gameObject);
        }
    }
}
