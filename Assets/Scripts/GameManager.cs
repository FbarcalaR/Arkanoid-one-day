using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public int numberOfBalls;
    public Text gameOverText;
    public Image ballImage;

    private Image[] ballImages;
    private int lastEnabledBallImage;
    private int currentBallsRemaining;

    public void Awake()
    {
        InitializeData();
    }

    public void BallDestroyed()
    {
        currentBallsRemaining--;
        lastEnabledBallImage--;
        ballImages[lastEnabledBallImage].enabled = false;

        if (currentBallsRemaining > 0)
        {
            Instantiate(ball, transform.position, Quaternion.identity);
        }
        else
        {
            gameOverText.enabled = true;
            StartCoroutine(reloadScene());
        }
    }

    public IEnumerator reloadScene()
    {
        gameOverText.enabled = true;

        yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
        InitializeData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void InitializeData()
    {
        currentBallsRemaining = numberOfBalls;
        ballImages = new Image[numberOfBalls];
        lastEnabledBallImage = numberOfBalls;

        var ballImagePosition = ballImage.gameObject.transform.position;
        var sizeX = ballImage.sprite.rect.width;
        var canvas = ballImage.canvas;
        ballImages[0] = ballImage;

        for (int i = 1; i < numberOfBalls; i++)
        {
            ballImagePosition.x += sizeX;
            var newBallImage = Instantiate(ballImage, ballImagePosition, Quaternion.identity);
            newBallImage.transform.SetParent(canvas.transform);
            ballImages[i] = newBallImage;
        }
    }

}
