using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance;

    public PlayerSO playerStatus;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }    
        Instance = this;
    }

    public int getCurrentHealth()
    {
        return playerStatus.currentHealth;
    }

    public void setCurrentHealth(int amount)
    {
        playerStatus.currentHealth = amount;
    }

    public int getMaxHealth()
    {
        return playerStatus.maxHealth;
    }

    public int getMoveSpeed()
    {
        return playerStatus.moveSpeed;
    }

    public void setMoveSpeed(int amount)
    {
        playerStatus.moveSpeed = amount;
    }

    public int getJumpForce()
    {
        return playerStatus.jumpForce;
    }

    public void setJumpForce(int amount)
    {
        playerStatus.jumpForce = amount;
    }

    public int getCurrentJump()
    {
        return playerStatus.currentJump;
    }

    public void setCurrentJump(int amount)
    {
        playerStatus.currentJump = amount;
    }

    public int getExtraJump()
    {
        return playerStatus.extraJump;
    }

    public void setExtraJump(int amount)
    {
        playerStatus.extraJump = amount;
    }

    public int getDamage()
    {
        return playerStatus.damage;
    }

    public void setDamage(int amount)
    {
        playerStatus.damage = amount;
    }

    public void TakeDamage(int amount)
    {
        if(playerStatus.currentHealth <= amount)
            Destroy(this.gameObject);
        else
        {
            playerStatus.currentHealth -= amount;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy"))
            TakeDamage(other.gameObject.GetComponent<EnemyAbstract>().damage);  
        if(other.CompareTag("Enemy2 Bullet"))
            TakeDamage(1);  
    }

    private void Update() 
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < getCurrentHealth())
                hearts[i].sprite = fullHeart;
            else hearts[i].sprite = emptyHeart;
        }    
    }
}
