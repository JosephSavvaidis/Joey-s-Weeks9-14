using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // The player's sprite
    public SpriteRenderer player;
    // The fireball's sprite
    public SpriteRenderer fireBall;

    // Button reference for parrying
    public Button parryButton;

    // Tracks if the player can be hit
    private bool canHit;
    // The player’s health
    private int health;
    // Controls if the player is allowed to be hit (used alongside canHit)
    public bool canCanHit;

    // Animator for health
    public Animator healthAnim;
    // Animator for the player character
    public Animator playerAnim;

    // Reference to the Fireball script
    public Fireball fb;

    // Particle system for effects
    public ParticleSystem ps;

    // Called once at the start
    void Start()
    {
        // Listen to Fireball events (scoreCollect)
        fb.scoreCollect.AddListener(PlayFire);
        fb.scoreCollect.AddListener(StopAblePressCoolDown);

        // Initialize health
        health = 3;
        // At the start, the player can be hit
        canCanHit = true;
    }

    // Plays the particle effect
    public void PlayFire()
    {
        ps.Play();
    }

    // Called once per frame
    void Update()
    {
        // Check if the player sprite overlaps with the fireball
        if (player.bounds.Intersects(fireBall.bounds))
        {
            // Only reduce health if both booleans allow it
            if (canHit && canCanHit)
            {
                // Subtract one health
                health -= 1;
                // Temporarily stop being able to hit the player
                canHit = false;
                // Trigger an animation state
                playerAnim.SetInteger("State", 1);

                // Log current health
                Debug.Log(health);
            }

            // Update the health animation with the current health value
            healthAnim.SetInteger("Health", health);
        }
        else
        {
            // If not colliding, reset canHit so the player can be hit again
            canHit = true;
        }
    }

    // Stops the coroutine that controls the parry button cooldown
    public void StopAblePressCoolDown()
    {
        StopCoroutine(AbleToPressButton());
    }

    // Called when the Parry button is pressed
    public void Parry()
    {
        // Start the parry cooldown routine
        StartCoroutine(AbleToPressButton());
        // Allow hits again
        canCanHit = true;
        // End dodge animation
        playerAnim.SetBool("Dodge", false);
        // Reactivate parry button
        parryButton.enabled = true;
    }

    // Handles timing around the parry action
    public IEnumerator AbleToPressButton()
    {
        // Start dodge animation
        playerAnim.SetBool("Dodge", true);
        // Disable parry button to prevent repeated presses
        parryButton.enabled = false;
        // Wait before allowing hits
        yield return new WaitForSeconds(1.8f);
        canCanHit = true;
        // End dodge animation
        playerAnim.SetBool("Dodge", false);
        // Wait a bit more
        yield return new WaitForSeconds(0.7f);
        // Enable parry button again
        parryButton.enabled = true;
    }
}
