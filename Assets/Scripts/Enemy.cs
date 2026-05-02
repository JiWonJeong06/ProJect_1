using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    [SerializeField]private int hp = 100;
    [SerializeField]private int damage = 30;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int getDamage(){
        return damage;
    }

    public void ApplyLevel(int level)
    {
        hp += 25 * level;
        damage += 10 * level;
    }
}