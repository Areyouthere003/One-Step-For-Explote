using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreValue : ScriptableObject
{
    [SerializeField] int _scoreValue;
    [SerializeField] string _totalTime;

    public int Score
    {
        get { return _scoreValue; }
        set { _scoreValue = value; }
    }

    public string TotalTime
    {
        get { return _totalTime; }
        set { _totalTime = value; }
    }
}
