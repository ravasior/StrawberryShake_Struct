namespace GraphQLServer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyGraphQL(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddGraphQLServer()
                .AddInMemorySubscriptions()
                .AddQueryType<Query>()
                .AddType<UnsignedIntType>()  // required for c# uint
                .BindRuntimeType<ModelId, ModelIdScalar>()
            ;
            return serviceCollection;
        }
    }
}
