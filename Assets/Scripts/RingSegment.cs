using UnityEngine;

public class RingSegment : MonoBehaviour{
    private bool selected;
    private bool Selected {
        get => Selected = selected;
        set {
            selected = value; gameObject.GetComponentInChildren<Renderer>().material.color = value ? Color.red : Color.white; 
            gameObject.GetComponentInChildren<Renderer>().forceRenderingOff = value;
        }
    }
    public Orbit orbit { get; private set; }
    private void Update() { if (!Selected) return;
        if (Input.GetKeyDown(KeyCode.UpArrow)) Up();
        if (Input.GetKeyDown(KeyCode.DownArrow)) Down();
    }
    private void StickToOrbit(Component orbit) {
        var t = transform;
        var pos = t.localPosition;
        t.localPosition = new Vector3(pos.x, orbit.transform.localPosition.y, pos.z);
    }
    public void OnTriggerEnter(Collider collider) {
        orbit = collider.gameObject.GetComponent<Orbit>(); StickToOrbit(orbit);
    }
    private void Up() { if (orbit.gameObject.CompareTag($"Upper Orbit")) return;
        var t = transform; var pos = t.localPosition;
        t.localPosition = new Vector3(pos.x,pos.y + 1f,pos.z);
    }
    private void Down() { if (orbit.gameObject.CompareTag($"Lower Orbit")) return;
        var t = transform;
        var pos = t.localPosition;
        t.localPosition = new Vector3(pos.x,pos.y - 1f,pos.z);
    }
    public void Toggle() { Selected = !Selected; }
}