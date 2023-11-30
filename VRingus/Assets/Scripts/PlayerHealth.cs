using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField, Tooltip("How many hitpoints the player has.")]
    private int health;
    [SerializeField, Tooltip("How long the player can't be damaged for.")]
    private float hitDelay = 5;
    private float timer = 0.0f;

    [Header("Death Settings")]
    [SerializeField, Tooltip("GameObject with the Death Animation.")]
    private GameObject DeathAnimation = null;
    private bool deathAnimationStarted = false;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (health <= 0)
            GameOver();
    }

    public void HitPlayer()
    {
        if (timer > hitDelay)
        {
            health--;
            timer = 0.0f;
        }
    }

    void GameOver()
    {
        //Game Over Script
        if (DeathAnimation != null)
        {
            DeathAnimation.SetActive(true);
            PlayableDirector playableDirector = DeathAnimation.GetComponent<PlayableDirector>();

            if (!deathAnimationStarted)
            {
                DeathAnimation.GetComponent<PlayableDirector>().Play();
                deathAnimationStarted = true;
            }
            else if (playableDirector.state != PlayState.Playing)
            {
                SceneManager.LoadScene(0);
            }
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
