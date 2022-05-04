using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class StaticAirMovement : MonoBehaviour
{
    public float zRotation, duration;
    IEnumerator Start()
    {
        Transform body = transform.Find("body");
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        Tween.LocalRotation(body, Quaternion.Euler(0f, 0f, zRotation), duration, 0, AnimationCurve.Linear(0f,0f,1f,1f), Tween.LoopType.PingPong);
    }
}
