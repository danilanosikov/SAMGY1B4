using Unity.Mathematics;
using UnityEngine;

/**
 * Casts a ray perpendicular to phone's surface and gets an in-game object,
 * which the ray hit.
 *
 * If screen centre was tapped =>
 * calls a "Select()" method of the gotten object.
 * 
 * When an object is selected and "UP" or "DOWN" buttons are pressed =>
 * The selected object moves respectively.
*/
public class Player : MonoBehaviour{
    private Ray ray;
    private RaycastHit focus;

    private void Update() {
        Physics.Raycast(transform.position,Vector3.forward,out focus,math.INFINITY);
    }
}