using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private int rayLength = 10;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {

            if (hit.collider.gameObject.GetComponent<IInteractable>() != null)
            {

                //If hit object is of type IInteractable, it can be used
                IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();

                GameUI.Instance.iText.text = interactable.ItemName;
                GameUI.Instance.crosshair.alpha = 1;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
            else
            {
                //Nothing in view...
                if (GameUI.Instance.iText.text.Length > 0)
                {
                    GameUI.Instance.iText.text = "";
                    GameUI.Instance.crosshair.alpha = 0.3f;
                }
            }
        }
        else
        {
            //Nothing in view...
            if (GameUI.Instance.iText.text.Length > 0)
            {
                GameUI.Instance.iText.text = "";
                GameUI.Instance.crosshair.alpha = 0.3f;
            }
        }
    }
}

//For instant interaction
public interface IInteractable
{
    string ItemName { get; set; }

    void Interact();
}
