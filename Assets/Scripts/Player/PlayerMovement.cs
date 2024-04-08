using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public float moveSpeed = 5.0f;
    private bool isFaceingLeft = true;

    public Animator animator;
    private string currentAnimation = "";



    void Update()
    {
        ProcessInputs();
    }
    void FixedUpdate()
    {


        Move();
        Flip();
        CheckAnimation();
    }

    void ProcessInputs()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        moveDirection = new Vector2(xInput, yInput).normalized;
    }


    void Move()
    {
        if (DialogueManager.isActive == true)
        {
            rb.velocity = Vector2.zero;//停止移动
            return;
        }


        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed *= 1.03f;
        }
        else
        {
            moveSpeed = 5.0f;
        }
    }

    void Flip()
    {
        if (DialogueManager.isActive == true)
        {
            return;
        }


        if (isFaceingLeft && moveDirection.x > 0f || !isFaceingLeft && moveDirection.x < 0f)
        {
            isFaceingLeft = !isFaceingLeft;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    //Animation
    void CheckAnimation()
    {
        if (moveDirection.x != 0f || moveDirection.y != 0f && !DialogueManager.isActive)
        {
            if (DialogueManager.isActive == true)
            {
                return;
            }

            ChangeAnimationState("Swim");
        }
        else
            ChangeAnimationState("Idle");
    }
    void ChangeAnimationState(string animation, float crossfade = 0.1f)
    {
        if (currentAnimation != animation) //current != target
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossfade);
        }
    }

}
