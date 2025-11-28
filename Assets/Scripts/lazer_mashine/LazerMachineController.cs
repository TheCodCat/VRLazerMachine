using System;
using UnityEngine;

public class LazerMachineController : MonoBehaviour
{
    [SerializeField] private Vector2 maxpositions;
    [SerializeField] private Transform center;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        var pointx1 = new Vector3(center.position.x + (maxpositions.x / 2), center.position.y, center.position.z + (maxpositions.y / 2));
        var pointy1 = new Vector3(center.position.x + (maxpositions.x / 2), center.position.y, center.position.z + (-maxpositions.y / 2));
        var pointx2 = new Vector3(center.position.x + (-maxpositions.x / 2), center.position.y, center.position.z + (-maxpositions.y / 2));
        var pointy2 = new Vector3(center.position.x + (-maxpositions.x / 2), center.position.y, center.position.z + (maxpositions.y / 2));

        var points = new Vector3[]
        {
            pointx1,
            pointy1,
            pointx2,
            pointy2
        };
        ReadOnlySpan<Vector3> vector3s = new ReadOnlySpan<Vector3>(points);

        Gizmos.DrawLineList(vector3s);
    }
}
