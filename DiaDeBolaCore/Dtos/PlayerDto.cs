namespace DiaDeBolaCore.Dtos
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public ApplicationUserDto UserDto { get; set; }
        public PlayerStatusDto PlayerStatusDto { get; set; }
    }
}
