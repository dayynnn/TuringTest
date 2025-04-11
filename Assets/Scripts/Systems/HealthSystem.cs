using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float currentHealth; // [SerializeField] for debugging purposes
    [SerializeField] private float maxHealth;
    [SerializeField] private TextMeshProUGUI healthValue;

    public Action<float> OnLifeChange; // no need to initiliase like UnityEvents
    public Action OnDead;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public float GetCurrentHealth() // Getter
    {
        return currentHealth;
    }

    public void IncreaseHealth(float toIncrease)
    {
        currentHealth += toIncrease;
        OnLifeChange?.Invoke(currentHealth);
    }

    public void DecreaseHealth(float toDecrease) 
    { 
        currentHealth -= toDecrease;
        OnLifeChange?.Invoke(currentHealth);
        UpdateHealthUI();

        if (currentHealth <= 0) OnDead?.Invoke();
    }

    private void UpdateHealthUI()
    {
        healthValue.text = currentHealth.ToString();
    }

}
