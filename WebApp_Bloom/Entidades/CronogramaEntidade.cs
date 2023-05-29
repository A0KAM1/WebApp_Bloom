namespace WebApp_Bloom.Entidades
{
    public class CronogramaEntidade
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public CasamentoEntidade Casamento { get; set; }
        public int CasamentoId { get; set; }
    }
}
