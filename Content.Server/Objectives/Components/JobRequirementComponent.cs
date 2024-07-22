using Content.Server.Objectives.Systems;
using Content.Shared.Roles;
using Content.Shared.Roles.Jobs;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

/// <summary>
/// Requires that the player has a certain job to have this objective.
/// </summary>
[RegisterComponent, Access(typeof(JobRequirementSystem))]
public sealed partial class JobRequirementComponent : Component
{
    /// <summary>
    /// ID of the job to whitelist having this objective.
    /// </summary>
    [DataField(required: true, customTypeSerializer: typeof(PrototypeIdSerializer<JobPrototype>))]
    public string Job = string.Empty;
}
