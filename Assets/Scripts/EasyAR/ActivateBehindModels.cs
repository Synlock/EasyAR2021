using easyar;
using UnityEngine;

public class ActivateBehindModels : MonoBehaviour
{
    ARSession session;
    [SerializeField] GameObject[] behindModels;
    const string MODEL_TAG = "Model";
    const string CHILD_TAG = "Behind";

    void Start()
    {
        session = FindObjectOfType<ARSession>();
    }
    void Update()
    {
        Activate();
    }
    void Activate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = session.Assembly.Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.CompareTag(MODEL_TAG))
                {
                    hit.collider.GetComponent<MeshRenderer>().enabled = false;

                    foreach (GameObject obj in behindModels)
                    {
                        obj.SetActive(true);
                    }
                    return;
                }

                Transform firstChild = hit.transform.GetChild(0);
                if (hit.collider.CompareTag(CHILD_TAG))
                {
                    firstChild.gameObject.SetActive(true);
                    return;
                }
            }
        }
    }
}