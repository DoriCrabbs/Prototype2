using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField]
    private int force;

    public void SetForce(int newforce)
    {
        force = newforce;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Pooiinng");
        collision.collider.GetComponent<Rigidbody>().AddForce(transform.up * 100f * force);
    }
}
