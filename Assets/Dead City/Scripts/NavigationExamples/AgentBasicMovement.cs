using Phyw.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace Phyw.Examples
{
  [RequireComponent(typeof(NavMeshAgent))]
  public class AgentBasicMovement : MonoBehaviour
  {
    #region UnityMethods

    private NavMeshAgent agent;
    [SerializeField] private WayPointPath path;

    private void Start()
    {
      agent = GetComponent<NavMeshAgent>();
      print(path.waypoints[Random.Range(0, 5)].position);

      agent.SetDestination(path.waypoints[Random.Range(0, 5)].position);
    }

    #endregion UnityMethods

    #region CustomMethods

    public void Something()
    { }

    #endregion CustomMethods
  }
}