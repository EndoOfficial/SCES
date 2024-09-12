using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject _camera;
    public Text actionButtonPrompt;

    public float raycastRange;
    public Vector3 Player;

    private Collectables coll;

    private bool raycheck;

    public string minutes;
    public string seconds;

    private float time;
    private Animator anim;


    public MouseLook mouseLook;

    public bool pressedEOnCollectable = false;
    public bool pressedEOnNPC = false;
    private bool pressedE = false;

    public Text DialogueText;
    private int index; // used to change dialogue text
    public AudioSource _audio;

    private void Start()
    {
        DialogueText = GameObject.Find("DialogueUIText").GetComponent<Text>();
    }
    // Start is called before the first frame update
    private void Update()
    {
        /*
            raycast checks to see if the character has the "SceneLoader" script component, which has a public string assigned to them individually,
            this string will have the exact name of the scene that is to be loaded.
            If the raycast hits on update it activates the UI element that has the action button prompt and allow for the player to load the scene from the sceneloader script
        */

        if (raycheck = Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hitinfo, raycastRange))
        {

            if (hitinfo.transform.CompareTag("NPC"))
            {
                actionButtonPrompt.gameObject.SetActive(true); // press E text
                var sceneLoader = hitinfo.transform.GetComponent<SceneLoader>();
                var dialogueLoader = hitinfo.transform.GetComponent<dialogueLoader>();
                _audio = hitinfo.transform.GetComponent<AudioSource>();
                if (Input.GetKeyDown(KeyCode.E) && !pressedEOnNPC)
                {
                    pressedEOnNPC = true; // toggle
                    actionButtonPrompt.gameObject.SetActive(false);
                    GameEvents.UIPanelToggle?.Invoke(true);
                    if (dialogueLoader != null)
                    {
                        dialogueLoader.StartDialogue(DialogueText, index, _audio); // open dialogue
                    }
                }

                else if (pressedEOnNPC) // to check if you've pressed E
                {
                    actionButtonPrompt.gameObject.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.E) && !pressedE)
                    {
                        pressedE = true;
                        DisableTextPannel();
                        StartCoroutine(LoadScene(sceneLoader, hitinfo));
                        if (_audio != null) _audio.Stop();

                    }
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow) && pressedEOnNPC)
                {
                    index = -1;
                    if (dialogueLoader != null)
                    {
                        dialogueLoader.ChangeDialogue(DialogueText, index, _audio); // open dialogue
                    }
                }

                if (Input.GetKeyDown(KeyCode.RightArrow) && pressedEOnNPC)
                {
                    index = 1;
                    if (dialogueLoader != null)
                    {
                        dialogueLoader.ChangeDialogue(DialogueText, index, _audio); // open dialogue
                    }
                }

            }

            else if (hitinfo.transform.CompareTag("Collectable")) //if your looking at a collectable
            {
                actionButtonPrompt.gameObject.SetActive(true); // press E text
                var dialogueLoader = hitinfo.transform.GetComponent<dialogueLoader>();
                _audio = hitinfo.transform.GetComponent<AudioSource>();
                if (Input.GetKeyDown(KeyCode.E) && !pressedEOnCollectable)
                {
                    pressedEOnCollectable = true;
                    actionButtonPrompt.gameObject.SetActive(false);
                    GameEvents.UIPanelToggle?.Invoke(true);
                    dialogueLoader.StartDialogue(DialogueText, index, _audio); // open dialogue
                }
                else if (pressedEOnCollectable)
                {
                    actionButtonPrompt.gameObject.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        pressedEOnCollectable = false;
                        DisableTextPannel();
                        if (_audio != null) _audio.Stop();
                    }
                }
            }
            else if (hitinfo.transform.CompareTag("GameWin"))
            {
                actionButtonPrompt.gameObject.SetActive(true);
                var sceneLoader = hitinfo.transform.GetComponent<SceneLoader>();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(LoadScene(sceneLoader, hitinfo));
                }
            }
            else
            {
                actionButtonPrompt.gameObject.SetActive(false);
                pressedEOnCollectable = false;
                pressedEOnNPC = false;
                DisableTextPannel();
                if (coll != null) coll.DisableCollect();
                if (_audio != null) _audio.Stop();
            }
        }

        else
        {
            actionButtonPrompt.gameObject.SetActive(false);
            pressedEOnCollectable = false;
            pressedEOnNPC = false;
            DisableTextPannel();
            if (coll != null) coll.DisableCollect();
            if(_audio != null) _audio.Stop();
        }
    }

    private IEnumerator LoadScene(SceneLoader sceneLoader, RaycastHit hitinfo)
    {
        StartCoroutine(FreezePlayer(hitinfo));
        GetComponent<Gun>().anim.SetTrigger("JackIn");
        yield return new WaitForSeconds(1.5f);

        GameEvents.UILoading?.Invoke(true);

        sceneLoader.LoadScene();
    }

    private IEnumerator FreezePlayer(RaycastHit hitinfo)
    {
        while (true)
        {
            GameObject.Find("Head").GetComponent<HeadBobController>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            mouseLook.enabled = false;
            yield return null;
        }
    }
    private void DisableTextPannel()
    {
        actionButtonPrompt.gameObject.SetActive(false);
        DialogueText.text = "";
        GameEvents.UIPanelToggle?.Invoke(false);
        if (_audio != null) _audio.Stop();
    }

}