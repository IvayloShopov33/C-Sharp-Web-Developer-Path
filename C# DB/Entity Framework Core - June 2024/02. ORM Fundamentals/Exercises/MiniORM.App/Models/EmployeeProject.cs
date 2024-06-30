using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniORM.App.Models
{
    public class EmployeeProject
    {
        [Key, ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }

        [Key, ForeignKey(nameof(ProjectId))]
        public int ProjectId { get; set; }
    }
}
