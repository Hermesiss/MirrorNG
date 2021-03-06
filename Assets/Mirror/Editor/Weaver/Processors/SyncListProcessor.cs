using Mono.Cecil;

namespace Mirror.Weaver
{
    /// <summary>
    /// generates OnSerialize/OnDeserialize for SyncLists
    /// </summary>
    static class SyncListProcessor
    {
        /// <summary>
        /// Generates serialization methods for synclists
        /// </summary>
        /// <param name="td">The synclist class</param>
        /// <param name="mirrorBaseType">the base SyncObject td inherits from</param>
        public static void Process(TypeDefinition td, TypeReference mirrorBaseType)
        {
            var resolver = new GenericArgumentResolver(1);

            TypeReference itemType = resolver.GetGenericFromBaseClass(td, 0, mirrorBaseType);
            if (itemType != null)
            {
                SyncObjectProcessor.GenerateSerialization(td, itemType, mirrorBaseType, "SerializeItem", "DeserializeItem");
            }
            else
            {
                Weaver.Error($"Could not find generic arguments for {mirrorBaseType.Name} in {td}", td);
            }
        }
    }
}
