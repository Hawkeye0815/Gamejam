using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

#if UNITY_EDITOR
/// <summary>
/// Helper class to draw custom gizmos for waypoints
/// </summary>
public class WaypointGizmos
{
    private static float lineWidth = 2f;
    private static float discRadius = 0.5f;
    private static Color colorLine = new Color(1, 0.28f, 0, 1);
    private static Color colorDisc = new Color(1, 0.28f, 0, 1f);
    

    public static void DrawWayPoints(List<Transform> Waypoints) 
    {
        if (Waypoints.Count == 0 || Waypoints[Waypoints.Count - 1] == null || Waypoints[0] == null)
            return;

        DrawLine(Waypoints[Waypoints.Count - 1].position, Waypoints[0].position);
        DrawDisc(Waypoints[0].position, Vector3.up);
        for (int i = 1; i < Waypoints.Count; i++)
        {
            DrawLine(Waypoints[i - 1].position, Waypoints[i].position);
            DrawDisc(Waypoints[i].position, Vector3.up);
        }
    }

    public static void DrawDisc(Vector3 startPosition, Vector3 normal) 
    {
        Handles.color = colorDisc;
        Handles.DrawSolidDisc(startPosition, normal, discRadius);
    }    

    public static void DrawLine(Vector3 from, Vector3 to) 
    {
        Handles.color = colorLine;
        Handles.DrawLine(from, to, lineWidth);
    }
}
#endif
