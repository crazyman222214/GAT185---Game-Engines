using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class AutonomousAgent : AIAgent
{
    public Perception perception;
    [SerializeField] int shootingRange = 10;
    [SerializeField] GameObject rocket;
    [SerializeField] Transform barrel;

    //Shoot Timer
    private float timer = 0;
    private void Update()
    {


        //movement.ApplyForce(Vector3.forward * 10);
        //transform.position = Utilities.Wrap(transform.position, new Vector3(-5, -5, -5), new Vector3(5, 5, 5));

        Debug.DrawRay(transform.position, transform.forward * perception.maxDistance, Color.green);

        var gameObjects = perception.GetGameObjects();

        //If there are no objects in sight, stop moving
        if (gameObjects.Length == 0)
        {
            movement.Velocity = Vector3.zero;
            movement.Acceleration = Vector3.zero;
        }

        foreach (var go in gameObjects)
        {

            Debug.DrawLine(transform.position, go.transform.position, Color.red);



            //Moving towards the player

            Vector3 moveDirection = go.transform.position - transform.position;
            print (moveDirection.magnitude);

            if (moveDirection.sqrMagnitude < (shootingRange * shootingRange))
            {
                //Shooting range
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    Instantiate(rocket, barrel.position, barrel.rotation);
                    timer = 5;
                }

                print("near player");
                movement.ApplyForce(-movement.Velocity);
                movement.Velocity = Vector3.zero;
                movement.Acceleration = Vector3.zero;
            }
            else
            {
                movement.ApplyForce((moveDirection * Time.deltaTime).normalized);
                if (movement.Direction.sqrMagnitude > 0) transform.forward = movement.Direction;
            }
        }
    }
}
