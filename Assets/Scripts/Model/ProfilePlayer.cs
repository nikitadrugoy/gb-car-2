using Model.Analytic;
using Tools;

namespace Model
{
    public class ProfilePlayer
    {
        public SubscriptionProperty<GameState> CurrentState { get; }

        public Car CurrentCar { get; }

        public IAnalyticTools Analytic { get; }
        
        public SubscriptionProperty<int> Gold { get; set; }
        
        public ProfilePlayer(float speedCar, IAnalyticTools analytic)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar);
            Analytic = analytic;
            Gold = new SubscriptionProperty<int>();
        }
    }
}

