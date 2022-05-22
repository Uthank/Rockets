using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2 _size;

    public Vector2 Size => _size;
}
