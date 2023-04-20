using Core.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Core.View
{
    public interface IBackend
    {
        void PostScore(int score);
        int GetScore();
    }

    public interface IItemGenerator
    {
        Item CreateItem(string id);
    }

    public interface DummyItemGenerator : IItemGenerator
    {
        public Item itemPrefab;
        public Item CreateItem(string id)
        {
            return Object.Instantiate(itemPrefab);
        }
    }

    class Shop
    {
        Singletons.ItemGenerator.CreateItem("Dagger");
    }

    public class DummyBackend : IBackend
    {
        private string PlayerPrefKey => $"{nameof(DummyBackend)}.Score";
        public void PostScore(int score)
        {
            Debug.Log($"Dummy Backend Post Score {score}");
            PlayerPrefs.SetInt(PlayerPrefKey, score);
        }

        public int GetScore()
        {
            Debug.Log($"Dummy Backend Get Score");
            return PlayerPrefs.GetInt(PlayerPrefKey);
        }
    }
    
    /// <summary>
    /// Used to display Player Stats as Text in the HUD
    /// </summary>
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
}
