using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UserName;

    [SerializeField] private TextMeshProUGUI ScoreValue;


    public void SetUserName(string userName)
    {
        UserName.text = userName;
    }
    
    public void SetScoreValue(string scoreValue)
    {
        ScoreValue.text = scoreValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
