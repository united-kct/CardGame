using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Timeline;
using UnityEngine.Playables;
public class Round : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private TextMeshProUGUI _round;
    private int _summonCount = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoundString() {
        switch(_summonCount) {
            case 0:
                _round.text = "ROUND";
                break;
            case 1:
                _round.text = "ROUN";
                break;
            case 2:
                _round.text = "ROU";
                break;
            case 3:
                _round.text = "RO";
                break;
            case 4:
                _round.text = "R";
                break;
            case 5:
                _round.text = "";
                break;
        }
        if (_summonCount >= 5) _summonCount = 0;
        _summonCount++;
    }

    

}
