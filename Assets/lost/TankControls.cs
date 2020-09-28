using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using InControl;

[RequireComponent(typeof(InControlInputModule))]
public class TankControls : MonoBehaviour
{
    MyCharacterActions characterActions;
    public Animator anim;
    public string LoseSceneName;
    public string WinSceneName;
    // Start is called before the first frame update
    void OnEnable()
    {
        characterActions = new MyCharacterActions();

        characterActions.mLeft.AddDefaultBinding(InputControlType.LeftStickLeft);
        characterActions.mRight.AddDefaultBinding(InputControlType.LeftStickRight);
        characterActions.mUp.AddDefaultBinding(InputControlType.LeftStickUp);
        characterActions.mDown.AddDefaultBinding(InputControlType.LeftStickDown);

        characterActions.mLeft.AddDefaultBinding(Key.LeftArrow);
        characterActions.mRight.AddDefaultBinding(Key.RightArrow);
        characterActions.mUp.AddDefaultBinding(Key.UpArrow);
        characterActions.mDown.AddDefaultBinding(Key.DownArrow);

        characterActions.Jump.AddDefaultBinding(InputControlType.Action4);
        characterActions.Jump.AddDefaultBinding(Key.Space);

        characterActions.Run.AddDefaultBinding(InputControlType.Action1);
        characterActions.Run.AddDefaultBinding(Key.RightControl);

    }
    bool dead = false;
    void die()
    {
        if (!dead) { 
        GetComponent<SceneLoader>().NextSceneName = LoseSceneName;
        GetComponent<SceneLoader>().Load();
            dead = true;
        }
    }

    public GameObject cube;
    public ghostScare camera;
    public void AddGhost(GameObject obj)
    {
        camera.relevantGhosts.Add(obj);
    }

    public void RemoveGhost(GameObject obj)
    {
        camera.relevantGhosts.Remove(obj);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.root.name.ToLower().Contains("tentacle"))
        {
            die();
        }
    }

    public List<Transform> souls;

    Transform getclosest() {
        if (souls.Count == 0) { return null; }
        Transform ret = souls[0];
        foreach (Transform transf in souls)
        {
            if (Vector3.Distance(anim.GetBoneTransform(HumanBodyBones.Hips).position, ret.position) > Vector3.Distance(anim.GetBoneTransform(HumanBodyBones.Hips).position, transf.position))
                ret = transf;
        }
        return ret;
    }

    public AudioSource staticSound;
    bool won = false;
    // Update is called once per frame
    void Update()
    {

        if (won)
            return;
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
        if (souls.Count == 0)
        {
            GetComponent<SceneLoader>().NextSceneName = WinSceneName;
            GetComponent<SceneLoader>().Load();
            won = true;
        }
        else
        {

            float dot = Vector3.Dot(anim.GetBoneTransform(HumanBodyBones.Hips).forward, (getclosest().position - anim.GetBoneTransform(HumanBodyBones.Hips).position).normalized);
           
            if (dot > 0.7f) { staticSound.volume = 0.8f * (dot - 0.7f); }
        }

 

        float x = characterActions.Move.LastValue.x;
        float z = characterActions.Move.LastValue.y;
        bool run = characterActions.Run.IsPressed;


        anim.SetFloat("Speed", z);
        anim.SetFloat("Direction", x);
        anim.SetBool("Run", run);
        if(z>0.5f && Mathf.Abs(x) > 0.2f)
        {
            transform.Rotate(new Vector3(0, x/(run ? 1: 3), 0));
        }

        if(Physics.Raycast(transform.position + transform.up*0.5f, Vector3.down, out RaycastHit hit, 10))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

    }
}
