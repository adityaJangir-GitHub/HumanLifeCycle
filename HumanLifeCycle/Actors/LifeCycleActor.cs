using Akka.Actor;
using HumanLifeCycle.Messages;

namespace HumanLifeCycle.Actors;
public class LifeCycleActor : ReceiveActor
{
    private ICancelable _scheduledTask;
    public LifeCycleActor()
    {
        _scheduledTask = Context.System.Scheduler.ScheduleTellRepeatedlyCancelable(
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(2),
            Self,
            new ChangeLifePhase(),
            Self);


        Receive<IMessage>(message => NewBornPhase(message));

    }

    private void NewBornPhase(object message)
    {
        switch (message)
        {
            case Crawl crawl:
                Console.WriteLine("Crawling");
                break;
            case PlayWithToys playWithToys:
                Console.WriteLine("Playing with Toys");
                break;
            case ChangeLifePhase _:
                Become(ChildPhase);
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void ChildPhase(object message)
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
                Become(TeenPhase);
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void TeenPhase(object message)
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
                Become(YoungPhase);
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void YoungPhase(object message)
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
                Become(AdultPhase);
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void AdultPhase(object message)
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
                Become(ElderlyPhase);
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }
    private void ElderlyPhase(object message)
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
                _scheduledTask.Cancel();
                Become(Stopped);
                break;
            default:
                Console.WriteLine("Cannot perfrom this task at this moment");
                break;
        }
    }

    private void Stopped(object message)
    {
        switch (message)
        {
            case IMessage _:
                Console.WriteLine("The human life cycle is completed it cannot perforn any activity now please press -1 to exit");
                break;
        }
    }
}
