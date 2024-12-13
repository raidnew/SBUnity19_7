using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarBackground : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _distance;
    [SerializeField] private bool _lockY;

    private Vector3 _startCameraPosition;
    private Vector3 _startPosition;
    private float _moveMultiplier;

    private void Awake()
    {
        _startCameraPosition = _camera.position;
        _startPosition = transform.position;

        _moveMultiplier = 1 - 1 / _distance;
    }

    private void Update()
    {
        Vector3 moveDelta = _camera.position - _startCameraPosition;
        if (_lockY) moveDelta.y = 0;
        transform.position = _startPosition + moveDelta * _moveMultiplier;
    }
}
