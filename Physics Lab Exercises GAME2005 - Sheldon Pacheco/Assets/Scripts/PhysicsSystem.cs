using UnityEngine;
using System.Collections.Generic;
public class PhysicsSystem 
{
    //default gravity of -9.81m/s^2 downwards along y
    public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);  
    //freq of 100 times per sec
    //public float stepFrequency = Time.fixedDeltaTime;    
    //public float frameTime = 0.0f;
    //public float frameRate = 1.0f;
    public float time = 0.0f;

    public List<PhysicsBody> bodies = new List<PhysicsBody>();
    private Game game;

    public PhysicsSystem(Game game)
    {
        this.game = game;
    }
    public void Step(float dt)
    {
        time += dt;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //    game.Relunach();
        //}
        if (bodies.Count < 5)
        {
            game.AddSphere();
        }
        for (int i = 0; i < bodies.Count; i++)
        {
            bodies[i].isColliding = false;
        }
        for (int i = bodies.Count - 1; i >= 0; i--)
        {
            PhysicsBody body = bodies[i];


            Vector3 acc = body.dynamic ? gravity / body.mass : Vector3.zero;


            body.vel *= Mathf.Pow(body.drag, dt);


            body.vel += acc * dt;
            body.pos += body.vel * dt;


            if (body.pos.y <= 0.0f)
            {
                body.vel.y = -body.vel.y * 1.5f;
                body.pos.y = 0.0f;
            }


            if (body.pos.x >= 12.0f)
            {
                bodies.RemoveAt(i);
                continue;
            }
            for (int j = i - 1; j >= 0; j--)
            {
                PhysicsBody secondBody = bodies[j];
                if (body.shapeType == ShapeType.SPHERE && body.shapeType == ShapeType.SPHERE)
                {
                    if (CircleCircle(body.pos, body.radius, secondBody.pos, secondBody.radius))
                    {
                        body.isColliding = true;
                        secondBody.isColliding = true;

                    }

                }
                else if (body.shapeType == ShapeType.PLANE && body.shapeType == ShapeType.SPHERE)
                {
                    if (CirclePlane(body.pos, body.radius, secondBody.pos, secondBody.normal))
                    {
                        body.isColliding = true;
                        secondBody.isColliding = true;

                    }

                }
                else if (body.shapeType == ShapeType.SPHERE && body.shapeType == ShapeType.HALFSPACE)
                {
                    if (CircleHalfspace(body.pos, body.radius, secondBody.pos, secondBody.normal))
                    {
                        body.isColliding = true;
                        secondBody.isColliding = true;
                    }

                }
                bodies[i] = body;
            }
        }
    }
    private bool CircleCircle (Vector3 center, float radius, Vector3 center2, float radius2)
    {
        float distance = Vector3.Distance(center, center2);
        return distance < (radius + radius2);
    }
    //LB6 TODO 2L complete this function to determine if a spheere and plane are overlapping
    private bool CirclePlane(Vector3 sphereCenter, float sphereRadius, Vector3 planePosition, Vector3 planeNormal)
    {
        // Step 1: Compute the relative position of the sphere to the plane
        Vector3 relativePosition = sphereCenter - planePosition;

        // Step 2: Project the sphere's position along the plane's normal to get the distance from the plane
        float distanceFromPlane = Vector3.Dot(relativePosition, planeNormal);

        // Step 3: Check if the sphere is overlapping with the plane
        // If the absolute distance from the plane is less than the sphere's radius, they are colliding
        return Mathf.Abs(distanceFromPlane) <= sphereRadius;

    }
    private bool CircleHalfspace(Vector3 sphereCenter, float sphereRadius, Vector3 halfspacePosition, Vector3 halfspaceNormal)
    {
        // Step 1: Compute the relative position of the sphere to the halfspace
        Vector3 relativePosition = sphereCenter - halfspacePosition;

        // Step 2: Project the sphere's position along the halfspace's normal to get the distance from the plane
        float distanceFromHalfspace = Vector3.Dot(relativePosition, halfspaceNormal);

        // Step 3: Check if the sphere is behind the halfspace plane
        // If the distance is less than or equal to the radius, the sphere is overlapping with the halfspace
        return distanceFromHalfspace <= sphereRadius;
    }

}
