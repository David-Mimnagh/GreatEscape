using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDestroyer : MonoBehaviour
{
	public void Explode(Vector2 worldPos, GameObject bomb)
	{
		Debug.Log($"WorldPosX: {worldPos.x}, WorldPosY: {worldPos.y}");
		var crackedWalls = GameObject.Find("CrackedWalls");
		Transform[] ts = crackedWalls.GetComponentsInChildren<Transform>();
		foreach (Transform child in ts)
		{
			//var crackedWallObj = GameObject.Find(child.name);
			//var m_Collider = crackedWallObj.GetComponent<BoxCollider2D>();
			//Debug.Log($"Cracked Wall Name: {m_Collider.bounds}");
		}
		//  Vector3Int originCell = tilemap.WorldToCell(worldPos);

		//ExplodeCell(originCell);
		//if (ExplodeCell(originCell + new Vector3Int(1, 0, 0)))
		//{
		//	ExplodeCell(originCell + new Vector3Int(2, 0, 0));
		//}

		//if (ExplodeCell(originCell + new Vector3Int(0, 1, 0)))
		//{
		//	ExplodeCell(originCell + new Vector3Int(0, 2, 0));
		//}

		//if (ExplodeCell(originCell + new Vector3Int(-1, 0, 0)))
		//{
		//	ExplodeCell(originCell + new Vector3Int(-2, 0, 0));
		//}

		//if (ExplodeCell(originCell + new Vector3Int(0, -1, 0)))
		//{
		//	ExplodeCell(originCell + new Vector3Int(0, -2, 0));
		//}

	}

	bool ExplodeCell(Vector3Int cell)
	{
		return true;
		//Tile tile = tilemap.GetTile<Tile>(cell);

		//if (tile == wallTile)
		//{
		//	return false;
		//}

		//if (tile == destructibleTile)
		//{
		//	tilemap.SetTile(cell, null);
		//}

		//Vector3 pos = tilemap.GetCellCenterWorld(cell);
		//Instantiate(explosionPrefab, pos, Quaternion.identity);

		//return true;
	}
}
