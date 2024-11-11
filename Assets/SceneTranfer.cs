using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranfer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered portal trigger"); // This will print to the console if the trigger is detected
        SceneManager.LoadScene("JarrettFight");
    }

}
