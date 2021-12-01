using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    public void ActivateGO(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
