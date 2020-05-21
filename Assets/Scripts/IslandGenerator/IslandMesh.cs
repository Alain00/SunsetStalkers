﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMesh : MonoBehaviour
{
    public MeshFilter filter;

    public Mesh GenerateMesh(Vector3[] vertices, int[] triangles, Color[] colors){
        Mesh mesh;
        if (!filter.sharedMesh){
            mesh = new Mesh();
            filter.sharedMesh = mesh;
        }
        mesh = filter.sharedMesh;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
        mesh.RecalculateNormals();
        return mesh;
    }
}
