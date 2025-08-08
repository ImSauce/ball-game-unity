using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 3f;


    public GameObject LevelComplete;


    public void CompleteLevel() {
        Debug.Log("YOU WIN");
        LevelComplete.SetActive(true);


    }

    public void EndGame() {

        if (gameHasEnded == false) {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }

    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }
}
