
while (true)
{
    DoorState doorCurrentState = DoorState.Locked;
    Console.Write($"The Door is {doorCurrentState}. What is your action? ");

}
enum DoorAction { Unlock, Open, Close, Lock };
enum DoorState { Open, Closed, Locked };
