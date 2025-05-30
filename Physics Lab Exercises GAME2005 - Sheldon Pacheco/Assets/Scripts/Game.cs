using System.Runtime.CompilerServices;
using UnityEngine;

public class Game : MonoBehaviour
{
    PhysicsSystem physicsSystem;
    int launchIndex = 0;
    public float fixedTimeStep = 0.03f; 
    private float totalTime = 0.0f;
    
    void Start()
    {
        
        physicsSystem = new PhysicsSystem(this);
        
        for (int i = 0; i < 5; i++)  
        {
            AddSphere();
        }
        AddFloor();
        AddHalfspace();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Relunach();
        }

        totalTime += Time.deltaTime;

        
        while (totalTime >= fixedTimeStep)
        {
            physicsSystem.Step(fixedTimeStep);
            totalTime -= fixedTimeStep; 
        }
    }
    void OnDrawGizmos()
    {
        
        for (int i = 0; i < physicsSystem.bodies.Count; i++)
        {
            PhysicsBody body = physicsSystem.bodies[i];
            if (body.isColliding)
            {
                Gizmos.color = Color.red;
            }
            else
            {
                Gizmos.color = Color.green;
            }
            if (body.shapeType == ShapeType.SPHERE)
                Gizmos.DrawSphere(body.pos, body.radius);
            else if (body.shapeType == ShapeType.PLANE)
                Gizmos.DrawCube(body.pos, new Vector3(5.0f, 0.0f, 5.0f));
            else if (body.shapeType == ShapeType.HALFSPACE)
            {

                Gizmos.color = Color.blue;
                Gizmos.DrawCube(body.pos, new Vector3(5.0f, 0.0f, 5.0f));
            }

        }

        
    }
    public void Relunach()
    {
        
        if (launchIndex < physicsSystem.bodies.Count)
        {
            PhysicsBody body = physicsSystem.bodies[launchIndex];
            body.vel = body.launchVelocity;
            launchIndex++;
        }
        else
        {
            
            launchIndex = 0;
        }
        
    }
    public void AddSphere()
    {
        PhysicsBody body = new PhysicsBody();
        body.pos = new Vector3(0.0f, Random.Range(1.0f, 4.0f) * 2.0f, 0.0f);
        body.vel = new Vector3(0.0f, Random.Range(5.0f, 15.0f), 0.0f);
        body.mass = Random.Range(0.5f, 2.0f);
        body.drag = 0.5f;
        body.shapeType = ShapeType.SPHERE;
        body.launchVelocity = new Vector3(Mathf.Cos(body.launchAngle * Mathf.Deg2Rad) * body.launchSpeed, Mathf.Sin(body.launchAngle * Mathf.Deg2Rad) * body.launchSpeed, 0f);
        physicsSystem.bodies.Add(body);
    }
    public void AddFloor()
    {
        PhysicsBody floor = new PhysicsBody();
        floor.pos = new Vector3(0.0f, -0.22f, 0.0f);
        floor.vel = Vector3.zero;
        floor.normal = Vector3.up;
        floor.mass = Random.Range(0.5f, 2.0f);
        floor.shapeType = ShapeType.PLANE;
        floor.dynamic = false;
        physicsSystem.bodies.Add(floor);
    }
    public void AddHalfspace()
    {
        PhysicsBody halfspace = new PhysicsBody();
        halfspace.pos = new Vector3(0.0f, 2.5f, 0.0f);
        halfspace.vel = Vector3.zero;
        halfspace.normal = Vector3.up;
        halfspace.mass = Random.Range(0.5f, 2.0f);
        halfspace.shapeType = ShapeType.HALFSPACE;  
        halfspace.dynamic = false; 
        physicsSystem.bodies.Add(halfspace);
    }
}
