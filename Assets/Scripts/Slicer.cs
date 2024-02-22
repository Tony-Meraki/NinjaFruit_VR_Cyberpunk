using UnityEngine;
using EzySlice;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Slicer : MonoBehaviour
{
    public Material materialAfterSlice;
    public LayerMask sliceMask;
    public bool isTouched;

    public int score = 0;

    public GameController gameController;

    ////When 
    ////점수획득시 칼의 길이 넓이 증가
    //public GameObject sword_;
    //public Vector3 scaleChange;

    //Sword Slicing Sound
    public AudioSource slice_sound;
    AudioSource audioSource;

    //TheEnd Sound
    [SerializeField] private AudioClip _clip;

    ////haptic Effect
    //public XRController xr;

    private void Start()
    {
        //sword_.transform.localScale = new Vector3(01.0f, +01.0f, 01.0f);
        //scaleChange = new Vector3(0.0f, +0.2f, 0.05f);
        this.audioSource = GetComponent<AudioSource>();

        ////Haptic effect
        //xr = (XRController)GameObject.FindObjectOfType(typeof(XRController));
    }

    private void Update()
    {
        if (isTouched == true)
        {
            isTouched = false;

            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);


            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                //SwordSound
                audioSource.Play();

                //If it's a bomb, the game is over, Fruits : +100, Metal : -200
                if (objectToBeSliced.gameObject.CompareTag("Fruit"))
                {
                    score += 100;
                }
                else if (objectToBeSliced.gameObject.CompareTag("Bomb"))
                {
                    SoundManager.Instance.PlaySound(_clip);
                    gameController.gameTimer = 0;
                }
                else if (objectToBeSliced.gameObject.CompareTag("Metal"))
                {
   
                    score -= 200;
                }


                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);


                //Sword Slicing Sound
                //sword_.transform.localScale += scaleChange;
                ////Haptic effect
                //float amplitude = 0.9f;
                //float duration = 0.9f;
                //xr.SendHapticImpulse(amplitude, duration);

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                Destroy(objectToBeSliced.gameObject);
            }
        }
    }

    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }


}
