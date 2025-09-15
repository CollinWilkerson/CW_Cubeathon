using UnityEngine;

public class InputHandeler : MonoBehaviour
{
    private bool isReplaying, isRecording;
    private Invoker invoker;
    private playerBehavior playerBehavior;
    private HomingAttack homingAttack;
    private ICommand _buttonA, _buttonAUp, _buttonD, _buttonDUp, _buttonSpace, _buttonLM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        invoker = gameObject.AddComponent<Invoker>();
        playerBehavior = FindAnyObjectByType<playerBehavior>();
        homingAttack = FindAnyObjectByType<HomingAttack>();

        _buttonA = new Left(playerBehavior);
        _buttonD = new Right(playerBehavior);
        _buttonAUp = new LeftUp(playerBehavior);
        _buttonDUp = new RightUp(playerBehavior);
        _buttonSpace = new Jump(playerBehavior);
        _buttonLM = new HAttack(homingAttack);

        isReplaying = false;
        isRecording = true;
        invoker.Record();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReplaying && isRecording)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                invoker.ExecuteCommand(_buttonD);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                invoker.ExecuteCommand(_buttonA);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                invoker.ExecuteCommand(_buttonDUp);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                invoker.ExecuteCommand(_buttonAUp);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                invoker.ExecuteCommand(_buttonSpace);
            }
            if (Input.GetMouseButtonDown(0))
            {
                invoker.ExecuteCommand(_buttonLM);
            }
        }
    }

    public void StartReplay()
    {
        isRecording = false;
        isReplaying = true;
        invoker.Replay();
    }
}
