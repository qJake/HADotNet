# HADotNet

A simple, straighforward .NET Standard library for the [Home Assistant](https://github.com/home-assistant/home-assistant) API.

## Features

* .NET Standard 2.0 cross-platform library
* DI-friendly client initialization (suitable for ASP.NET Core)
* Home Assistant data is represented by strongly-typed, commented model classes

## Getting Started

### From NuGet (Recommended)

Install **[HADotNet.Core](https://www.nuget.org/packages/HADotNet.Core/)** from NuGet:

`Install-Package HADotNet.Core`

### From Source

Clone this repo and either include the `HADotNet.Core` library in your project, 
or build the project and include the DLL as a reference.

## Examples

### Initializing The Client Factory

The `ClientFactory` class is reponsible for initializing all other clients in a 
reusable way, so you only have to define your instance URL and API key once.

To initialize the `ClientFactory`, pass in your base Home Assistant URL and a
long-lived access token that you created on your profile page.

```csharp
ClientFactory.Initialize("https://my-home-assistant-url/", "AbCdEf0123456789...");
```

### Getting Home Assistant's Current Configuration

Get a `ConfigClient` and then call `GetConfiguration()`:

```csharp
var configClient = ClientFactory.GetClient<ConfigClient>();
var config = await configClient.GetConfiguration();
// config.LocationName: "Home"
// config.Version: 0.96.1
```

### Retrieving All Entities

Get an `EntityClient` and then call `GetEntities()`:

```csharp
var entityClient = ClientFactory.GetClient<EntityClient>();
var entityList = await entityClient.GetEntities();
```

### Retrieving All Entity States

Get a `StatesClient` and then call `GetStates()`:

```csharp
var statesClient = ClientFactory.GetClient<StatesClient>();
var allMyStates = await statesClient.GetStates();
```

### Retrieving State By Entity

Get a `StatesClient` and then call `GetState(entity)`:

```csharp
var statesClient = ClientFactory.GetClient<StatesClient>();
var state = await statesClient.GetState("sun.sun");
// state.EntityId: "sun.sun"
// state.State: "below_horizon"
```

### Retrieving All Service Definitions

Get a `ServiceClient` and then call `GetServices()`:

```csharp
var serviceClient = ClientFactory.GetClient<ServiceClient>();
var services = await serviceClient.GetServices();
```

### Calling a Service

Get a `ServiceClient` and then call `CallService()`:

```csharp
var serviceClient = ClientFactory.GetClient<ServiceClient>();

var resultingState = await serviceClient.CallService("homeassistant", "restart");
// Or
var resultingState = await serviceClient.CallService("light", "turn_on", new { entity_id = "light.my_light" });
// Or
var resultingState = await serviceClient.CallService("light.turn_on", new { entity_id = "light.my_light" });
// Or
var resultingState = await serviceClient.CallService("light.turn_on", @"{""entity_id"":""light.my_light""}");
```

### Retrieving History for an Entity

Get a `HistoryClient` and then call `GetHistory(entityId)`:

```csharp
var historyClient = ClientFactory.GetClient<HistoryClient>();
var historyList = await historyClient.GetHistory("sun.sun");

// historyList.EntityId: "sun.sun"
// historyList[0].State: "above_horizon"
// historyList[0].LastUpdated: 2019-07-25 07:25:00
// historyList[1].State: "below_horizon"
// historyList[1].LastUpdated: 2019-07-25 20:06:00
```

### Rendering a Template

Get a `TemplateClient` and then call `RenderTemplate(templateBody)`:

```csharp
var templateClient = ClientFactory.GetClient<TemplateClient>();
var myRenderedTemplate = await templateClient.RenderTemplate("The sun is {{ states('sun.sun') }}");

// myRenderedTemplate: The sun is above_horizon
```

## Testing

To run the unit tests, you must first set two environment variables:

* `HADotNet:Tests:Instance` = `https://my-home-assistant-url/`
* `HADotNet:Tests:ApiKey` = `AbCdEf0123456789...`

## Collaborating

Fork the project, make some changes, and submit a pull request!

Be sure to follow the same coding style (generally, the standard Microsoft C# coding 
guidelines) and comment all publicly-visible types and members with XMLDoc comments.
