using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;

namespace Estudos.Hotelaria.Consumer.Consumers;

public class HotelConsumerDefinition : ConsumerDefinition<HotelConsumer>
{
    public HotelConsumerDefinition()
    {
        Endpoint(x =>
        {
            x.Name = "hotel-queue-consumer";
            x.PrefetchCount = 1;
        });
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<HotelConsumer> consumerConfigurator)
    {
        consumerConfigurator.UseMessageRetry(retryConfigurator =>
        {
            retryConfigurator.Incremental(3,
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(5)
            );
        });

        consumerConfigurator.UseDelayedRedelivery(r =>
        {
            r.Intervals(
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(15),
                TimeSpan.FromSeconds(30)
            );
        });
    }
}