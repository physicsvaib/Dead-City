using UnityEditor.Search;
using UnityEngine;

public enum PathDisplayMode
{
  None, Connections, Paths
}

namespace Phyw.Utils
{
  public class WayPointPath : MonoBehaviour
  {
    [HideInInspector]
    public PathDisplayMode mode = PathDisplayMode.Connections;

    [HideInInspector]
    public int PathStart = 0, PathEnd = 0;

    public Transform[] waypoints;
  }
}