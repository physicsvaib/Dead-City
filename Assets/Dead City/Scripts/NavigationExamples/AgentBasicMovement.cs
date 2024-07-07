using Phyw.Utils;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Phyw.Examples
{
  [RequireComponent(typeof(NavMeshAgent))]
  public class AgentBasicMovement : MonoBehaviour
  {
    [SerializeField] private int StartIndex = 0;
    [SerializeField] private WayPointPath path;
    [SerializeField] private AnimationCurve curve;
    private NavMeshAgent agent;
    private NavMeshPathStatus status;
    private bool isJumping;

    #region UnityMethods

    private void Start()
    {
      agent = GetComponent<NavMeshAgent>();
      SetNextDestination(false);
    }

    private void Update()
    {
      if (agent.isOnOffMeshLink)
      {
        print("Waiting for link");
        if (!isJumping)
          StartCoroutine(Jump(1));
        return;
      }

      if (agent.remainingDistance < 2 && !agent.pathPending || agent.pathStatus == NavMeshPathStatus.PathInvalid)
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

    private IEnumerator Jump(float duration)
    {
      OffMeshLinkData linkData = agent.currentOffMeshLinkData;
      float timer = 0;
      agent.speed = 0.2f;
      isJumping = true;
      while (timer < duration)
      {
        agent.transform.position = (Vector3.Lerp(agent.transform.position, linkData.endPos + agent.baseOffset * Vector3.up, Time.deltaTime * 2)) + Vector3.up * curve.Evaluate(timer / duration);
        print($"Jumping {agent.transform.position} {linkData.endPos} {isJumping}");
        timer += Time.deltaTime;

        yield return null;
      }
      isJumping = false;
      agent.speed = 10;
      agent.CompleteOffMeshLink();
    }

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