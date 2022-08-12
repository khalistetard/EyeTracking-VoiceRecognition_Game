using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileManagement : MonoBehaviour
{
    GameObject[] projectiles; //list of projectiles
    public GameObject player; //player object
    //force strength initialization
    public float speed = 1f,sideF =1f, jumpF=1f;

    // FixedUpdate is called once per frame for physics use, it works almost like Update but is made better for cpu interactions with physics law
    private void FixedUpdate()
    {
        projectiles = player.GetComponent<MovementsShooting>().instantiatedObjects;
        for (int i=0; i<10 && projectiles[i] !=null; i++)
        {
            Vector3 target = projectiles[i].GetComponent<CollisionProjectile>().getTarget();
            //target.z +=  30;

            Vector3 direction = target - player.transform.position;
            direction.Normalize();
            /*Vector3 side = new Vector3(target.x - projectiles[i].transform.position.x,0,0);
            Vector3 jump = new Vector3(0, target.y - projectiles[i].transform.position.y, 0);
            Vector3 forward = new Vector3(0, 0, target.z - projectiles[i].transform.position.z);

            side *= sideF;
            jump *= jumpF;
            forward *= speed;


            side.Normalize();
            jump.Normalize();
            forward.Normalize();*/



            if (projectiles[i].transform.position.y > 5f || projectiles[i].transform.position.z >= target.z) { projectiles[i].GetComponent<CollisionProjectile>().isInAir = true; }
            if (projectiles[i].transform.position.z < target.z)
            {
                //projectiles[i].transform.position = Vector3.MoveTowards(projectiles[i].transform.position, target, speed*Time.deltaTime);
                projectiles[i].GetComponent<Rigidbody>().velocity = direction * speed;
            }
            //if (projectiles[i].GetComponent<CollisionProjectile>().isInAir && projectiles[i].transform.position.y > target.y) { direction.y = 1 / direction.y; projectiles[i].GetComponent<Rigidbody>().AddForce(direction); }

            //projectiles[i].transform.position = Vector3.

            //projectiles[i].GetComponent<Rigidbody>().velocity = projectiles[i].transform.position.normalized;


            /* if ( (projectiles[i].transform.position.x < target.x && target.x > 0) || (projectiles[i].transform.position.x > target.x && target.x <= 0) )
             {
                 //projectiles[i].transform.position = Vector3.MoveTowards(projectiles[i].transform.position, target, speed*Time.deltaTime);
                 projectiles[i].GetComponent<Rigidbody>().AddForce(side*sideF, ForceMode.VelocityChange);
             }
             if (projectiles[i].transform.position.y < target.y)
             {
                // if (target.y <= 1) { jumpF = 0.05f; }
                // if (target.y <= 2) { jumpF = 0.18f; }

                 //projectiles[i].transform.position = Vector3.MoveTowards(projectiles[i].transform.position, target, speed*Time.deltaTime);
                 projectiles[i].GetComponent<Rigidbody>().AddForce(jump * jumpF, ForceMode.VelocityChange);
             }*/
            /*
             if (projectiles[i].transform.position.z >= target.z-2 && jump.y>0)
             {
                 projectiles[i].GetComponent<Rigidbody>().AddForce(new Vector3(0,-jump.y * jumpF,0), ForceMode.VelocityChange);
             }*/

            if (projectiles[i].transform.position.y < -5)
            {
                player.GetComponent<MovementsShooting>().setShooting(false);
                Destroy(projectiles[i]);

            }
        }
    }
}
