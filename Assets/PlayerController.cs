using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer fireBall;

    public TextMeshProUGUI parryButton;

    private bool canHit;
    private int health;
    public bool canCanHit;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.bounds.Intersects(fireBall.bounds))
        {
            if(canHit == true && canCanHit == true)
            {
                
                    health -= 1;
                    canHit = false;
                    Debug.Log(health);
                
            }
        }
        else
        {
            
            canHit = true;
        }
        
    }
    public void Parry()
    {
        canCanHit = false;
        StartCoroutine(AbleToPressButton());
    }
    IEnumerator AbleToPressButton()
    {
        parryButton.enabled = false;
        yield return new WaitForSeconds(2f);
        canCanHit = true;
        parryButton.enabled = true;
    }
}
