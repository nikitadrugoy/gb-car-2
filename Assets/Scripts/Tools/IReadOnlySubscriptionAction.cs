using System;

namespace Tools.Tools
{
    public interface IReadOnlySubscriptionAction
    {
        void SubscribeOnChange(Action subscriptionAction);
        void UnSubscriptionOnChange(Action unsubscriptionAction);
    }
}