namespace Producer.EmulsiveFactory.Contract.Tests.Models;

public enum ContractStrategy
{
    [System.ComponentModel.Description("ConsumerDriven")]
    Consumer,
    [System.ComponentModel.Description("ProducerDriven")]
    Producer
}