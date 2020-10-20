using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ShootComponent shootComponent;
    ParticleSystem particleSystem;

    new Rigidbody rigidbody;
    new Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        shootComponent = GetComponent<ShootComponent>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", rigidbody.velocity.magnitude);

        Vector3 dir;

        dir.x = Input.GetAxis("Horizontal");
        dir.y = 0;
        dir.z = Input.GetAxis("Vertical");

        rigidbody.velocity = dir * 5f;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, float.MaxValue))
        {
            Vector3 dirToCursor = hit.point - transform.position;
            dirToCursor.y = 0;
            transform.forward = dirToCursor;

            if (Input.GetButtonDown("Fire1"))
            {
                dirToCursor.y = transform.position.y;
                shootComponent.Shoot(dirToCursor);
                particleSystem.Play();
            }
        }
    }
}
