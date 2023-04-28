using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform Player;

    [SerializeField] private float SmoothFollow = 0.125f;
    public Vector3 offset;

    void Start()
    {
        Vector3 PlayerFollow = Player.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 FixedDirection = Player.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, FixedDirection, SmoothFollow);
        transform.position = SmoothedPosition;

        transform.LookAt(Player);
    }
}
