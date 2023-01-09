using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public Animator fadeSystem;

    //this method is used to get this fadeSystem reusable in any other scene and works for prefabs
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    //we check if the player is in collision with the door and we start the coroutine
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(loadNextScene());
        }   

    }

    //the Courentine is used to get the animation to be played well and to wait 1 second before loading the scene.
    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }
}
