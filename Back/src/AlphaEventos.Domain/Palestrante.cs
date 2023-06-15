using System.Collections.Generic;

namespace AlphaEventos.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public string Minicurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string MyProperty { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocial> RedeSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrateEvento { get; set; }

    }
}