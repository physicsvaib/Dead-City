using UnityEngine;

namespace Phyw.Examples
{
  public class NavDoor : MonoBehaviour
  {
    private bool isOpen;

    #region UnityMethods

    private void Start()
    { }

    #endregion UnityMethods

    #region CustomMethods

    [ContextMenu("Toggle Door")]
    public void ToggleDoor()
    {
      isOpen = !isOpen;
      Vector3 finalPos = transform.position + (isOpen ? Vector3.up * 5 : Vector3.down * 5f);

      for (int i = 0; i < 30; i++)
      {
        transform.position = Vector3.Lerp(transform.position, finalPos, 0.5f);
      }
    }

    #endregion CustomMethods
  }
}