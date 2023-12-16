namespace DigitalArs_copia.DTO_s
{
    public class CreateAccountDTO
    {
        public decimal? Money { get; set; }
        public bool? IsBlocked { get; set; }
        public int UserId { get; set; }
    }
    public class AccountDTO
    {
        public int Id { get; set; }

        public DateTime CrationDate { get; set; }
        public decimal Money { get; set; }
        public bool IsBlocked { get; set; }
        public int UserId { get; set; }
    }
}
