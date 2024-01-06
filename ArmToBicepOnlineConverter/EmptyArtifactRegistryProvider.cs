using System.Collections.Immutable;
using Bicep.Core.Registry;

public class EmptyArtifactRegistryProvider : IArtifactRegistryProvider
{
    public ImmutableArray<IArtifactRegistry> Registries(Uri _) => ImmutableArray<IArtifactRegistry>.Empty;
}
