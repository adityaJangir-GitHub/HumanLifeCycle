using Akka.Actor;
using HumanLifeCycle.Messages;

namespace HumanLifeCycle.Actors;
public class LifeCycleActor : ReceiveActor
{
    public LifeCycleActor()
    {

        Receive<IMessage>(message => NewBornPhase(message));

    }

    private void NewBornPhase(IMessage message)
    {
        switch (message)
        {
            case Crawl crawl:
                Console.WriteLine("Crawling");
                break;
            case PlayWithToys playWithToys:
                Console.WriteLine("Playing with Toys");
                break;
            case ChangeLifePhase phase:
                Become(() => ChildPhase(message));
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void ChildPhase(IMessage message)
    {
        switch (message)
        {
            case PlayWithFriends playWithFriends:
                Console.WriteLine("Playing with friends");
                break;
            case GoToSchool goToSchool:
                Console.WriteLine("Going to school");
                break;
            case ChangeLifePhase _:
                Become(() => TeenPhase(message));
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void TeenPhase(IMessage message)
    {
        switch (message)
        {
            case FightWithParents fightWithParents:
                Console.WriteLine("Fighting with parents");
                break;
            case GoOutWithFriends goOutWithFriends:
                Console.WriteLine("Going out with friends");
                break;
            case ChangeLifePhase _:
                Become(() => YoungPhase(message));
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void YoungPhase(IMessage message)
    {
        switch (message)
        {
            case GoToCollege goToCollege:
                Console.WriteLine("Going to college");
                break;
            case DrinkBeer drinkBeer:
                Console.WriteLine("Drinking beer");
                break;
            case ChangeLifePhase _:
                Become(() => AdultPhase(message));
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void AdultPhase(IMessage message)
    {
        switch (message)
        {
            case GetMarried getMarried:
                Console.WriteLine("Getting married");
                break;
            case GoToWork goToWork:
                Console.WriteLine("Going to work");
                break;
            case HaveKids haveKids:
                Console.WriteLine("Having kids");
                break;
            case ChangeLifePhase _:
                Become(() => ElderlyPhase(message));
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void ElderlyPhase(IMessage message)
    {
        switch (message)
        {
            case Retire retire:
                Console.WriteLine("Retiring");
                break;
            case EnjoyingLife enjoyingLife:
                Console.WriteLine("Enjoying life");
                break;
            case Die die:
                Console.WriteLine("Dead");
                break;
            case ChangeLifePhase _:
                Become(() => StopLifeCycle());
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void StopLifeCycle()
    {
        Console.WriteLine("Human Life cycle has been completed");
        Context.Stop(Self);
    }
}
