﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    private Vector3 _startTouchPos, _currentPosPlayer, _targetPosPlayer, _startPosPlayer;
    private Camera _cam;
    [SerializeField]
    private float _lateralSpeed, _runningSpeed, _boosterAccelerationPercentage;
    [SerializeField]
    private float _horizontalLimit;

    private void Start()
    {
        _startPosPlayer = transform.position;
        _targetPosPlayer = transform.position;
        _cam = Camera.main;
    }
    private void Update()
    {
        if (TouchUtility.TouchCount > 0)
        {
            Touch touch = TouchUtility.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                _currentPosPlayer = transform.position;

                _startTouchPos = (_cam.transform.position - ((ray.direction) *
                        ((_cam.transform.position - transform.position).z / ray.direction.z)));
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

                if (_startTouchPos == Vector3.zero)
                {
                    _startTouchPos = (_cam.transform.position - ((ray.direction) *
                            ((_cam.transform.position - transform.position).z / ray.direction.z)));
                }

                _targetPosPlayer = _currentPosPlayer + ((_cam.transform.position - ((ray.direction) *
                        ((_cam.transform.position - transform.position).z / ray.direction.z))) - _startTouchPos);
            }
        }
        else
        {
            _targetPosPlayer = transform.position;
        }

    }
    private void FixedUpdate()
    {
        //if (GameStage.IsGameFlowe)
        //{
            Vector3 PosX = transform.position;
            PosX.x = CheckLimmit(_targetPosPlayer);
            transform.position = Vector3.MoveTowards(transform.position, PosX, _lateralSpeed);

            transform.Translate(Vector3.forward * _runningSpeed);
        //}
    }

    private float CheckLimmit(Vector3 target)
    {
        if (target.x > _startPosPlayer.x + _horizontalLimit)
        {
            target.x = _startPosPlayer.x + _horizontalLimit;
        }
        else if (target.x < _startPosPlayer.x - _horizontalLimit)
        {
            target.x = _startPosPlayer.x - _horizontalLimit;
        }
        return target.x;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position - Vector3.right * _horizontalLimit, transform.position + Vector3.right * _horizontalLimit);
    }
}
