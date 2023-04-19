using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDView : MonoBehaviour
{
    public PlayerModel player;
    public Text text; // VIEW how is information displayed?

    // Update is called once per frame
    void Update()
    {
        // VIEW UPDATES ITSELF BASED ON MODEL
        text.text = $"{player.Health}/{player.maxHealth}";
    }
}
