using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace galaxypremiere.Domain.Common
{
    public class BaseEntityComment:BaseEntityGuid
    {
        public Guid? Parent { get; set; } = null; // x=null=> main comment | x!=null => subComment
        public string Comment { get; set; }
    }
}
