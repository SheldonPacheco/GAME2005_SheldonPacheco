using UnityEngine;

public class PhysicsBody 
{
    public Vector3 vel = Vector3.zero;
    public Vector3 pos = Vector3.zero;
    public float drag = 1.0f;
    public float mass = 1.0f;
    public float launchAngle = 30f;
    public float launchSpeed = 10f;
    public Vector3 launchVelocity;
    public bool isColliding = false;
    public float radius = 1.0f;
}
