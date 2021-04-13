using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweemShoots;
    [SerializeField] private float _recoiDistance;

    private float _timeAfterShoot;

    private bool _isAttack;
    public bool IsAttack
    {
        set { _isAttack = value; }
    }

    private void Start()
    {
        _isAttack = true;
    }

    private void Update()
    {
        if (!_isAttack)
            return;

        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(_timeAfterShoot > _delayBetweemShoots)
            {
                Shot();
                transform.DOMoveZ(transform.position.z - _recoiDistance, _delayBetweemShoots / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoot = 0;
            }
        }
    }

    private void Shot()
    {
        Instantiate(_bulletTemplate, _shotPoint.position, Quaternion.identity);
    }
}
