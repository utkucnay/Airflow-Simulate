using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils 
{
    public static float Scale(in float OldMin, in float OldMax, in float NewMin, in float NewMax, in float OldValue)
    {

        float OldRange = OldMax - OldMin;
        float NewRange = NewMax - NewMin;
        float NewValue = ((OldValue - OldMin) * NewRange / OldRange) + NewMin;

        return NewValue;
    }
}
