using Microsoft.EntityFrameworkCore;

namespace CoreMine.Data.ReadModels
{
    [Keyless]
    public class CategoryWithHierarchyReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string FullPath { get; set; } = string.Empty;
        public string FullCode { get; set; } = string.Empty;
        public int? ParentId { get; set; }
    }
}
