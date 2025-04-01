namespace GraphQLServer
{
    public class Query
    {
        public ModelId GetModelIdFromTypeAndInstance(ModelType type, uint instance) => new(type, instance);
        public ModelType? GetModelTypeFromModelId(ModelId? modelId) => modelId?.Type;
        public uint? GetModelInstanceFromModelId(ModelId? modelId) => modelId?.Instance;
        public uint? GetModelInstanceFromModelId2(ModelId modelId) => modelId.Instance;
    }
}
