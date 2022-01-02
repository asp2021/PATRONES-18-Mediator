using System;

namespace Mediator
{
    public interface IMediator
    {
        void RegisterRunWay(RunWay runway);
        void RegisterFlight(Flight flight);
        bool IsLandingOk();
        void SetLandingStatus(bool status);
    }

    public class Mediator : IMediator
    {
        private Flight _flight;
        private RunWay _runway;
        private bool _land;

        public bool IsLandingOk() => _land;
      

        public void RegisterFlight(Flight flight)
        {
            _flight = flight;
        }

        public void RegisterRunWay(RunWay runway)
        {
            _runway = runway;
        }

        public void SetLandingStatus(bool status)
        {
            _land = status;
        }
    }

    public class Flight
    {
        private IMediator _mediator;

        public Flight(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Land()
        {
            if(_mediator.IsLandingOk())
            {
                Console.WriteLine("Se puede aterrizar");
                _mediator.SetLandingStatus(true);
            }
            else
            {
                Console.WriteLine("Esperando disponibilidad");
            }
        }
    }

    public class RunWay
    {
        private IMediator _mediator;

        public RunWay(IMediator mediator)
        {
            _mediator = mediator;
            _mediator.SetLandingStatus(false);
        }

        public void Land()
        {
            Console.WriteLine("Permiso para aterrizar");
            _mediator.SetLandingStatus(true);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MEDIATOR" + "\n");
            Console.WriteLine("Se encarga de la comunicación entre distintos objetos." + "\n");

            IMediator mediator = new Mediator();
            Flight flight1 = new Flight(mediator);
            RunWay runWay = new RunWay(mediator);

            mediator.RegisterFlight(flight1);
            mediator.RegisterRunWay(runWay);

            flight1.Land();
            runWay.Land();
            flight1.Land();

            Console.ReadLine();


        }
    }
}
