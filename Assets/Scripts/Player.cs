using System.Collections.Generic;
using System.Linq;
using GG.Infrastructure.Utils.Swipe;
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
    private IEnumerable<RingSegment> segments => FindObjectsOfType<RingSegment>();
    private SwipeListener SWL => GetComponent<SwipeListener>();

    private void Update() {
        var ray = new Ray(transform.position, transform.forward);
        SWL.OnSwipe.AddListener(OnSwipe);
        if (Physics.Raycast(ray, out var hit, 20)) {
            if (hit.collider.gameObject.CompareTag($"Ring")) {
                lookingAt = hit.transform.gameObject;
            }
        }
        Debug.DrawRay(transform.position, transform.forward*20 , Color.red);
    }

    public void OnClick() {
        if (lookingAt == null) {
            DeselectEverything();
            return;
        }
        var segment = lookingAt.GetComponentInChildren<RingSegment>();
        if (!segment) return;
        segment.Toggle();
    }
    private static void OnSwipe(string swipe) {
        Debug.Log(swipe);
    }
    private void OnDisable() {
        SWL.OnSwipe.RemoveListener(OnSwipe);
    }

    private void DeselectEverything() {
        foreach(var obj in segments) {
            if (obj.Selected) obj.Toggle();
        }
    }
    //swipe uses them
    public void SelectedUp() {
        if (segments == null) return;
        foreach (var segment in segments) {
            segment.Up();
        }
    }
    public void SelectedDown() {
        if (segments == null) return;
        foreach (var segment in segments) {
            segment.Down();
        }
    }
}