using UnityEngine;
using System.Collections;

public class DinoControll : MonoBehaviour
{
    [SerializeField]private float speed = 10f;
    [SerializeField]private int hp = 100;
    [SerializeField]private GameObject nextUI;

    [SerializeField] private float invincibleTime = 3f;

    private bool isInvincible = false;
    private Vector3 targetPos;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
    }

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
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isInvincible)
        {
            Enemy enemy = other.GetComponent<Enemy>();

            TakeDamage(enemy.getDamage());
            StartCoroutine(InvincibleRoutine());
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
        Time.timeScale = 0f;
        gameObject.SetActive(false);
        nextUI.SetActive(true);
    }


    IEnumerator InvincibleRoutine()
    {
        isInvincible = true;

        float endTime = Time.time + invincibleTime;

        while (Time.time < endTime)
        {
            SetAlpha(0.3f);
            yield return new WaitForSeconds(0.2f);

            SetAlpha(1f);
            yield return new WaitForSeconds(0.2f);
        }

        SetAlpha(1f);
        isInvincible = false;
    }

    void SetAlpha(float alpha)
    {
        if (sr != null)
        {
            Color c = sr.color;
            c.a = alpha;
            sr.color = c;
        }
    }

}