using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsDone(PlayableDirector director) {
        Debug.Log(director.time + "," + director.duration);
        return Math.Round(director.time,2,MidpointRounding.AwayFromZero) >= Math.Round(director.duration,2,MidpointRounding.AwayFromZero);
    }
}
