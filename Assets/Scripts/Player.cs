using System.Security.Principal;
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
    private RaycastHit focus;
    private Touch firstTouch;
    
    private int centreOffset { get; set; }
    private void Update() {
        Physics.Raycast(transform.position,Vector3.forward,out focus,math.INFINITY);
        OnTap();
    }

    private void OnTap() {
        var segment = focus.rigidbody.gameObject.GetComponent<RingSegment>();
        if (!segment) return;
        
        var touch = Input.GetTouch(0);
        var x = touch.position.x;
        var y = touch.position.y;
        var w = Screen.width;
        var h = Screen.height;
        
        var statement = x < w*centreOffset && x > w*(1-centreOffset) && y < h*centreOffset && y > h*(1-centreOffset);
        if (statement) return;
        
        segment.Toggle();
    }
}