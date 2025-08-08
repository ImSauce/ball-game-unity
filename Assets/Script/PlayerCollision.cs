using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public movement_script movement;
    void OnCollisionEnter(Collision collisionInfo) {

        
        
        if (collisionInfo.collider.tag == "Obstacle")
        Debug.Log("hit");

        //movement.enabled =false;

    }
}
