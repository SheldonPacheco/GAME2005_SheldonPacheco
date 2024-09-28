using UnityEngine;

public class Launch : MonoBehaviour
{
    public GameObject projectile;
    public float launchAngle = 30f;
    public float launchSpeed = 10f;
    Vector3 launchVelocity;
    Vector3 acc = Physics.gravity;
    Vector3 vel;
    Vector3 pos;
    private Vector3 projectilePosition;

    void Start()
    {
        
        launchVelocity = new Vector3(Mathf.Cos(launchAngle * Mathf.Deg2Rad) * launchSpeed, Mathf.Sin(launchAngle * Mathf.Deg2Rad) * launchSpeed, 0f);
        pos = projectile.transform.position;

        projectilePosition = pos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Relaunch();
        }

        float dt = Time.deltaTime;
        vel += acc * dt;
        pos += vel * dt;

        if (pos.y <= 0.0f)
        {
            vel.y = -vel.y;
            pos.y = 0.0f;
        }

        projectile.transform.position = pos;

        if (pos.x >= 12.0f) {
            pos = projectilePosition;
            vel = Vector3.zero;
        }

        Debug.DrawLine(projectilePosition, projectilePosition + launchVelocity, Color.yellow);
    }

    void Relaunch()
    {
        vel = launchVelocity;
    }
}
