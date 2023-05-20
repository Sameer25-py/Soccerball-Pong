using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public  float       Speed = 1f;
    private Rigidbody2D _rb2D;
    private Vector2     _direction;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void OnEnable()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _direction = new Vector2(
            Random.Range(-1f, 1f),
            Random.Range(-1, 2)
        );
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _direction = Vector2.Reflect(_direction, col.contacts[0]
                .normal)
            .normalized;
    }


    private void Update()
    {
        _rb2D.position += _direction * (Time.deltaTime * Speed);
    }
}