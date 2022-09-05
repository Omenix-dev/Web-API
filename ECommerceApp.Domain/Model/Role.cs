using ECommerceApp.Domain.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Domain.Model
{
    public class Role : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
