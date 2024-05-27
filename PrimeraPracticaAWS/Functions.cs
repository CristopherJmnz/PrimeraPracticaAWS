using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using PrimeraPracticaAWS.Models;
using PrimeraPracticaAWS.Repositories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace PrimeraPracticaAWS;

public class Functions
{
    /// <summary>
    /// Default constructor that Lambda will invoke.
    /// </summary>
    private PelisRepository repo;
    public Functions(PelisRepository repo)
    {
        this.repo = repo;
    }


    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/")]
    public async Task<IHttpResult> Get(ILambdaContext context)
    {
        List<Pelicula> pelis = await this.repo.GetPeliculasAsync();

        return HttpResults.Ok(pelis);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/{actor}")]
    public async Task<IHttpResult> GetPelisActor(string actor,ILambdaContext context)
    {
        List<Pelicula> pelis = await this.repo.GetPeliculasActorAsync(actor);
        return HttpResults.Ok(pelis);
    }
}
