using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System;

public class Round_Timeline : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;

    
    // Start is called before the first frame update
    void Start()
    {
        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDone() {
        return Math.Round(director.time,2,MidpointRounding.AwayFromZero) >= Math.Round(director.duration,2,MidpointRounding.AwayFromZero);
    }

    public void TimelinePlay() {
        director.Play();
    }
}
