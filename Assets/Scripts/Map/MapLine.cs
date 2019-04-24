﻿/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLine : MapData
{
    public bool displayHandles = false;
    public List<Vector3> mapLocalPositions = new List<Vector3>();
    [System.NonSerialized]
    public List<Vector3> mapWorldPositions = new List<Vector3>();
    public LineType lineType;

    private void Draw(bool highlight = false)
    {
        if (mapLocalPositions.Count < 2) return;

        Color typeColor = Color.clear;
        switch (lineType)
        {
            case LineType.UNKNOWN:
                typeColor = Color.black;
                break;
            case LineType.SOLID_WHITE:
            case LineType.DOTTED_WHITE:
            case LineType.DOUBLE_WHITE:
                typeColor = whiteLineColor;
                break;
            case LineType.SOLID_YELLOW:
            case LineType.DOTTED_YELLOW:
            case LineType.DOUBLE_YELLOW:
                typeColor = yellowLineColor;
                break;
            case LineType.CURB:
                typeColor = curbColor;
                break;
            case LineType.STOP:
                typeColor = stopLineColor;
                break;
            default:
                break;
        }

        AnnotationGizmos.DrawWaypoints(transform, mapLocalPositions, MapAnnotationTool.PROXIMITY * 0.5f, typeColor, typeColor);
        AnnotationGizmos.DrawLines(transform, mapLocalPositions, typeColor);
    }

    protected virtual void OnDrawGizmos()
    {
        if (MapAnnotationTool.SHOW_MAP_ALL)
            Draw();
    }

    protected virtual void OnDrawGizmosSelected()
    {
        if (MapAnnotationTool.SHOW_MAP_SELECTED)
            Draw();
    }
}