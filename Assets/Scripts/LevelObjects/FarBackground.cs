using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarBackground : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _distance;

    private Vector3 _startCameraPosition;
    private Vector3 _startPosition;
    private float _moveMultiplier;

    private void Awake()
    {
        _startCameraPosition = _camera.position;
        _startPosition = transform.position;

        _moveMultiplier = 1 / _distance;
    }

    private void Update()
    {
        transform.position = _startPosition + (_camera.position - _startCameraPosition) * _moveMultiplier;
    }
}
