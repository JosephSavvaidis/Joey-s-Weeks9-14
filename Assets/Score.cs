using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Score : MonoBehaviour
{
    // Tracks the players score
    public int score;

    // UI text element to display the score
    public TextMeshProUGUI textPro;

    // A particle sysem to play effects
    public ParticleSystem system;

    // Reference to the Fireball script
    public Fireball fb;

    private void Start()
    {
        // Subscribe to the Fireball event to play the article efect when it fires
        fb.scoreCollect.AddListener(PlayTheParty);
    }

    // Increases the score by 1 and updates the text
    public void ScorePlus()
    {
        score += 1;
        textPro.text = "" + score;
    }

    // Resets the score to 0 and updates the text
    public void ScoreZero()
    {
        score = 0;
        textPro.text = "" + score;
    }

    // Plays the partice system effect
    public void PlayTheParty()
    {
        system.Play();
    }
}
