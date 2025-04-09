using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer player;
    public SpriteRenderer fireBall;

    public Button parryButton;

    private bool canHit;
    private int health;
    public bool canCanHit;

    public Animator healthAnim;
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        canCanHit = true;
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
                playerAnim.SetInteger("State", 1);
                
                    Debug.Log(health);
                
            }
            healthAnim.SetInteger("Health", health);
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
    public IEnumerator AbleToPressButton()
    {
        playerAnim.SetBool("Dodge", true);
        parryButton.enabled = false;
        yield return new WaitForSeconds(1.8f);
        canCanHit = true;
        playerAnim.SetBool("Dodge", false);
        yield return new WaitForSeconds(0.7f);
        parryButton.enabled = true;
        

    }
    
}
