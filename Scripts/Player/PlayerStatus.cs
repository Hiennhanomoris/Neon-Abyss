using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance;

    public PlayerSO playerStatus;

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

    public void TakeDamage(int amount)
    {
        if(playerStatus.currentHealth <= amount)
            Destroy(this.gameObject);
        else
        {
            playerStatus.currentHealth -= amount;
        }
    }
}
