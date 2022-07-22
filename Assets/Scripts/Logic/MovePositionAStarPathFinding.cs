using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class MovePositionAStarPathFinding : MonoBehaviour
{
    public AIPath aiPath;
    private void Start()
    {
        aiPath = GetComponent<AIPath>();
    }
    void SetMovePosition(/*Vector3 movePosition = new Vector3()*/)
    {
        aiPath.destination = new Vector3();
    }
}
