using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RayController : MonoBehaviour {

    public GameObject diveCamera;
    public GameObject buttonCollider;
    public Image buttonGauge;
    public int endPositionX = -4;
    float gaugeTime;
    Vector3 firstButtonGaugePosition;
    GameObject[] difficultyImages;

    void Update () {
        Ray ray = new Ray (diveCamera.transform.position, diveCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast (ray, out hit)) {
            Debug.DrawLine (ray.origin, hit.point, Color.black);

            if (hit.collider.gameObject.tag == "DifficultyCollider") {
                for (int i = 0; i < difficultyImages.Length; i++) { 
                    difficultyImages [i].GetComponent<Image> ().color = Color.white;
                }

                hit.collider.gameObject.transform.parent.GetComponent<Image> ().color = Color.red;
            }

            if (hit.collider.gameObject == buttonCollider) {
                gaugeTime += Time.deltaTime * 0.01f;
                buttonGauge.rectTransform.localPosition = Vector3.Lerp (buttonGauge.rectTransform.localPosition, new Vector3 (0, 0, 1), gaugeTime);
            } else {
                gaugeTime = 0;
                buttonGauge.rectTransform.localPosition = firstButtonGaugePosition;
            }
            if (buttonGauge.rectTransform.localPosition.x > endPositionX) {
                SceneManager.LoadScene ("Main");
                Debug.Log("ok");
            }
        }
    }
}
