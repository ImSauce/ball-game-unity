using UnityEngine;

public class slam : MonoBehaviour
{
    public AudioSource sound;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void Update() { }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") { 
            sound.Play();
        }
    }
}
