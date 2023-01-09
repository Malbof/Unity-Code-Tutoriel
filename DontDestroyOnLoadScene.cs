using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;

    //this method use the array gameObject to stock the object that we want to conservate from level to another (Camera-Inventory-Canvas etc).
    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }

    }

   
}
