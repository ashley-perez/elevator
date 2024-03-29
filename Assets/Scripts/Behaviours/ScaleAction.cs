//// NOTES ////
//
//  - think of usability moving forward
//      - for example, would it be better if the block
//          expanded in every direction?
//      - does the scaling based on player direction feel intuitive?
//
//  - also, think of more organic ways to limit the scaling
//      - e.g. stops growing if it collides with object
//      - e.g. doesn't scale up if player is on it

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAction : MonoBehaviour
{
    public bool activated = false;
    [SerializeField] private PushAndPull pap;

    public GameObject target;

    public float growPower = 5f;
        [SerializeField] private Vector3 startScale;
        public float maxScale = 25f;
        public float minScale = 1f;

    // Start is called before the first frame update
    void Start()
    {

        activated = false;
        pap = GetComponent<PushAndPull>();
        
    }

    // Update is called once per frame
    void Update()
    {

        var move = Input.GetAxis("Mouse Y");

        if (activated) {

            var dir = transform.forward * move * Time.deltaTime * growPower;        // direction ur facing * mouse slide * time since last frame * scalar
            var localScale = target.transform.localScale;
            target.transform.localScale = new Vector3 (localScale.x + dir.x, localScale.y + dir.y, localScale.z + dir.z);

            // ==== LIMIT SCALE
            target.transform.localScale = new Vector3 (Mathf.Clamp(target.transform.localScale.x, minScale, startScale.x * maxScale),
                                                        Mathf.Clamp(target.transform.localScale.y, minScale, startScale.y * maxScale),
                                                        Mathf.Clamp(target.transform.localScale.z, minScale, startScale.z * maxScale));

        }
        
    }

    void OnDisable()
    {
        
        if (activated) {
            
            activated = false;

        }

    }

    void OnEnable()
    {

        pap.DisableControl(false, false, false);
        activated = true;

        maxScale = target.GetComponent<ScaleComponent>().maxScale;
        startScale = target.GetComponent<ScaleComponent>().startScale;

    }
}
