using UnityEngine;

public class ShowDialogBouble : MonoBehaviour
{
    public Racoon racoon;
    public Animator animator;
    public GameObject dialogManager;

    private Dialog _dialog;
    private float _interactionDistance;
   

    private enum DialogStates
    {
        Gone,
        Open,
        Pop,
        Close,
    };
    private DialogStates state;

    // Start is called before the first frame update
    void Start()
    {
        _dialog = dialogManager.GetComponent<Dialog>();
        state = DialogStates.Gone;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case DialogStates.Gone:
                animator.SetTrigger("idle");
                if (Vector2.Distance(racoon.transform.position, racoon.player.transform.position) < racoon.interactDistance)
                {
                    state = DialogStates.Pop;
                }
                break;
            case DialogStates.Open:
                if (Input.GetKeyDown(KeyCode.Return) && !_dialog.interacting)
                {
                    _dialog.StartDialog();
                }

                // Racoon has finished talking but player is still in range of interacting
                if (_dialog.finishedTalking && Vector2.Distance(racoon.transform.position, racoon.player.transform.position) < racoon.interactDistance)
                {
                    _dialog.continueDisplay.text = "'Enter' to talk";
                }

                // Player moved too far away form racoon to interact
                if (Vector2.Distance(racoon.transform.position, racoon.player.transform.position) > racoon.interactDistance)
                {
                    state = DialogStates.Close;
                }
                break;
            case DialogStates.Pop:
                animator.SetTrigger("pop");
                _dialog.continueDisplay.text = "'Enter' to talk";
                state = DialogStates.Open;
                break;
            case DialogStates.Close:
                animator.SetTrigger("close");
                _dialog.CloseDialog();
                state = DialogStates.Gone;
                break;
        }
    }
}
