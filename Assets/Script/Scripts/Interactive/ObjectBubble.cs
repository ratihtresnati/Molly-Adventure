using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SleepyKuma.Inventory;

namespace SleepyKuma.Interactive
{
    public class ObjectBubble : MonoBehaviour, IInteractable
    {
        private Interactor interactor;
        [SerializeField] private string changeScene;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private ItemsData itemsData;

        public bool Interact(Interactor interactor)
        {
            ClickOBject();
            return true;
        }

        public void ClickOBject()
        {
            interactor = FindObjectOfType<Interactor>();
            if (interactor != null)
            {
                if(interactor.InteractorCollider().tag == "Scene") GameManager.ChangeScene(changeScene);
                if(interactor.InteractorCollider().tag == "Objection") Inventory();
            }
        }

        public void Inventory()
        {
            InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();

            if (PauseMenuUI.Instance != null && winPanel != null && inventoryManager != null)
            {
                PauseMenuUI.Instance.PauseGame();
                winPanel.SetActive(true);
                inventoryManager.AddItem(itemsData);
                PanelWin.Instance.ShowItemsGet(itemsData);
            }
        }

        public void ClickNPC(){}
        public void Hide(){}
    }
}
