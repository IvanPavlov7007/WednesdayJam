using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    Slider healthBar;

    public static HealthManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        healthBar = FindObjectOfType<Slider>();
    }

    void Update()
    {
        healthBar.value = currentHealth / maxHealth;
    }
}
