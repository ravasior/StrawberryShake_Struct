using GraphQL.Client;
using GraphQLServer;

namespace TestProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            IMyClient theClient = GetClient();

            var result = await theClient.GetModelIdFromTypeAndInstance.ExecuteAsync(GraphQL.Client.ModelType.Type1, 0xbadf00d);
            ModelId? modelId = result.Data?.ModelIdFromTypeAndInstance;

            var result2 = await theClient.GetModelInstanceFromModelId.ExecuteAsync(modelId);
            uint? resultInstance = result2.Data?.ModelInstanceFromModelId;

            var result3 = await theClient.GetModelTypeFromModelId.ExecuteAsync(modelId);
            GraphQL.Client.ModelType? resultType = result3.Data?.ModelTypeFromModelId;

            Assert.AreEqual(GraphQL.Client.ModelType.Type1, resultType);
            Assert.AreEqual((uint)0xbadf00d, resultInstance);
        }

        public IMyClient GetClient()
        {
            ServiceCollection serviceCollection = new();

            serviceCollection
                .AddMyGraphQL()
                ;

            serviceCollection
                .AddSerializer<UnsignedIntSerializer>()
                .AddSerializer<ModelIdSerializer>()
                .AddMyClient()
                .ConfigureInMemoryClient()
            ;
            ServiceProvider services = serviceCollection.BuildServiceProvider();
            return services.GetRequiredService<IMyClient>();
        }
    }
}
