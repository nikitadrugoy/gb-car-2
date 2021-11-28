using Model.Analytic;
using Tools;

namespace Model
{
    public class ProfilePlayer
    {
        public ProfilePlayer(float speedCar, IAnalyticTools analytic)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            Analytic = analytic;
        }

        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }

        public IAnalyticTools Analytic { get; }
    }
}

