using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDView : MonoBehaviour
{
    public PlayerModel player;
    public Text text; // VIEW how is information displayed?

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
        text.text = $"{player.Health}/{player.MaxHealth}";
    }
}
