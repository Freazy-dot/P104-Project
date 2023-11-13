using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float maxHealth = 100f;

    [SerializeField] // Make currentHealth public in the Inspector
    private float currentHealth;

    public Color greenColor = Color.green;
    public Color yellowColor = Color.yellow;
    public Color redColor = Color.red;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void SetHealth(float health)
    {
        currentHealth = health;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        slider.value = currentHealth / maxHealth;

        // Interpolate the color based on the health value.
        if (currentHealth >= 50f)
        {
            slider.fillRect.GetComponent<Image>().color = Color.Lerp(yellowColor, greenColor, (currentHealth - 50f) / 50f);
        }
        else
        {
            slider.fillRect.GetComponent<Image>().color = Color.Lerp(redColor, yellowColor, (currentHealth) / 50f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(10f);
        }
    }
}
