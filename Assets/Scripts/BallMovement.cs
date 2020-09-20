using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    public float speed = 40f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    public AudioSource audioOnCollision;
    public Text gameStartText;

    private Rigidbody2D m_Rigidbody2D;
    private Vector3 targetVelocity;
    private Vector3 m_Velocity = Vector3.zero;

    public void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if (gameStartText == null)
        {
            gameStartText = GameObject.FindGameObjectWithTag("StartText").GetComponent<Text>();
        }
        gameStartText.enabled = true;
        MoveDown();
    }

    public void Update()
    {
        if ( m_Rigidbody2D.velocity.magnitude != speed)
        {
            targetVelocity = m_Rigidbody2D.velocity.normalized * speed;
            Move();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        audioOnCollision.Play();
    }

    public void MoveDown()
    {
        SetRandomTargetVelocityBetweenAngles(165, 196);
        m_Rigidbody2D.bodyType = RigidbodyType2D.Static;
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
        gameStartText.enabled = false;
        m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Move();
    }

    private void Move()
    {
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    private void SetRandomTargetVelocityBetweenAngles(int minAngle, int maxAngle)
    {
        float angle = Random.Range(minAngle, maxAngle) * Mathf.Deg2Rad;

        float x = Mathf.Sin(angle) * speed;
        float y = Mathf.Cos(angle) * speed;

        targetVelocity.x = x;
        targetVelocity.y = y;
    }

}
