using UnityEngine;

public class DinoControll : MonoBehaviour
{
    [SerializeField]private float speed = 10f;
    [SerializeField]private int hp = 3;

    private Vector3 targetPos;

    void Update()
    {
        // 터치
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;

            targetPos = touchPos;
        }

        // 테스트용(마우스)
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            targetPos = mousePos;
        }

        // 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

     public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("HP: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("죽음");
        gameObject.SetActive(false);
    }

}