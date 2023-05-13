using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _jumpForce = 1;

    public void OnBirdJumped()
    {
        var velocity = Vector2.up * _jumpForce;
        _rigidBody2D.velocity = velocity;
    }
}
