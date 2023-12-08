namespace DigitalArs_copia.DTO_s
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        public RoleDTO? RoleDTO { get; set; }
    }
}
