using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] private Vector2Int _fieldOfView;
    [SerializeField] private Building[] _buildings;
    [SerializeField] private float _buildingCellScale;
    [SerializeField] private CityCell _cityCell;
    [SerializeField] private Player _player;
    [SerializeField] private CellLine _cellLine;

    private readonly Queue<CellLine> _city = new Queue<CellLine>();
    private float _playerFarnessBreakpoint;

    private void Awake()
    {
        for (var i = 0; i < _fieldOfView.y; i++)
        {
            CellLine cellLine = Instantiate(_cellLine,new Vector3(0, 0, _buildingCellScale * i),Quaternion.identity, transform);
            
            for (int j = 0; j < _fieldOfView.x; j++)
            {
                var position = new Vector3(-_buildingCellScale * _fieldOfView.x / 2 + _buildingCellScale * j, 0, cellLine.transform.position.z);
                CityCell cell = Instantiate(_cityCell, position, Quaternion.identity, cellLine.transform);
                cell.Init(_buildingCellScale, _buildings[Random.Range(0, _buildings.Length)]);
            }
            
            _city.Enqueue(cellLine);
        }

        _playerFarnessBreakpoint = _buildingCellScale;
    }

    private void Update()
    {
        if (_player.transform.position.z > _playerFarnessBreakpoint)
        {
            var cellLine = _city.Dequeue();
            cellLine.transform.position = new Vector3(0, 0, cellLine.transform.position.z + _buildingCellScale * _fieldOfView.y);
            _city.Enqueue(cellLine);
            _playerFarnessBreakpoint += _buildingCellScale;
        }
    }
}
