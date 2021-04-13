using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private PlayerDead _playerDead;

    private void Awake()
    {
        _playerDead = FindObjectOfType<PlayerDead>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            _playerDead.Dead();
        }
    }
}
