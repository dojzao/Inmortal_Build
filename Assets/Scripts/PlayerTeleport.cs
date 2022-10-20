using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter = null;
	
	private PlayerInputs entrada;
	
    void Update()
    {
		entrada = new PlayerInputs();
		entrada.Player.Interact.performed += DoInteract;
		entrada.Player.Interact.Enable();
    }
	
	private void DoInteract(InputAction.CallbackContext context) {
		StartCoroutine(teleportation());
	}

    IEnumerator teleportation()
    {
        yield return new WaitForSeconds(1);
        if(currentTeleporter != null)
        {
            transform.position = currentTeleporter.GetComponent<Portal>().GetDestination().position;
        }
        yield return new WaitForSeconds(3);
        

        
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Portal"))
        {
            currentTeleporter = collision.gameObject;
        }
    }
	
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Portal"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
