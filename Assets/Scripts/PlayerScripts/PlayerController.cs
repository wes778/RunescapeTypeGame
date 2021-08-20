using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;
    PlayerMotor motor;
    //NavMeshAgent player;
    public Canvas inventory;
    public Canvas characterCanvas;
    //public GameObject testToBeDeleted;
    //public Equipment swordToBeDeleted;
    public HouseBuilding houseBuilding;

    public Interactable focus;


    //this is all for building
    GameObject buildableGameObject;
    BuildableItem buildableItem;
    public Vector3 offset;
    bool allowToBuild;


    public void SetAllowedToBuild(bool setAllowedToBuild)
    {
        allowToBuild = setAllowedToBuild;
    }
    public bool GetBuildableGameObjectNull()
    {
        return buildableGameObject == null;
    }

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
        motor = GetComponent<PlayerMotor>();
        //player = GetComponent<NavMeshAgent>();
    }

    public void SetBuildableItem(GameObject buildableGameObject, BuildableItem buildableItem, Vector3 offset)
    {
        this.buildableGameObject = buildableGameObject;
        this.buildableItem = buildableItem;
        this.offset = offset;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f, mask))
            {
                motor.Move(hit.point);
                RemoveFocus();
            }
        }

        
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f))
            {

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //print(interactable.name);
                if(interactable != null && interactable.name.CompareTo("Player") != 0)
                {
                    
                    SetFocus(interactable);
                    //interactable.Interact();
                }
            }
        }


        // this is to make the inventory pop up
        if(Input.GetKeyDown("i"))
        {
            //print("you hit i");
            if(inventory.enabled)
            {
                inventory.enabled = false;
            } 
            else
            {
                inventory.enabled = true;
            }
            
        }

        if(Input.GetKeyDown("c"))
        {
            if(characterCanvas.enabled)
            {
                characterCanvas.enabled = false;
            }
            else
            {
                characterCanvas.enabled = true;
            }
        }



        //this is all for building
        if(buildableGameObject != null)
        {
            buildableGameObject.transform.position = this.transform.position + offset;
        }

        if (Input.GetKeyDown("t"))
        {
            if(buildableGameObject != null && allowToBuild)
            {
                Instantiate(buildableItem.startOfBuild, buildableGameObject.transform.position, buildableGameObject.transform.rotation);
                Destroy(buildableGameObject);
                buildableItem = null;
                buildableGameObject = null;
            }
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            if(buildableGameObject != null)
            {
                Inventory.instance.Add(buildableItem);
                Destroy(buildableGameObject);
                buildableItem = null;
                buildableGameObject = null;
            }
        }
        if(Input.GetKey("r"))
        {
            if(buildableGameObject != null)
            {
                
                buildableGameObject.transform.Rotate(0, 50 * Time.deltaTime, 0);
            }
        }


    }

    void SetFocus(Interactable interactable)
    {
        if(interactable != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            
            focus = interactable;
            motor.FollowTarget(interactable);

        }

        
        interactable.OnFocused(this.transform);
        
    }

    void RemoveFocus()
    {

        if(focus != null)
        {
            focus.OnDefocused();
        }

        focus = null;
        
        motor.StopFollowingTarget();
    }
}
