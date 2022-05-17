using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class ShootingManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector3 offset;
    public Quaternion rotat;
    public void Shoot(Vector3 direcion)
    {
         var bullet =  Instantiate(bulletPrefab, transform.position + offset, Quaternion.identity);
         Tween.Position(bullet.transform, bullet.transform.position + direcion, 2f, 0f);
         Tween.Rotation(bullet.transform, bullet.transform.rotation * rotat, 2f, 0f);
         Destroy(bullet, 2f);
    }
}
