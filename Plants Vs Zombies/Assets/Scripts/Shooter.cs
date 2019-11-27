using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator anim;
    private Spawner myLaneSpawner;



    private void Start()
    {
        anim = GameObject.FindObjectOfType<Animator>();
        
        // Creates a parent if necessary
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
        print(myLaneSpawner);
    }

    private void Update()
    {
        if(isAttackerAheadInLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    void SetMyLaneSpawner()
    {
        // Look through all spawners and set mylanespawner if found
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + " can't find spawner in lane");
    }

    bool isAttackerAheadInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        
        // If there are attackers, are they ahead?
        foreach(Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        return false;
    }

    private void FireGun()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

}
