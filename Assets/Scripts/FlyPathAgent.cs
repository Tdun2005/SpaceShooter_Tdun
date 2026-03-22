using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed = 3f;

    private int nextIndex = 1;

    void Start()
    {
        if (flyPath != null)
        {
            transform.position = flyPath[0];
        }
    }

    void Update()
    {
        if (flyPath == null) return;

        if (nextIndex >= flyPath.waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        if (Vector3.Distance(transform.position, flyPath[nextIndex]) > 0.05f)
        {
            FlyToNextWaypoint();
            LookAt(flyPath[nextIndex]);
        }
        else
        {
            nextIndex++;
        }
    }

    void FlyToNextWaypoint()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            flyPath[nextIndex],
            flySpeed * Time.deltaTime
        );
    }

    void LookAt(Vector2 destination)
    {
        Vector2 position = transform.position;
        Vector2 dir = destination - position;

        if (dir.magnitude < 0.01f) return;

        float angle = Vector2.SignedAngle(Vector2.down, dir);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}