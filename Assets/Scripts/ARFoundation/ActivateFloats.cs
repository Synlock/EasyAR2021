using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ActivateFloats : MonoBehaviour
{
    [SerializeField] GameObject[] behindModels;
    const string MODEL_TAG = "Model";
    const string CHILD_TAG = "Behind";

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Activate();
    }
    void Activate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.CompareTag(MODEL_TAG))
                {
                    hit.collider.GetComponent<MeshRenderer>().enabled = false;

                    foreach (GameObject obj in behindModels)
                    {
                        obj.SetActive(true);
                        if (obj.GetComponent<ARAnchor>() == null)
                            obj.AddComponent<ARAnchor>();
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