using UnityEngine;

public class TopWallBallReflector : MonoBehaviour
{
    public void OnCollisionStay2D(Collision2D collision)
    {
        var ball = collision.gameObject.GetComponent<BallMovement>();
        if (ball != null)
        {
            ball.MoveDown();
        }
    }
}
