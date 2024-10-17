using UnityEngine;
public enum ShapeType
{
    SPHERE, PLANE, HALFSPACE
}
public class PhysicsBody 
{
    public Vector3 vel = Vector3.zero;
    public Vector3 pos = Vector3.zero;
    public Vector3 rot;
    public float drag = 1.0f;
    public float mass = 1.0f;
    public float launchAngle = 30f;
    public float launchSpeed = 10f;
    public Vector3 launchVelocity;

    public ShapeType shapeType = ShapeType.SPHERE; 
    public bool isColliding = false;
    public float radius = 1.0f;
    public Vector3 normal = Vector3.up;
    public bool dynamic = true;
}

