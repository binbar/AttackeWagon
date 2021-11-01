
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DepthSortByY : MonoBehaviour
{
    private Renderer renderer;
    private const int IsometricRangePerYUnit = 100;
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        renderer.sortingOrder = -(int)(transform.position.y * IsometricRangePerYUnit);
    }
}