using UnityEngine;

public class Donosauro1 : MonoBehaviour
{
    Rigidbody2D rb;
    public float fallSpeed;
    bool isFalling;
    public GameManager gm;
    float minY = -2.098552f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFalling = false;
    }

    void Update()
    {
        // ����������¼��Ҳ���������
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isFalling)
        {
            // ֱ�������ٶ�Ϊ�����ٶ�
            rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
            isFalling = true;
        }

        // ��� y �����Ƿ�С����Сֵ
        if (transform.position.y < minY)
        {
            // ���ý�ɫλ�õ� minY
            Vector3 newPosition = transform.position;
            newPosition.y = minY;
            transform.position = newPosition;
            // ֹͣ����
            isFalling = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFalling = false;

        if (collision.gameObject.tag == "Cactus")
        {
            gm.GameOver();
        }
    }
}