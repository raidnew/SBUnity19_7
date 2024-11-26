using System;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class MovingPlatform : MonoBehaviour, IGround
{
    private SliderJoint2D _slider;
    private Rigidbody2D _rb;

    public Vector2 Speed 
    {
        get
        {
            return _rb.velocity;
        }
    }

    private void Awake()
    {
        _slider = GetComponent<SliderJoint2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_slider.limitState == JointLimitState2D.UpperLimit)
            SwitchMoveDirection( -1 );
        else if (_slider.limitState == JointLimitState2D.LowerLimit)
            SwitchMoveDirection( 1);
    }

    private void SwitchMoveDirection(int direction)
    {
        JointMotor2D motor = _slider.motor;
        motor.motorSpeed = direction * Math.Abs(_slider.motor.motorSpeed);
        _slider.motor = motor;
    }

}
