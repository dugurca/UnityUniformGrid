using UnityEngine;
using System.Collections;

public class GridUtils
{
	public static Vector3 GridStartPos(Vector3 gridPos, int numVoxel, float voxelSize)
	{
		var half = (numVoxel * voxelSize) / 2f;
		return gridPos - new Vector3(half, half, half);
	}

	public static Vector3 GridEndPos(Vector3 gridPos, int numVoxel, float voxelSize)
	{
		var half = (numVoxel * voxelSize) / 2f;
		return gridPos + new Vector3(half, half, half);
	}

	public static bool InGrid(Vector3 pos, Vector3 gridPos, int numVoxel, float voxelSize)
	{
		var start = GridStartPos(gridPos, numVoxel, voxelSize);
		var end = GridEndPos(gridPos, numVoxel, voxelSize);

		bool startOK = pos.x > start.x && pos.y > start.y && pos.z > start.z;
		bool endOK = pos.x < end.x && pos.y < end.y && pos.z < end.z;

		return startOK && endOK;
	}

}
