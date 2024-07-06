using Phyw.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace Phyw.Examples
{
  [RequireComponent(typeof(NavMeshAgent))]
  public class AgentBasicMovement : MonoBehaviour
  {
    [SerializeField] private int StartIndex = 0;
    private NavMeshAgent agent;
    [SerializeField] private WayPointPath path;
    private NavMeshPathStatus status;

    #region UnityMethods

    private void Start()
    {
      agent = GetComponent<NavMeshAgent>();
      SetNextDestination(false);
    }

    private void Update()
    {
      status = agent.pathStatus;
      if (!agent.hasPath && !agent.pathPending || agent.pathStatus == NavMeshPathStatus.PathInvalid)
      {
        print("path recalculate");
        SetNextDestination(true);
      }
      else if (agent.isPathStale)
      {
        print("path recalculate as stale");
        SetNextDestination(false);
      }
    }

    #endregion UnityMethods

    #region CustomMethods

    public void SetNextDestination(bool inc)
    {
      if (inc)
      {
        StartIndex += 1;
      }

      StartIndex %= path.waypoints.Length;
      agent.SetDestination(path.waypoints[StartIndex].position);
    }

    #endregion CustomMethods
  }
}