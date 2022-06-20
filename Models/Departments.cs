using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCoreWebAPiDemo.DepartmentModels
{
    public class Departments
    {
        
        [Key]
        
        public int DepartmentId
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
    }
}
