using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjTween : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Vector3 Rotation;
    public float Duration;
    public int _LoopCount;
    public LoopType Loop;

    public float LRDuation;
    [SerializeField] private Vector3 Strt_Direction;
    [SerializeField] private Vector3 End_Direction;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalRotate(Rotation, Duration, RotateMode.LocalAxisAdd).SetLoops(_LoopCount, Loop).SetEase(Ease.Linear);
        StartMovement();
        //transform.DOLocalMove(End_Direction, LRDuation, true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartMovement()
    {
        transform.DOLocalMove(End_Direction, LRDuation).OnComplete(() => RestartMovement());
    }
    public void RestartMovement()
    {
        transform.DOLocalMove(Strt_Direction, LRDuation).OnComplete(() => StartMovement());
    }
}