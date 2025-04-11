using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    private HealthSystem playerHealth;
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        playerHealth = PlayerInput.Instance.GetComponent<HealthSystem>();
        playerHealth.OnLifeChange += UpdateHealthText;
        playerHealth.OnDead += DisplayDeathScreen;
    }

    void DisplayDeathScreen()
    {
        //SET ACTIVE
    }

    void UpdateHealthText(float healthToDisplay)
    {
        healthText.text = "Health: " + healthToDisplay.ToString(/*"F2"*/);
    }
}
