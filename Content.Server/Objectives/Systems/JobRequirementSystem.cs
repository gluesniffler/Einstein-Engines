using Content.Shared.Objectives.Components;
using Content.Shared.Roles.Jobs;

namespace Content.Server.Objectives.Systems;

/// <summary>
/// Handles checking the job whitelist for this objective.
/// </summary>
public sealed class JobRequirementSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<JobRequirementComponent, RequirementCheckEvent>(OnCheck);
    }

    private void OnCheck(EntityUid uid, JobRequirementComponent comp, ref RequirementCheckEvent args)
    {
        if (args.Cancelled)
            return;

        // if player has no job
        if (!TryComp<JobComponent>(args.MindId, out var job))
        {
            args.Cancelled = true;
            return;
        }

        if (job.Prototype != comp.Job)
            args.Cancelled = true;
    }
}
