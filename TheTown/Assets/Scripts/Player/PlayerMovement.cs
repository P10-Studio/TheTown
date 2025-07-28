using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera cam;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        var ray = cam.ScreenPointToRay(Input.mousePosition);
        
        if (!Physics.Raycast(ray, out var hit)) return;
        
        var target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        agent.SetDestination(target);
    }

}
