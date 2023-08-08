# 15. Service Locator

When making your game you use many standardized methods to for example generate random numbers. These are called services and should be accessible from everywhere (globally) but still be independet from your game's main code. The pattern allows services to be easily replaced or extended without affecting the existing code that relies on them.    

**How to implement?**

Put each service in a static class. The static class should be in its own folder and have its own namespace to make sure you are not mixing the services with your main code.

Use a Service Locator that provides access to a service provider. To make sure no other methods than the ones you need are exposed to the outside world, the service provider should limit which methods it can provide access to.   

Unity has implemented this pattern in the form of the GetComponent() method.

**When is it useful?**

- Several services are already built-in into Unity, such as Random.Range() to get a random number, Mathf.PI to get pi, and Debug.Log() to display something in the console.

- In the game you may have different audio objects depending on if the game is running on a console or PC. This is the same example as in the book so you can find the code for it in the code section.  

- To inject dependencies into game objects or systems - aka dependency injection. Instead of hardcoding the references to specific services, game objects can use the service locator to request and retrieve the required services at runtime.

- To obtain the input service, abstracting away the underlying input device handling.

- Objects or systems that need to display localized text can use the service locator to retrieve the appropriate localization service.

- Objects that need AI functionality can use the service locator to access AI-related services, such as pathfinding or decision-making algorithms.

**Related patterns** 

- **Singleton.** Both provide a global access to an object. So the problems with the Singleton also applies to this pattern.  

- **Facade.** You can use Facade in combination with Service Locator.


## [Back](../)