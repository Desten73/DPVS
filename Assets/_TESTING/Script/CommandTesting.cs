using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Running());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            CommandManager.instance.Execute("moveCharDemo", "left");
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            CommandManager.instance.Execute("moveCharDemo", "right");
    }

    IEnumerator Running()
    {
        yield return CommandManager.instance.Execute("print");
        yield return CommandManager.instance.Execute("print_1p", "Hello World");
        yield return CommandManager.instance.Execute("print_mp", "Line 1", "Line 2", "Line 3");

        yield return CommandManager.instance.Execute("lambda");
        yield return CommandManager.instance.Execute("lambda_1p", "Hello lambda");
        yield return CommandManager.instance.Execute("lambda_mp", "lambda 1", "lambda 2", "lambda 3");

        yield return CommandManager.instance.Execute("process");
        yield return CommandManager.instance.Execute("process_1p", "3");
        yield return CommandManager.instance.Execute("process_mp", "process 1", "process 2", "process 3");
    }
}
