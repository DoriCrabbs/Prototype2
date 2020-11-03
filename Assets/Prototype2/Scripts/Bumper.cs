using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class Bumper : MonoBehaviour
{
  [SerializeField]
  private int force;

  [SerializeField]
  private int forceMultiplier = 100;

  [SerializeField]
  private Transform mushroomImage;
  public void SetForce(int newforce)
  {
    force = newforce;
  }

  private void OnCollisionEnter(Collision collision)
  {
    collision.collider.GetComponent<Rigidbody>().AddForce(transform.up * forceMultiplier * force);
    if (mushroomImage)
    {
      //mushroomImage.DOPunchScale(new Vector3(0f, force * 0.06f, 0f), 1f);
      float time = 0.6f;
      int vibrato = 10;
      float elasticity = 0.9f;
      mushroomImage.DOPunchScale(new Vector3(0.01f, 0.12f, 0f), time, vibrato, elasticity);
    }
  }
}
