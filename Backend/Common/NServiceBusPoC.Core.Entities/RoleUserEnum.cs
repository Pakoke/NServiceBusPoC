using System.ComponentModel.DataAnnotations;

namespace NServiceBusPoC.Core.Entities
{
    public enum RoleUserEnum
    {
        [Display(Name = "Coach")]
        Coach = 0,

        [Display(Name = "Parent")]
        Parent = 1,

        [Display(Name = "Child")]
        Child = 2
    }
}
