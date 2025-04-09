using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float moveSpeed;

    public Transform cannon;
    public Transform fireballMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1f, 0f) * moveSpeed * Time.deltaTime);

        if (transform.position.x < fireballMax.transform.position.x)
        {
            transform.position = cannon.transform.position;
        }
    }
}
