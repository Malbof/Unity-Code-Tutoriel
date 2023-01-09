using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    //this method is used to update the plauer spawn position after changing level so or he will spawn at the same position as the he was at the level before
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
