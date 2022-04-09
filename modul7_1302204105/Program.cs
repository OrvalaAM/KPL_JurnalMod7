using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace modul7_1302201405
{
    class Program
    {
        public static void Main()
        {
            Bank bank = new Bank();
            bank.BankTransferConfig();
        }
        
    }
    class Bank
    {
        public void BankTransferConfig()
        {
            string dataStr = File.ReadAllText(@"C:\Users\orval\Documents\Kuliah\KPL\modul7_1302204105\modul7_1302204105\bank_transfer_config.json");
            dynamic data = JsonConvert.DeserializeObject(dataStr);
            int transfer;
            int biaya;
            if (data.lang == "en")
            {
                Console.Write("Please insert the amount of money to transfer: ");
            }
            else if (data.lang == "id")
            {
                Console.Write("Masukkan jumlah uang yang akan ditransfer: ");
            }
            transfer = Convert.ToInt32(Console.ReadLine());
            if(transfer <= Convert.ToInt32(data.transfer.threshold))
            {
                biaya = data.transfer.low_fee;
            }
            else
            {
                biaya = data.transfer.high_fee;
            }

            if (data.lang == "en")
            {
                Console.WriteLine("Transfer fee: " + transfer);
                Console.WriteLine("Total amount: " + (transfer+biaya));
                Console.WriteLine("Select transfer method:");
                int i = 1;
                foreach (var item in data.methods)
                {
                    Console.WriteLine(i + ". " + item);
                }
            }
            else if (data.lang == "id")
            {
                Console.WriteLine("Biaya transfer: " + transfer);
                Console.WriteLine("Total biaya: " + (transfer + biaya));
                Console.WriteLine("Pilih metode transfer:");
                int i = 1;
                foreach (var item in data.methods)
                {
                    Console.WriteLine(i + ". " + item);
                }
            }
        }
    }
}