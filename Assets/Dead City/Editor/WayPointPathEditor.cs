using Phyw.Utils;
using System.Linq;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.AI;

// Is used when the component needs to render itself in scene view
[CustomEditor(typeof(WayPointPath))]
public class WayPointPathEditor : Editor
{
  private WayPointPath path;

  // we get the object referenced here by a target property, then just cast it in
  private void OnSceneGUI()
  {
    path = (WayPointPath)target;
    GUIStyle style = new GUIStyle();
    style.normal.textColor = Color.yellow;
    //style.fontStyle = FontStyle.Bold;
    style.fontSize = 20;

    for (int i = 0; i < path.waypoints.Length; i++)
    {
      if (path.waypoints[i] != null)
      {
        Handles.Label(GetPosition(i) + Vector3.up * 0.5f, "Waypoint " + i, style);
      }
    }

    switch (path.mode)
    {
      case PathDisplayMode.Connections:
        Vector3[] points = path.waypoints.Select(x => x.position).ToArray();
        Handles.color = Color.yellow;
        Handles.DrawPolyLine(points);
        Handles.DrawLine(GetPosition(0), GetPosition(path.waypoints.Length - 1));
        break;

      case PathDisplayMode.Paths:
        // Navmesh is a singleton class, hence we can use CalculatePath to get the proper path
        NavMeshPath tempPath = new NavMeshPath();
        NavMesh.CalculatePath(GetPosition(path.PathStart), GetPosition(path.PathEnd), NavMesh.AllAreas, tempPath);

        if (tempPath.status != NavMeshPathStatus.PathInvalid)
        {
          Handles.color = tempPath.status == NavMeshPathStatus.PathComplete ? Color.green : Color.red;
          Handles.DrawPolyLine(tempPath.corners);
        }
        break;
    }
  }

  // Use when we need to render on inspector, custom elements and all
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
  }

  private Vector3 GetPosition(int index)
  {
    return path.waypoints[index].position;
  }
}