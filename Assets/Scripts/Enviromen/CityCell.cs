using UnityEngine;

public class CityCell : MonoBehaviour
{
    private Vector2 _buildingSize;
    private float _scale;

    public void Init(float scale, Building building)
    {
        _scale = scale;
        transform.localScale = Vector3.one * scale / 10;
        BuildBuilding(building);
    }

    private void BuildBuilding(Building building)
    {
        _buildingSize = building.Size; 
        int rotation = Random.Range(0, 2);

        if (rotation == 1)
            _buildingSize = new Vector2(building.Size.y, building.Size.x);

        Vector3 point;
        point.x = Random.Range(_buildingSize.x / 2f, _scale - _buildingSize.x / 2f) - _scale / 2;
        point.z = Random.Range(_buildingSize.y / 2f, _scale - _buildingSize.y / 2f) - _scale / 2;
        point.y = 0;

        var _build = Instantiate(building, transform.position + point, rotation == 0 ? transform.rotation : Quaternion.Euler(0, 90, 0) * transform.rotation, transform);
        _build.transform.localScale /= (_scale / 10);
    }
}
