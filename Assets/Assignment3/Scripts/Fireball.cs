using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fireball : MonoBehaviour
{
    // How fast the fireball moves horizontally
    public float moveSpeed;

    // Positions where the fireball starts and where it resets
    public Transform cannon;
    public Transform fireballMax;

    // Event called when the fireball resets
    public UnityEvent scoreCollect;

    void Start()
    {
        // No setup needed here for now
    }

    void Update()
    {
        // Move the firball to the right every frameeeeeeeeeeeeee
        transform.Translate(new Vector2(1f, 0f) * moveSpeed * Time.deltaTime);

        // If the fireball goes past the fireballMax point...
        if (transform.position.x < fireballMax.transform.position.x)
        {
            //reset it to the cannon's position
            transform.position = cannon.transform.position;
            // Trigger the event that soething has happened (e.g., score increase)
            scoreCollect.Invoke();
        }
    }
}