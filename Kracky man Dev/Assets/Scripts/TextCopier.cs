using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCopier : MonoBehaviour
{
    [SerializeField]
    private Text finalScore;
    [SerializeField]
    private Text score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = score.text;
    }
}
