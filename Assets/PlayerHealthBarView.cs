using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarView : MonoBehaviour
{
    public PlayerModel player;
    public Image image; // VIEW how is information displayed?

    // OBSERVER DESIGN PATTERN
    // The VIEW OBSERVES changes on the MODEL
    // instead of checking for updates every UPDATE
    
    void OnEnable()
    {
        player.HealthChanged.AddListener(OnPlayerHealthChanged);
        player.HealthChanged.AddListener(OnPlayerMaxHealthChanged);
        UpdateHealthView();
    }
    
    void OnDisable()
    {
        player.HealthChanged.RemoveListener(OnPlayerHealthChanged);
        player.HealthChanged.RemoveListener(OnPlayerMaxHealthChanged);
    }

    public void OnPlayerHealthChanged(int newHealth)
    {
        UpdateHealthView();
    }
    
    public void OnPlayerMaxHealthChanged(int newMaxHealth)
    {
        UpdateHealthView();
    }
    
    void UpdateHealthView()
    {
        // VIEW UPDATES ITSELF BASED ON MODEL
        image.fillAmount = (float)player.Health / player.MaxHealth;
    }

    private void LateUpdate()
    {
        //transform.position = player.transform.position + new Vector3(0, 1, 0);
    }
}
