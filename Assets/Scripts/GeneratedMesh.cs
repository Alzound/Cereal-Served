using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ok... So i dont really know what this does... Aparently if there´s the case that you want to delete the mesh renderer or filter
//This instruction doesn't let you do it, or at least it gives you a fair warning. 

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GeneratedMesh : MonoBehaviour
{
	private Mesh mesh;
	public float xSize, zSize, ySize, ySize1;
	int y = 0; 
	private Vector3[] vertices;
	public float amplify=2, frecuency=2f, fi=3f;
	public float resultY; 

	private void Awake()
	{
		Generate();
	}

	private void Update()
	{
		ySize = amplify * Mathf.Sin(frecuency + fi);
		ColliderGenerator();
		Generate();


	}

	private void Generate()
	{
		//Script for the creation of the plane, and also the UV's


		GetComponent<MeshFilter>().mesh = mesh = new Mesh();
		mesh.name = "Procedural Grid";

		vertices = new Vector3[(int)((xSize + 1) *(ySize + 1) * (zSize + 1))];
		Vector2[] uv = new Vector2[vertices.Length];
		Vector4[] tangents = new Vector4[vertices.Length];
		Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
		for (int i = 0, z = 0; z <= zSize; z++)
		{
			for (int y = 0; y <= ySize; y++)
			{
					for (int x = 0; x <= xSize; x++, i++)
					{
						vertices[i] = new Vector3(x, y, z);
						uv[i] = new Vector3(x / xSize, y / ySize, z / zSize);
						tangents[i] = tangent;
					}
			}
		}
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.tangents = tangents;

		int[] triangles = new int[(int)(xSize * zSize * ySize * 6)];
		for (int ti = 0, vi = 0, z = 0; z < zSize; z++, vi++)
		{
			for (int y1 = 0; y1 < ySize1; y++)
			{
				for (int x = 0; x < xSize; x++, ti += 6, vi++)
				{
					triangles[ti] = vi;
					triangles[ti + 3] = triangles[ti + 2] = vi + 1;
					triangles[ti + 4] = triangles[ti + 1] = (int)(vi + xSize + 1);
					triangles[ti + 5] = (int)(vi + xSize + 2);
				}
			}
		}

		mesh.triangles = triangles;
		mesh.RecalculateNormals();
	}



	private void ColliderGenerator()
	{
		//Script for the collider to be updated in every frame so the game can manipulate everything in the right way
		MeshCollider meshV = GetComponent<MeshCollider>();
		if (meshV == null)
		{
			meshV = (MeshCollider)this.transform.gameObject.AddComponent(typeof(MeshCollider));
		}
		else
		{
			meshV.sharedMesh = null;
			meshV.sharedMesh = mesh;
		}
	}

	

	/*
	//desde el inspector
	public divisions = 1;

		//xSize * divisions = el número total de divisiones, dependiendo del tamaño de tu plano
		cutsX = (xSize* divisions);
		cutsY = (ySize* divisions);
		vertices = new Vector3[(cutsX + 1) * (cutsY + 1)];
		Vector2[] uv = new Vector2[vertices.Length];
	Vector4[] tangents = new Vector4[vertices.Length];
	Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);
		for (int i = 0, y = 0; y <= cutsY; y++) {
			for (int x = 0; x <= cutsX; x++, i++) {
				vertices[i] = new Vector3((x / divisions , y / divisions);
	uv[i] = new Vector2((float)(x / divisions) / xSize, (float) (y / divisions) / ySize);
				tangents[i] = tangent;
			}
		}
		mesh.vertices = vertices;
mesh.uv = uv;
mesh.tangents = tangents;

	*/
}
