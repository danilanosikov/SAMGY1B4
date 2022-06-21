using System.Security.Principal;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject lookingAt;
    
    private int centreOffset { get; set; }
    private void Update() {
        var ray = new Ray(transform.position, transform.forward);
        

        
        if (Physics.Raycast(ray, out var hit, 20)) {
            lookingAt = hit.transform.gameObject;
        }
        Debug.DrawRay(transform.position, transform.forward*20 , Color.red);
    }

    public void OnClick() {
        var segment = lookingAt.GetComponentInChildren<RingSegment>();
        if (!segment) return;
        segment.Toggle();
    }
}