using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 8.0f;
    public VectorValue startingPosition;
    public int keys = 0;
    public TextMeshProUGUI keyAmount;
    public GameObject WinPanel; // Reference to the win panel

    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    private Vector2 lastMotionVector;

    public bool moving;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
        if (WinPanel != null)
        {
            WinPanel.SetActive(false); // Ensure the win panel is inactive at the start }
        }
    }

    private void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            lastMotionVector = new Vector2(change.x, change.y).normalized;
            animator.SetFloat("lastHorizontal", change.x);
            animator.SetFloat("lastVertical", change.y);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Keys"))
        {
            keys++;
            keyAmount.text = "Collected Stationeries: " + keys;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemies"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("Exit") && keys == 4)
        {
            WinPanel.SetActive(true); // Show the win panel
        }
    }
}
