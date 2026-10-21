using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLineMover : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _characterModelTransform;
    
    [SerializeField] private PlayerConfig _playerConfig;
    
    private int _currentLaneIndex = 1;
    
    private float _verticalVelocity;

    private void OnEnable()
    {
        PlayerSwipeInput.OnHorizontalSwipe += CurrentLaneChange;
        PlayerSwipeInput.OnSwipeUp += TryJump;
    }

    private void OnDisable()
    {
        PlayerSwipeInput.OnHorizontalSwipe -= CurrentLaneChange;
        PlayerSwipeInput.OnSwipeUp -= TryJump;
    }

    private void Update()
    {
        ApplyGravity();
        Move();
    }

    private void Move()
    {
        float horizontalMove = CalculateHorizontalMove();
        
        Vector3 move = new Vector3(horizontalMove, _verticalVelocity *  Time.deltaTime, 0f);
        
        _characterController.Move(move);
        _animator.SetBool("IsGrounded", _characterController.isGrounded);
    }
    
    private void ApplyGravity()
    {
        if(_characterController.isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = -2f;
        }

        _verticalVelocity += _playerConfig.Gravity * Time.deltaTime;
    }
    
    private void TryJump()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(_playerConfig.JumpHeight * -2f * _playerConfig.Gravity);
            _animator.SetTrigger("Jump");
        }
    }
    
    private float CalculateHorizontalMove()
    {
        float currentX = transform.position.x;
        float targetX = _playerConfig.LaneXPositions[_currentLaneIndex];

        float nextX = Mathf.MoveTowards(currentX, targetX, _playerConfig.LaneChangeSpeed * Time.deltaTime);

        return nextX - currentX;
    }

    private void CurrentLaneChange(int  direction)
    {
        if (direction == 0)
        {
            _currentLaneIndex--;
        }
        else if (direction == 1)
        {
            _currentLaneIndex++;
        }
        
        _currentLaneIndex = Mathf.Clamp(_currentLaneIndex, 0, _playerConfig.LaneXPositions.Length - 1);
    }
}
