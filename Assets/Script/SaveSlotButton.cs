using UnityEngine;
using UnityEngine.UI;

public class SaveSlotButton : MonoBehaviour
{
    // Public property to set the save slot index for each button
    public int SaveSlotIndex { get; set; }

    private Button button;

    private void Start()
    {
        // Mendapatkan referensi ke komponen Button
        button = GetComponent<Button>();

        // Menambahkan fungsi panggilan ketika tombol diklik
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        // Ketika tombol diklik, kirim notifikasi ke SaveLoadManager
        SaveLoad.Instance.HandleMouseClick(this);
    }
}
