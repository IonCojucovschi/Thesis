using Int.Core.Attributes;

namespace Core.Models.DAL.Contracts
{
    public enum EnergySourceType
    {
        [StringValue("POD")] Gas,
        [StringValue("PDR")] Light
    }
}