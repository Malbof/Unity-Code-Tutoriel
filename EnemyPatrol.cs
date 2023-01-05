using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision = 20;

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
    //we use this method to make the player take the damage from the ennemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this condition take the component Player health and takeDamage used is the HealthBar script. If the ennemi enter in collision of the player he take  damage using (damageOnCollision)
        //from the ennemy
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }


}
