using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public movement_script movement;
    public int health = 3;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            if (health > 0)
            {
                Debug.Log("hit");
                health -= 1;

                if (health <= 0)
                {
                    movement.enabled = false;
                    FindObjectOfType<GameManager>().EndGame();
                }
            }
        }
    }
}
