
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    //this Game Object Add a box to what we wanna destroy .
    public GameObject objectToDestroy;

    //This method is used to destroy the ennemi but the only condition if that its destroy from a tag Player.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(objectToDestroy);
        }
    }
}
