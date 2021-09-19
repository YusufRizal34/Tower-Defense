using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Tower _placedTower;
    private int _towerTotal = 1;

    // Fungsi yang terpanggil sekali ketika ada object Rigidbody yang menyentuh area collider
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (_placedTower != null)
        {
            return;
        }

        Tower tower = collision.GetComponent<Tower> ();

        if (tower != null && _towerTotal > 0)
        {
            tower.SetPlacePosition (transform.position);
            _placedTower = tower;
            _towerTotal--;
        }
    }

    // Kebalikan dari OnTriggerEnter2D, fungsi ini terpanggil sekali ketika object tersebut meninggalkan area collider
    private void OnTriggerExit2D (Collider2D collision)
    {
        if (_placedTower == null)
        {
            return;
        }
        _placedTower.SetPlacePosition (null);
        _placedTower = null;
    }
}
