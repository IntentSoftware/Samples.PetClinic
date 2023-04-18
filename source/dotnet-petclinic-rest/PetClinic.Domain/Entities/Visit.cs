using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Ignore)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace PetClinic.Domain.Entities
{
    [IntentManaged(Mode.Merge)]
    [DefaultIntentManaged(Mode.Merge, Signature = Mode.Merge, Body = Mode.Ignore, Targets = Targets.Methods, AccessModifiers = AccessModifiers.Public)]
    public class Visit
    {
        public int Id { get; set; }

        public DateTime VisitDate { get; set; }

        public string Description { get; set; }

        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }

    }
}