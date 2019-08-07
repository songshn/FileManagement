using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHJ.FileManagement.Files.FileEntities.Bills.ChangeBills
{
    public class ChangeBill : FileBase
    {
        public ChangeBill(string fileName) : base(fileName)
        {
        }

        /// <summary>
        /// 更换的页数
        /// </summary>
        public ICollection<int> PageIndex { get; set; }
    }
}
