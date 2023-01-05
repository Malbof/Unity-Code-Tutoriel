using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invicibilityTimeAfterHit = 3f;
    public float invicibilityFlashDelay = 0.2f;
    public bool isInvincible = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;


    void Start()
    {
        //We set the player health at the beggining using MaxHealth and we store it in current health variable.
        //we set the maxhealth in the health bar using the methos used in the HealthBar Script
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        //We take 20 damage every time we input the key H.
                 if (Input.GetKeyDown(KeyCode.H))
                {
                    TakeDamage(20);
                }
    }

    //this method is used to update the player and make him take damage
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            //we update the player health using this variable
            currentHealth -= damage;
            //or currentHealth = currentHealth - damage;
            //we update the health bar on the player from the variable that we updated up
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }


    public IEnumerator InvicibilityFlash()//This method is used to get the player changing of oppacity (to show that he is invincible) yield return is used to
                                          //wait between each change of animation
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()// this method is used to after X time set the invicibility to false Again.
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvincible = false;
    }
}
