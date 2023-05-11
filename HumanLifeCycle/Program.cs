using Akka.Actor;
using HumanLifeCycle.Actors;
using HumanLifeCycle.Messages;

namespace HumanLifeCycle;
internal class Program
{
    private static ActorSystem LifeCyclePhasesActorSystem;
    private static void Main(string[] args)
    {

        LifeCyclePhasesActorSystem = ActorSystem.Create("LifeCyclePhasesActorSystem");

        Props LifecycleActorProps = Props.Create<LifeCycleActor>();


        IActorRef lifeCycleActorRef = LifeCyclePhasesActorSystem.ActorOf(LifecycleActorProps, "LifecycleActorProps");
        var flag = 1;
        while (flag == 1)
        {
            try
            {
                Console.WriteLine("-1 - To exit the lifecycle");
                Console.WriteLine("0 - Change Life Phase");
                Console.WriteLine("Select Life activity. Select Number...");
                Console.WriteLine("1 - Crawl");
                Console.WriteLine("2 - Play with Toys");
                Console.WriteLine("3 - Play with friends");
                Console.WriteLine("4 - Go to school");
                Console.WriteLine("5 - Fight with parents");
                Console.WriteLine("6 - Go out with friends");
                Console.WriteLine("7 - Go to college");
                Console.WriteLine("8 - Drink beer");
                Console.WriteLine("9 - Get married");
                Console.WriteLine("10 - Go to work");
                Console.WriteLine("11 - Have kids");
                Console.WriteLine("12 - Retire");
                Console.WriteLine("13 - Enjoy life");
                Console.WriteLine("14 - Die");

                var messageType = Console.ReadLine();

                switch (messageType)
                {
                    case "-1":
                        lifeCycleActorRef.Tell(PoisonPill.Instance);
                        flag = -1;
                        break;
                    case "0":
                        lifeCycleActorRef.Tell(new ChangeLifePhase());
                        break;
                    case "1":
                        lifeCycleActorRef.Tell(new Crawl());
                        break;
                    case "2":
                        lifeCycleActorRef.Tell(new PlayWithToys());
                        break;
                    case "3":
                        lifeCycleActorRef.Tell(new PlayWithFriends());
                        break;
                    case "4":
                        lifeCycleActorRef.Tell(new GoToSchool());
                        break;
                    case "5":
                        lifeCycleActorRef.Tell(new FightWithParents());
                        break;
                    case "6":
                        lifeCycleActorRef.Tell(new GoOutWithFriends());
                        break;
                    case "7":
                        lifeCycleActorRef.Tell(new GoToCollege());
                        break;
                    case "8":
                        lifeCycleActorRef.Tell(new DrinkBeer());
                        break;
                    case "9":
                        lifeCycleActorRef.Tell(new GetMarried());
                        break;
                    case "10":
                        lifeCycleActorRef.Tell(new GoToWork());
                        break;
                    case "11":
                        lifeCycleActorRef.Tell(new HaveKids());
                        break;
                    case "12":
                        lifeCycleActorRef.Tell(new Retire());
                        break;
                    case "13":
                        lifeCycleActorRef.Tell(new EnjoyingLife());
                        break;
                    case "14":
                        lifeCycleActorRef.Tell(new Die());
                        break;
                    default:
                        break;
                }

            }
            catch (Exception)
            {
                LifeCyclePhasesActorSystem.Stop(lifeCycleActorRef);
            }
        }
        LifeCyclePhasesActorSystem.Dispose();
    }


}
