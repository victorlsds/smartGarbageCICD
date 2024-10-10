namespace vstudy.smartgarbage.Model
{
    public class UsuarioModel
    {
        public int UsuarioId {  get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } //implementar codificação
        public string? Role { get; set; }
    }
}
