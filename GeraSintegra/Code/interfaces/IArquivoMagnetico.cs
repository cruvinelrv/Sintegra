using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public interface IArquivoMagnetico
    {
        //void informaConstrutor(IConstrutorTipo construtor);
        void insere(Tipo t);
        int countTipo50 { get; }
        int countTipo51 { get; }
        int countTipo53 { get; }
        int countTipo54 { get; }
        int countTipo55 { get; }
        int countTipo56 { get; }
        int countTipo60 { get; }
        int countTipo75 { get; }
        //int count { get; }
    }
}
