using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacTweener : MonoBehaviour
{
    private PacTween activePacTween;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(activePacTween.Target.position, activePacTween.EndPosition) > 0.1f)
        {
            float timeCut = (Time.time - activePacTween.StartTime) / activePacTween.Duration;
            timeCut = timeCut * timeCut * timeCut;
            activePacTween.Target.position = Vector3.Lerp(activePacTween.StartPosition, activePacTween.EndPosition, timeCut);

        }
        else
        {
            activePacTween.Target.position = activePacTween.EndPosition;
            activePacTween = null;
        }
    }

    public void AddTween(Transform targetObject, Vector3 StartPosition, Vector3 EndPosition, float duration)
    {
        if (activePacTween == null)
        {
            activePacTween = new PacTween(targetObject, StartPosition, EndPosition, Time.time, duration);
        }
    }
}
