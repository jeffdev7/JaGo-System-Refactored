using System.ComponentModel.DataAnnotations;

namespace jago.Application.ViewModel
{
    public class PassengerViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
