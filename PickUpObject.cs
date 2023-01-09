using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //we check if the tag Player get in collision with the object (the coin) we add one coins in the inventory and we destroy this object
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoins(1);
            Destroy(gameObject);

        }
    }
}
