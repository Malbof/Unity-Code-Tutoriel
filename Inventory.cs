using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;

    public static Inventory instance;

    //We check if there is already an instance: if one instance is open we send a message in the debug if not we show the instance
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("They are more than one instance of Inventory in the scene");
            return;
        }

        instance = this;
    }

    // This method is to add coin, we addition one coin then we added to the coins count text.
    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }
}
