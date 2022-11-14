using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Model
{
    public class EstoqueTemMaterial
    {
        public int id_estoque_tem_material;
        public int quantidade_estoque;
        public int fk_id_material;
        public int fk_id_estoque;
    }
}
