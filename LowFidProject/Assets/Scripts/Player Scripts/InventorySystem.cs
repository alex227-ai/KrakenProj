using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Texture crosshairTexture;
    public PlayerController pc;
    public PickUpScript[] availableItems; // list with Prefabs of all the available items

    // available items slots
    int[] itemSlots = new int[12];
    bool showInventory = false;
    float windowAnimation = 1;
    float animationTimer = 0;

    // UI Drag and Drop
    int hoveringOverIndex = -1;
    int itemIndexToDrag = -1;
    Vector2 dragOffset = Vector2.zero;

    // Item Pick up
    PickUpScript detectedItem;
    int detectedItemIndex;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Initialize Item Slots
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Show/Hide Inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showInventory = !showInventory;
            animationTimer = 0;

            if (showInventory)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (animationTimer < 1)
        {
            animationTimer += Time.deltaTime;
        }

        if (showInventory)
        {
            windowAnimation = Mathf.Lerp(windowAnimation, 0, animationTimer);
            // pc.canMove = false;
        }
        else{
            windowAnimation = Mathf.Lerp(windowAnimation, 1f, animationTimer);
            // pc.canMove = true;
        }

        // Begin item drag
        if (Input.GetMouseButtonDown(0) && hoveringOverIndex > -1 && itemSlots[hoveringOverIndex] > -1)
        {
            itemIndexToDrag = hoveringOverIndex;
        }

        // Release dragged item
        if(Input.GetMouseButtonUp(0) && itemIndexToDrag > -1)
        {
            if (hoveringOverIndex < 0)
            {
                // drop the item outside
                //Instantiate(availableItems[itemSlots[itemIndexToDrag]],  Quaternion.identity);
            }
        }
    }
}
