
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;

    

    void Start()
    {
        target = waypoints[0];
    }

    
    void Update()
    {
        //this is used to get the distance between the 2 waypoints and calculate the distance between them
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //if ennemi will soon arrive to destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            //This flip is used to get the snake to flip toward the direction of the waypoints
            graphics.flipX = !graphics.flipX;
        }
    }
}
