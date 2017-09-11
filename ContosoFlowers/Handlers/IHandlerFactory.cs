namespace ContosoFlowers.Handlers
{
    public interface IHandlerFactory
    {
        IIntentHandler CreateIntentHandler(string key);
    }
}
