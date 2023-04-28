using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private int _moveSpeed = 10;
    float PosX;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        PosX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime * PosX);
    }
}
