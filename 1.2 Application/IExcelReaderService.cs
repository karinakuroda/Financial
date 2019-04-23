using System;
using System.Collections.Generic;
using System.Text;

namespace _1._2_Application
{
    public interface IExcelReaderService
    {
        void Process(string filePath, int customerId);
    }
}
