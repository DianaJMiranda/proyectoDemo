using System.ComponentModel;

namespace proyectoDemo.Model
{
    internal class Person
    {
        
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Dirección")]
        public string Address { get; set; }
        [DisplayName("Num. Celular")]
        public string Smartphone {  get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}
