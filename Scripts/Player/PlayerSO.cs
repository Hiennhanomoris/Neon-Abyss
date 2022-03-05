using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player/Player Status", order = 0)]
public class PlayerSO : ScriptableObject 
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public int extraJump;
    public int currentJump;

    public int jumpForce;
    public int moveSpeed;
}
