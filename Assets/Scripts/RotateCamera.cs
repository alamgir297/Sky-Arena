using UnityEngine;

public class RotateCamera : MonoBehaviour {
    [SerializeField] private float _rotationSpeed;
    //[SerializeField] private float _forwardSpeed;
    private float _horizontaInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        RotateHorizontal();
    }

    void RotateHorizontal() {
        _horizontaInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * _horizontaInput * _rotationSpeed * Time.deltaTime);
    }
}
