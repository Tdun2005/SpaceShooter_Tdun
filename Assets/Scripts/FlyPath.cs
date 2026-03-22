using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public Transform[] waypoints;

    // cho phép truy cập kiểu array
    public Vector3 this[int index] => waypoints[index].position;

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;

        Gizmos.color = Color.green;

        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(
                waypoints[i].position,
                waypoints[i + 1].position
            );
        }
    }
}