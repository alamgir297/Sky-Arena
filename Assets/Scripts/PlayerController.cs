using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    private float _verticalInput;
    private bool _isPowerupActive = false;
    private float _countdownDuration = 5f;
    private float _powerupKnockback = 15f;
    private float _lowerBound = -1f;

    private Rigidbody _playerRb;

    [SerializeField] private float _forwardForce;
    [SerializeField] GameObject _focalPoint;
    [SerializeField] GameObject _powerupIndicator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void Update() {
        _verticalInput = Input.GetAxis("Vertical");
        _powerupIndicator.transform.position = transform.position;
        CheckBound();

    }
    void FixedUpdate() {
        PlayerMovement();
    }

    void PlayerMovement() {
        Vector3 forwardDirection = _focalPoint.transform.forward;
        _playerRb.AddForce(forwardDirection * _forwardForce * _verticalInput);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            _isPowerupActive = true;
            _powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy") && _isPowerupActive) {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayDirection * _powerupKnockback, ForceMode.Impulse);
            Debug.Log("u are cooked");
        }
    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(_countdownDuration);
        _isPowerupActive = false;
        _powerupIndicator.SetActive(false);
    }
    void CheckBound() {
        if (transform.position.y <= _lowerBound) {
            GameManager.Singleton.GameOver();
        }
    }

}
