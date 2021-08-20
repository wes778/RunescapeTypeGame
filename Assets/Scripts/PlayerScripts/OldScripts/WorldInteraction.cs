
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour
{
    Camera mainCamera;
    NavMeshAgent playerMovement;
    public Canvas inventory;
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        playerMovement = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())  
        {
            GetInteraction();
        }
        if(Input.GetKeyDown("i"))
        {
            if(inventory.enabled == true)
            {
                inventory.enabled = false;
            } else
            {
                inventory.enabled = true;
            }
            
        }
        #region a for attack
        /*        if(Input.GetKey("a"))
                {


                        MeleeWeapon curWeapon = pwc.GetCurrentWeapon();
                        if (curWeapon != null)
                        {
                        animator.Play("Player_Attack");
                            pwc.Attack();
                        }
                    }*/


        #endregion
    }

    void GetInteraction()
    {
        /* Ray interactionRay = mainCamera.ScreenPointToRay(Input.mousePosition);

         RaycastHit hitObject;

         if(Physics.Raycast(interactionRay, out hitObject, Mathf.Infinity))
         {
             GameObject objectInteracted = hitObject.collider.gameObject;
             if(objectInteracted.tag.CompareTo("InteractableObject") <= 0)
             {
                 objectInteracted.GetComponent<Interactable>().MoveToInteract(playerMovement);
             }
             else
             {
                 playerMovement.SetDestination(hitObject.point);
             }
         }*/

        Ray interactionRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitObject;

        if (Physics.Raycast(interactionRay, out hitObject, Mathf.Infinity))
        {
            Interactable objectInteracted = hitObject.collider.GetComponent<Interactable>();
            if (objectInteracted != null)
            {
                //objectInteracted.MoveToInteract(playerMovement);
            }
            else
            {
                playerMovement.SetDestination(hitObject.point);
            }
        }
    }
}
