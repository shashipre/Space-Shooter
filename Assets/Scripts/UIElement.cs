using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIElement : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI textMeshPro;
    ScoreCard ScoreCard;
    [SerializeField] Health playerhealth;
    [SerializeField] Slider Health;

    private void Awake()
    {
        ScoreCard = FindObjectOfType<ScoreCard>();
    }
    void Start()
    {
        Health.maxValue = playerhealth.GetHealth();
        
    }

    void Update()
    {
        int score = ScoreCard.GetScore();
        textMeshPro.text = score.ToString("000000000");
        Health.value =  playerhealth.GetHealth();
    }
}
