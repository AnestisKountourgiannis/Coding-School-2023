// See https://aka.ms/new-console-template for more information
namespace Session_07
{

    ActionRequest request = new ActionRequest();
    ActionResponse response = new ActionResponse();

    ActionResolver resolver = new ActionResolver();

    response = resolver.Execute(request);
}