using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UnityEvent OnGameStart = new UnityEvent();
    public UnityEvent OnFinalPuzzleCompleted = new UnityEvent();

    //[SerializeField] private Puzzle finalPuzzle;
    [SerializeField] private GameObject player;
    [SerializeField] private HealthSystem playerHealth;

    [SerializeField] private GameObject healthUICanvas;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private GameObject EndCutscene;
    [SerializeField] private PlayableDirector cutsceneDir;

    private void Start()
    {
        playerHealth.OnDead += GameOver;
        EndCutscene.SetActive(false);
        if (winUI != null)
        {
            winUI.SetActive(false);
        }
        //finalPuzzle.OnPuzzleCompleted.AddListener(GameCompleted);
    }

    public void StartGame()
    {
        healthUICanvas.SetActive(true);
        //Enable player movement
        //anything else needed in the game
    }

    public void GameCompleted()
    {
        Debug.Log("Game Completed!");
        OnFinalPuzzleCompleted.Invoke();
        healthUICanvas.SetActive(false);

        if (winUI != null) 
        {
            winUI.SetActive(true);
        }
        if(cutsceneDir != null)
        {
            EndCutscene.SetActive(true);
            cutsceneDir.Play();
            player.GetComponent<PlayerInput>().enabled = false;
            
        }

        //save progress
        //play cutscene
    }
    public void GameOver()
    {
        Debug.Log("Player Died. - Game Over");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        player.GetComponent<PlayerInput>().enabled = false;
        healthUICanvas.SetActive(false);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; 
    }
    public void RetryGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
