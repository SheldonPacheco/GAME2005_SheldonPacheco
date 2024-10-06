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
    private PhysicsBody physicsBody;

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

        for (int i = bodies.Count - 1; i >= 0; i--) 
        {
            PhysicsBody body = bodies[i];

            
            Vector3 acc = gravity / body.mass;

            
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
            }
            else
            {
                bodies[i] = body; 
            }
        }
    }
}
