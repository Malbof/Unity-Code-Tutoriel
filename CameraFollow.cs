
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float timeOffset;
    public Vector3 posOffSet;

    private Vector3 velocity;

    //this is Used to get the camera to follow the player on the 2d plan
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSet, ref velocity, timeOffset);
    }
}
