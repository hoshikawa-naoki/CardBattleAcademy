using UnityEngine;

public class move_chara : MonoBehaviour
{
    private float speed = 0.011f;
    private Animator animator;
    private Rigidbody2D rb;
    public RandomEncount randomEncount;
    public float speedThreshold = 0.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        randomEncount = FindObjectOfType<RandomEncount>(); // RandomEncount�̃C���X�^���X���擾����
    }

    void Update()
    {
        Vector2 pos = transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= speed;
        }

        float playerSpeed = rb.velocity.magnitude;

        if (playerSpeed > speedThreshold && randomEncount != null)
        {
            randomEncount.PlayerIsMoving(true);
        }
        else if (randomEncount != null)
        {
            randomEncount.PlayerIsMoving(false);
        }

        transform.position = pos;
    }

    public bool IsMoving()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // ���̃��\�b�h�i�ȗ��j
}
