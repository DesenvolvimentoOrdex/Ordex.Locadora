using Ordex.Locadora.Domain.Alugueis;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
using Ordex.Locadora.Shared.Roots;

namespace Ordex.Locadora.Domain.Vistorias
{
    public class Vistoria : Entity
    {
        public int CodigoAluguel { get; private set; }
        public bool SinistroEntrega { get; private set; }
        public int CodigoFuncionario { get; private set; }
        public DateTime DataRetirada { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public double TaxaSinistro { get; private set; }
        public bool PneuDianteiroEsquedo { get; private set; }
        public bool PneuDianteiroDireito { get; private set; }
        public bool PneuTraseiroEsquedo { get; private set; }
        public bool PneuTraseiroDireito { get; private set; }
        public bool PneuStep { get; private set; }
        public bool Riscado { get; private set; }
        public bool Amassado { get; private set; }
        public bool Quebrado { get; private set; }
        public bool Farol { get; private set; }
        public bool LuzDeFreio { get; private set; }
        public bool SetaDianteiraDireita { get; private set; }
        public bool SetaDianteiraEsquerda { get; private set; }
        public bool SetaTraseiraDireita { get; private set; }
        public bool SetaTraseiraEsquerda { get; private set; }
        public bool Extintor { get; private set; }
        public bool Triangulo { get; private set; }
        public bool Chave { get; private set; }
        public bool MacacoHidraulico { get; private set; }

        public Aluguel Aluguel { get; set; }
        public Funcionario Funcionario { get; set; }

        protected Vistoria()
        {

        }

    }
}
