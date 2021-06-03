using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health_final : MonoBehaviour
{
    public Slider healthSlider;
    public Image damageImage;

    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    [SerializeField]
    private int startingHealth = 5;

    private int currentHealth;
    private const int MAX_HEALTH = 5;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("Demaged check");
        currentHealth -= damageAmount;
        
        healthSlider.value = currentHealth;

        animator.SetTrigger("Damaged");

        if(currentHealth== 4)
            damageImage.color = new Color(1f, 0f, 0f, 0.01f);
        if (currentHealth == 3)
            damageImage.color = new Color(1f, 0f, 0f, 0.05f);
        if (currentHealth == 2)
            damageImage.color = new Color(1f, 0f, 0f, 0.1f); ;
        if (currentHealth == 1)
            damageImage.color = new Color(1f, 0f, 0f, 0.2f); ;


        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 1.5f);

        SceneManager.LoadScene(1);
    }

    public void EatFood()
    {
        if(currentHealth <= MAX_HEALTH)
        {
            currentHealth = MAX_HEALTH;
        }
        healthSlider.value = currentHealth;
        damageImage.color = Color.clear;
        Debug.Log(currentHealth);
    }

}
