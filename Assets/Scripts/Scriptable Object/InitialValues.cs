using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InitialValues : ScriptableObject
{
    [SerializeField] private int sizeLevel = 0;
    [SerializeField] private int difficultLevel= 0;

    public int SizeValue
    {
        get { return sizeLevel; }
        set { sizeLevel = value; }
    }

    public int DifficultValue
    {
        get { return difficultLevel; }
        set { difficultLevel = value; }
    }


}
