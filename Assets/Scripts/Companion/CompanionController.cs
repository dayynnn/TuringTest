using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompanionController : MonoBehaviour
{
    [SerializeField] private Queue<Command> commandQueue = new Queue<Command>();

    /*Command myElement = commandQueue.Dequeue();
    //the first element is now inside the variable "myELement"
    the second element is now in the first */

    Command currCommand;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (currCommand != null && !currCommand.IsCommandComplete()) return;
     
        if (commandQueue.Count == 0) return;
        
        currCommand = commandQueue.Dequeue();
        currCommand.Execute();
    }

    public void GiveCommand(Command newCommand)
    {
        newCommand.SetCompanionController(this);
        commandQueue.Enqueue(newCommand);

    }

    public void FinishCommand()
    {
        commandQueue.Dequeue().Cancel();
    }

    public NavMeshAgent GetNavMeshAgent() 
    {
        return _agent;
    }

}
