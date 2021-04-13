using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [Space]
    [SerializeField] private Color _colorOne;
    [SerializeField] private Color _colorTwo;

    private List<Block> _blocks;

    private readonly float _indentPlatforms = 0.78f;

    public float IndentPlatforms => _indentPlatforms;

    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform currentPoint = _buildPoint;

        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(i % 2 == 0? _colorOne : _colorTwo);
            _blocks.Add(newBlock);

            currentPoint = newBlock.transform;
        }

        return _blocks;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuilderPoint(currentBuildPoint), Quaternion.Euler(-90, 0, 0), _buildPoint);
    }

    private Vector3 GetBuilderPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + _indentPlatforms, _buildPoint.position.z);
    }
}
