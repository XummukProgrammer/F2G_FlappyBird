using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Resource _moneyResource;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private float _jumpForce = 1;

    public Character Character => _character;
    public Resource MoneyResource => _moneyResource;

    private bool _isStopped = false;

    public bool IsStopped => _isStopped;

    public void SetIsStop(bool isStop)
    {
        _isStopped = isStop;
        _rigidBody2D.bodyType = isStop ? RigidbodyType2D.Static : RigidbodyType2D.Dynamic;
    }

    public void SetMoney(int money)
    {
        _moneyResource.AddValue(money, true);
    }

    public void OnBirdJumped()
    {
        var velocity = Vector2.up * _jumpForce;
        _rigidBody2D.velocity = velocity;
    }
}
