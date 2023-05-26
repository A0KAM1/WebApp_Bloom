namespace WebApp_Bloom.Entidades
{
    public class Cronogramas_EventosEntidade
    {
        public int Id { get; set; }
        public CronogramaEntidade Cronograma { get; set; }
        public int CronogramaId { get; set; }
        public EventosEntidade Evento { get; set; }
        public int EventoId { get; set; }
    }
}
