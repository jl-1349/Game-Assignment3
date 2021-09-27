using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacTween : MonoBehaviour
{
    public Transform Target { get; private set; }
    public Vector3 StartPosition { get; private set; }
    public Vector3 EndPosition { get; private set; }
    public float StartTime { get; private set; }
    public float Duration { get; private set; }

    public PacTween(Transform target, Vector3 startposition, Vector3 endposition, float time, float duration)
    {
        Target = target;
        StartPosition = startposition;
        EndPosition = endposition;
        StartTime = time;
        Duration = duration;
    }
}