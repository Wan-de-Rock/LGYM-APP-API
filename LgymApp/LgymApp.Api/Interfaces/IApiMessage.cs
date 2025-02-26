namespace LgymApp.Api.Interfaces;

/// <summary>
/// Represents a message in the API.
/// </summary>
public interface IApiMessage {}

/// <summary>
/// Represents a request message in the API.
/// </summary>
public interface IApiRequest : IApiMessage {}

/// <summary>
/// Represents a response message in the API.
/// </summary>
public interface IApiResponse : IApiMessage {}