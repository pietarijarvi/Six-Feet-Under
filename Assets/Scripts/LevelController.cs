using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// LevelController changes scene of the game after certain triggers
/// </summary>
public class LevelController : MonoBehaviour {

    /// <summary>
    /// Starts the actual game
    /// </summary>
	public void StartGame()
    {
        //Loads the scene called "Level"
        SceneManager.LoadScene("Level");
        ScoreBoard.scoreCount = 0;
    }
    /// <summary>
    /// Takes the player to the Game Over screen after they hit an obstacle or fall off the screen
    /// </summary>
    public void GameOver()
    {
        //Loads the scene called "GameOver"
        SceneManager.LoadScene("GameOver");
    }
    /// <summary>
    /// Quits the game completely
    /// </summary>
    public void Quit()
    {
        //Closes the application
        Application.Quit();
    }
}
