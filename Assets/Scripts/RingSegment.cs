using UnityEngine;

public class RingSegment : MonoBehaviour{
    private bool selected; // make an accessor, if you need to add animation of the selection
    public Orbit orbit { get; private set; }
    private void Update() { if (!selected) return;
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
    public void Toggle() { selected = !selected; }
}