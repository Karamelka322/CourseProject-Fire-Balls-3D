using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdate;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.BullerHit += OnBulletHit;
        }

        SizeUpdate?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BullerHit -= OnBulletHit;

        _blocks.Remove(hitedBlock);

        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3()
            {
                x = block.transform.position.x,
                y = block.transform.position.y - _towerBuilder.IndentPlatforms,
                z = block.transform.position.z
            };
        }

        SizeUpdate?.Invoke(_blocks.Count);
    }
}
