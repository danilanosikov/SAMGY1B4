using System.Linq;
using UnityEngine;
public class Orbit : MonoBehaviour{
    // if all ring segments are on the same orbit - Integrity = true, false otherwise. 
    protected bool integrity => FindObjectsOfType<RingSegment>().All(segment => segment.orbit == this);
}