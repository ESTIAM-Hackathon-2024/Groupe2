using UnityEngine;
using UnityEngine.SceneManagement;

public class GameQuitController : MonoBehaviour
{
    public string sceneToLoad = "Menu"; 

    public KeyCode quitKey = KeyCode.Escape; 

    void Update()
    {
        if (Input.GetKeyDown(quitKey))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        if (GameManager.inst != null)
        {
            GameManager.inst.SaveScore();
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}

